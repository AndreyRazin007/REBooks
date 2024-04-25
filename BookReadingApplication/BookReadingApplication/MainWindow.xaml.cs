using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace BookReadingApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadMenuItem_Click(object sender, RoutedEventArgs args)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "PDF файлы (*.pdf)|*.pdf"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string file = openFileDialog.FileName;

                pdfViewer.Load(file);
            }
        }

        private void OpenDirectory_Click(object sender, RoutedEventArgs args)
        {
            string relativePath = "..\\..\\..\\SaveBooks\\";

            string fullPath = Path.GetFullPath(relativePath);
            string directoryPath = Path.GetDirectoryName(fullPath);

            if (Directory.Exists(directoryPath))
            {
                Process.Start("explorer.exe", directoryPath);
            }
            else
            {
                MessageBox.Show("Директория не существует!");
            }
        }

        private async void OpenPdfButton_Click(object sender, RoutedEventArgs args)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs args)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?",
                "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        Application.Current.Shutdown();
                        break;
                    }
                case MessageBoxResult.No:
                    {
                        break;
                    }
            }
        }
    }
}
