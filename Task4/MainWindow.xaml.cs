using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == true)
            {
                MediaListBox.ItemsSource = openFileDialog.FileNames;
                if (currentMediaElement.NaturalDuration.HasTimeSpan)
                {
                    TotalTimeText.Text = currentMediaElement.NaturalDuration.TimeSpan.ToString();
                    CurrentTimeText.Text = currentMediaElement.Position.ToString();
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            currentMediaElement.Play();
            timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            currentMediaElement.Pause();
            timer.Stop();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            currentMediaElement.Close();
            TotalTimeText.Text = "00:00:00";
            CurrentTimeText.Text = "00:00:00";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentMediaElement.NaturalDuration.HasTimeSpan)
            {
                TotalTimeText.Text = currentMediaElement.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
                CurrentTimeText.Text = currentMediaElement.Position.ToString(@"hh\:mm\:ss");
            }
        }

        private void MediaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFilePath = (string)MediaListBox.SelectedItem;
            if (selectedFilePath != null)
            {
                currentMediaElement.Source = new Uri(selectedFilePath);
            }
        }
    }
}
