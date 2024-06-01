using System;
using System.Dynamic;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer soundPlayer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SystemSoundButton_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Position = TimeSpan.Zero;
            VideoPlayer.Play();
        }

        private void SoundButton_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer = new SoundPlayer(@"Sounds/elevator.wav");
            soundPlayer.Play(); 
        }
    }
}

