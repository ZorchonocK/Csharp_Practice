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

namespace _28
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

        public double[,] myArray;
        public double[,] myArray1;
        public double[,] result;
        public void CreateArray(int row1, int row2)
        {
            myArray = new double[row1, row2];
            myArray1 = new double[row1, row2];
            Random rnd = new Random();

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    myArray[i, j] = rnd.Next(1, 101);
                }
            }

            for (int i = 0; i < myArray1.GetLength(0); i++)
            {
                for (int j = 0; j < myArray1.GetLength(1); j++)
                {
                    myArray1[i, j] = rnd.Next(1, 101);
                }
            }
        }
  

        public static double[,] plusMatrices(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
                throw new ArgumentException("Matrices must have the same dimensions.");

            int rows = matrix1.GetLength(0);
            int columns = matrix1.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static double[,] minusMatrices(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
                throw new ArgumentException("Matrices must have the same dimensions.");

            int rows = matrix1.GetLength(0);
            int columns = matrix1.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static double[,] umnozhMatrices(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new ArgumentException("Number of columns in matrix1 must be equal to number of rows in matrix2.");

            int rows = matrix1.GetLength(0);
            int columns = matrix2.GetLength(1);
            int shared = matrix1.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < shared; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }


        public static double[,] MultiplyMatrixByNumber(double[,] matrix, double number)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }


        public static double[,] SortColumns(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int j = 0; j < columns; j++)
            {
                double[] column = new double[rows];
                for (int i = 0; i < rows; i++)
                {
                    column[i] = matrix[i, j];
                }

                Array.Sort(column);

                for (int i = 0; i < rows; i++)
                {
                    result[i, j] = column[i];
                }
            }

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateArray(3, 3);

            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();

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

            //

            for (int i = 0; i < myArray1.GetLength(1); i++)
            {
                dataTable1.Columns.Add($"Column {i + 1}", typeof(int));
            }

            for (int i = 0; i < myArray1.GetLength(0); i++)
            {
                DataRow row = dataTable1.NewRow();
                for (int j = 0; j < myArray1.GetLength(1); j++)
                {
                    row[j] = myArray1[i, j];
                }
                dataTable1.Rows.Add(row);
            }

            array1Grid.ItemsSource = dataTable.DefaultView;
            array2Grid.ItemsSource = dataTable1.DefaultView;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0); 
            int columns = matrix.GetLength(1); 
            double[,] result = new double[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public void ResultPerevod(double[,] matrix)
        {
            DataTable resultTable = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                resultTable.Columns.Add($"Column {i + 1}", typeof(int));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataRow row = resultTable.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                resultTable.Rows.Add(row);
            }

            resultGrid.ItemsSource = resultTable.DefaultView;
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ResultPerevod(plusMatrices(myArray, myArray1));
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ResultPerevod(minusMatrices(myArray, myArray1));

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ResultPerevod(umnozhMatrices(myArray, myArray1));

        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            ResultPerevod(SortColumns(myArray));

        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            ResultPerevod(SortColumns(myArray1));

        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            ResultPerevod(MultiplyMatrixByNumber(myArray1, Convert.ToDouble(chislo.Text)));

        }

        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            ResultPerevod(TransposeMatrix(myArray));
        }
    }
}