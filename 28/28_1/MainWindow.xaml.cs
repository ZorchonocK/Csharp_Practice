using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _28_1
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

        public string path = "C:\\Практика\\28\\28_1\\bin\\Debug\\net7.0-windows\\note.txt";

        private void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textBox1.Text);

            path = saveFileDialog.FileName;
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(textBox1.Text);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                textBox1.Text = File.ReadAllText(openFileDialog.FileName);
            path = openFileDialog.FileName;
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string newFontFamily = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            textBox1.FontFamily = new System.Windows.Media.FontFamily(newFontFamily);
        }

        private void FontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            textBox1.FontSize = e.NewValue;
        }
    }
}
