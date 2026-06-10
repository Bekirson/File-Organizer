# Automated File Organizer

A lightweight, automated desktop filesystem utility designed to scan cluttered folders (like `Downloads` or `Desktop`) and dynamically sort files into structured subdirectories based on their file extensions and classification rules.

## ⚙️ Features
* **Extension-Based Sorting:** Automatically groups files into designated categories (e.g., `.pdf` and `.docx` into *Documents*, `.png` and `.jpg` into *Images*).
* **Automated Cleanup:** Safely handles high-volume directories to transform unorganized workspaces into structured structures instantly.
* **Streamlined IO Architecture:** Implements optimized filesystem input/output tracking routines to guarantee data integrity during file transfers.

## 📁 Sample Target Organization Structure
```text
📦 Target Folder (Before)             📦 Organized Folder (After)
 ├── invoice.pdf                       ├── 📂 Documents
 ├── photo.png         ──►             │    └── invoice.pdf
 ├── song.mp3                          ├── 📂 Images
 └── setup.exe                         │    └── photo.png
                                       └── 📂 Applications
                                            └── setup.exe