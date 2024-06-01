using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WinForms = System.Windows.Forms;



namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _imagePaths;
        private int _currentIndex;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder()
        {
            WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
                GetImagePaths(dialog.SelectedPath);
        }

        public void GetImagePaths(string folderName)
        {
            List<string> filePaths = Directory.GetFiles(folderName)
                                              .Where(file => file.EndsWith(".jpg") ||
                                                             file.EndsWith(".jpeg") ||
                                                             file.EndsWith(".png") ||
                                                             file.EndsWith(".bmp"))
                                              .ToList();
            _imagePaths = filePaths;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Image.Source = new BitmapImage(new Uri(_imagePaths[_currentIndex]));

            _currentIndex++;
            if (_currentIndex >= _imagePaths.Count)
                _currentIndex = 0;
        }

        private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            SelectFolder();


            if (_imagePaths.Count < 5)
            {
                MessageBox.Show("В папке дожно быть не меньше пяти изображений.");
                SelectFolder();
            }
            else
            {            
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.3);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }
    }
}


