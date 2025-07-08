using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhiRedactionApp
{
    public partial class Form1 : Form
    {
        private List<string> selectedFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Select Lab Order Files"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFiles.Clear();
                selectedFiles.AddRange(openFileDialog.FileNames);
                lstFiles.Items.Clear();
                lstFiles.Items.AddRange(openFileDialog.FileNames);
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("Please select at least one file to process.", "No Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Select Output Folder for Redacted Files"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFolder = folderBrowserDialog.SelectedPath;
                int processedCount = 0;

                foreach (string filePath in selectedFiles)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        string redactedContent = RedactPHI(fileContent);

                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        string outputPath = Path.Combine(outputFolder, $"{fileName}_sanitized.txt");

                        File.WriteAllText(outputPath, redactedContent);
                        processedCount++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {Path.GetFileName(filePath)}:\n{ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show($"Successfully processed {processedCount} of {selectedFiles.Count} files.", "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string RedactPHI(string input)
        {
            // Patterns for different PHI elements
            var patterns = new Dictionary<string, string>
            {
                // Patient Name (after "Patient Name:" or similar labels)
                { @"(?i)(Patient\s*Name\s*:\s*)([^\r\n]+)", "$1[REDACTED]" },
                
                // Date of Birth (MM/DD/YYYY format)
                { @"\b\d{1,2}/\d{1,2}/\d{2,4}\b", "[REDACTED]" },
                
                // Social Security Number (###-##-#### format)
                { @"\b\d{3}-\d{2}-\d{4}\b", "[REDACTED]" },
                
                // Address (simple pattern)
                { @"\b\d+\s+[\w\s]+,\s*[\w\s]+\b", "[REDACTED]" },
                
                // Phone Numbers ((111) 123-4567 format)
                { @"\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}\b", "[REDACTED]" },
                
                // Email addresses
                { @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", "[REDACTED]" },
                
                // Medical Record Number (MRN- followed by digits)
                { @"\bMRN-\d+\b", "[REDACTED]" }
            };

            string output = input;
            foreach (var pattern in patterns)
            {
                output = Regex.Replace(output, pattern.Key, pattern.Value, RegexOptions.IgnoreCase);
            }

            return output;
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}