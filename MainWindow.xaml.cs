using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace FileOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void OrganizeButton_Click(Object sender, RoutedEventArgs e)
        {
            string target = HandleBrowse();

            if (string.IsNullOrWhiteSpace(target) || !Directory.Exists(target))
            {
                StatusLabel.Text = "Operation cancelled. No valid folder selected.";
                return;
            }

            StatusLabel.Text = "Organizing files...";

            IProgress<float> progressPipeline = new Progress<float>(percentage => // blackmagic
            {
                ProcessingProgress.Value = percentage;
            });

            await Task.Run(() =>
            {
                string[] files = Directory.GetFiles(target);
                int totalFiles = files.Length;
                int currentProccessed = 0;

                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file).ToUpper().Replace(".", "");

                    if (string.IsNullOrWhiteSpace(extension)) extension = "Uncategorized";

                    string destinationFolder = Path.Combine(target, extension);

                    if (!(Directory.Exists(destinationFolder)))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    string fileName = Path.GetFileName(file);
                    string destinationFile = Path.Combine(destinationFolder, fileName);

                    File.Move(file, destinationFile);

                    currentProccessed++;
                    float percentage = ((float)currentProccessed / totalFiles) * 100;
                    progressPipeline.Report(percentage);

                    //Thread.Sleep(3000);
                }
            });

            StatusLabel.Text = "Finished Organizing!";
        }

        public string HandleBrowse()
        {
            OpenFolderDialog folderDialog = new OpenFolderDialog();

            folderDialog.Title = "Select a Folder to Organize";

            if (folderDialog.ShowDialog() == true)
            {
                return folderDialog.FolderName;
            }

            return string.Empty;
        }
    }
}