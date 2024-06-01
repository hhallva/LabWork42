using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1
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

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                inkCanvas.Children.Add(image);
            }
        }

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            ChengeColorDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                CurrentColorRectangle.Fill = new SolidColorBrush(dialog.CurrentColor);
                inkCanvas.DefaultDrawingAttributes.Color = dialog.CurrentColor;

            }

        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var size = SizeSlider.Value;
            if (inkCanvas != null)
            {
                inkCanvas.DefaultDrawingAttributes.Height = size;
                inkCanvas.DefaultDrawingAttributes.Width = size;
            }
           
        }
    }
}
