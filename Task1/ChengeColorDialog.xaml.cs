using System.Windows;
using System.Windows.Media;

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для ChengeColorDialog.xaml
    /// </summary>
    public partial class ChengeColorDialog : Window
    {
        public Color CurrentColor => Color.FromRgb(red, green, blue);

        byte red;
        byte green;
        byte blue;

        public ChengeColorDialog()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            red = (byte)RedSlider.Value;
            green = (byte)GreenSlider.Value;
            blue = (byte)BlueSlider.Value;
            ColorRectangle.Fill = new SolidColorBrush(CurrentColor);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
