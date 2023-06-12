using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _25
{
    public partial class Form1 : Form
    {
        public string path;
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            path = filename;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLineAsync(textBox1.Text);
                }
                MessageBox.Show("Файл сохранен");
            }
            catch (Exception) { }
        }

        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = fontDialog.Font;
                textBox1.Font = selectedFont;
                MessageBox.Show("Шрифт и размер текста успешно изменены.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CarRecord> carRecords = new List<CarRecord>();

            // Формирование пяти записей
            carRecords.Add(new CarRecord("Audi", "1234 AB-1"));
            carRecords.Add(new CarRecord("BMW", "5678 CD-2"));
            carRecords.Add(new CarRecord("Mercedes", "9012 EF-3"));
            carRecords.Add(new CarRecord("Toyota", "3456 GH-4"));
            carRecords.Add(new CarRecord("Honda", "7890 IJ-5"));

            // Запись в файл
            string filePath = "car_records.txt";
            WriteCarRecordsToFile(carRecords, filePath);

            // Чтение из файла и определение марки по госномеру
            string licensePlate = textBox2.Text;
            string carMake = GetCarMakeByLicensePlate(filePath, licensePlate);
            label1.Text = $"Марка автомобиля с госномером {licensePlate}: {carMake}";
        }

        static void WriteCarRecordsToFile(List<CarRecord> carRecords, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (CarRecord record in carRecords)
                {
                    writer.WriteLine($"{record.CarMake},{record.LicensePlate}");
                }
            }
        }

        static string GetCarMakeByLicensePlate(string filePath, string licensePlate)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && parts[1] == licensePlate)
                    {
                        return parts[0];
                    }
                }
            }
            return "Марка не найдена";
        }

        class CarRecord
        {
            public string CarMake { get; set; }
            public string LicensePlate { get; set; }

            public CarRecord(string carMake, string licensePlate)
            {
                CarMake = carMake;
                LicensePlate = licensePlate;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "fibonacci.txt";
            int[] fibonacciNumbers = ReadFibonacciNumbers(filePath);
            int nextFibonacciNumber = CalculateNextFibonacciNumber(fibonacciNumbers);
            AddFibonacciNumberToFile(filePath, nextFibonacciNumber);

            label2.Text = "Файл успешно обновлен.";
        }


        static int[] ReadFibonacciNumbers(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int[] fibonacciNumbers = Array.ConvertAll(lines, int.Parse);
            return fibonacciNumbers;
        }

        static int CalculateNextFibonacciNumber(int[] fibonacciNumbers)
        {
            int n = fibonacciNumbers.Length;
            int nextFibonacciNumber = fibonacciNumbers[n - 1] + fibonacciNumbers[n - 2];
            return nextFibonacciNumber;
        }

        static void AddFibonacciNumberToFile(string filePath, int fibonacciNumber)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(fibonacciNumber);
            }
        }
    }
}
