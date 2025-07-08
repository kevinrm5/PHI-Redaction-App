# PHI Redaction Application

A Windows Forms application that identifies and redacts Protected Health Information (PHI) from lab order documents.

## Features

- Redacts sensitive patient information including names, dates of birth, SSNs, addresses, etc.
- Preserves original file structure while replacing PHI with `[REDACTED]`
- Simple and intuitive user interface
- Batch processing of multiple files

## Requirements

- .NET Framework 4.7.2 or later
- Windows OS

## Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/kevinrm5/PHI-Redaction-App.git
2. Open the solution in Visual Studio (2019 or later recommended)

## Running the Application
After successful build, run the application:
- Click the Start button in Visual Studio Or press F5 to debug
- The executable will be in bin\Debug or bin\Release

## Usage
1. Click "Select Lab Order Files" to choose one or more text files containing PHI
2. Selected files will appear in the list
3. Click "Process Files" to:
   - Select an output folder
   - Redact PHI from all selected files
   - Save sanitized versions with _sanitized.txt suffix
4. Status messages will show processing results

## PHI Identification Approach
The application uses regular expressions to identify and redact the PHI elements.

## Assumptions
1. Input Format:
   - Files are text-based with consistent labeling (e.g., "Patient Name:")
   - PHI follows common formats shown in the sample
2. Output Requirements:
   - Users want new files rather than modified originals
   - [REDACTED] placeholder is sufficient for all PHI types
3. Environment:
   - Application will run on Windows machines
   - Users have permission to read/write in selected folders

## Limitations
1. PHI Detection:
   - Address detection is basic and may miss complex formats
   - Doesn't handle unstructured PHI well (e.g., names in free text)
2. Performance:
   - Processes files sequentially (no parallel processing)
   - No progress reporting during large file processing
3. File Types:
   - Only handles text files (.txt)
   - Doesn't support PDF, DOCX, or other formats
