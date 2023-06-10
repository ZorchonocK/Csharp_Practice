using System;
using System.Collections.Generic;
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

namespace Брееееед
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(txt1.Text);
                if (a == 1 || a == 2 || a == 12)
                {
                    txt2.Text = "Зима";
                }
                else if (a == 3  || a == 4 || a == 5) 
                {
                    txt2.Text = "Весна";
                }
                else if (a == 6 || a == 7 || a == 8)
                {
                    txt2.Text = "Лето";
                }
                else if (a == 9 || a == 10 || a == 11)
                {
                    txt2.Text = "Осень";
                }
                else
                {

                    MessageBox.Show("Введеные не верные данные");
                    txt2.Text = "";
                }
            }
            catch (Exception)
            {

                 MessageBox.Show("Введеные не верные данные");
                txt2.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txt3.Text);
                double y = (Math.Abs(Math.Pow(x, 2) - Math.Pow(x, 3))) - (7 * x) / (Math.Pow(x, 3) - 15 * x);
                txt4.Text = y.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Введеные не верные данные");
            }
        }
    }
}
