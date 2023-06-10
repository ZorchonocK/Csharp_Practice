using System;
using System.Collections.Generic;
using System.Data;
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

namespace _27
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

        private void textIn1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string inputString = textIn1.Text;
            int count = 0;

            foreach (char c in inputString)
            {
                if (Char.IsDigit(c))
                {
                    count++;
                }
            }

            textOut1.Content = "Кол-во цифр: " + count;
        }




        public int[,] myArray;

        public void CreateArray(int row1, int row2)
        {
            myArray = new int[row1, row2];
            Random rnd = new Random();

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    myArray[i, j] = rnd.Next(1, 101);
                }
            }
        }

        public void SwapRows(int[,] array)
        {
            int columns = myArray.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                int temp = array[2, j];
                array[2, j] = array[4, j];
                array[4, j] = temp;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateArray(6, 4);

            DataTable dataTable = new DataTable();

            for (int i = 0; i < myArray.GetLength(1); i++)
            {
                dataTable.Columns.Add($"Column {i + 1}", typeof(int));
            }

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    row[j] = myArray[i, j];
                }
                dataTable.Rows.Add(row);
            }

            arrayGrid.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SwapRows(myArray);


            DataTable dataTable = new DataTable();

            for (int i = 0; i < myArray.GetLength(1); i++)
            {
                dataTable.Columns.Add($"Column {i + 1}", typeof(int));
            }

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    row[j] = myArray[i, j];
                }
                dataTable.Rows.Add(row);
            }

            arrayGrid.ItemsSource = dataTable.DefaultView;
        }

    }
}
