using System;

class CMD
{
    private ControlMyArray controller;

    public CMD()
    {
        MyArray model = new MyArray();
        ViewMyArray view = new ViewMyArray();
        controller = new ControlMyArray(model, view);
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Создать новый массив");
            Console.WriteLine("2. Вывести сумму элементов в строках без отрицательных элементов");
            Console.WriteLine("3. Вывести минимум среди сумм элементов параллельных диагоналей");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateArray();
                    break;
                case "2":
                    SumRows();
                    break;
                case "3":
                    MinSum();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод!");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            Console.ReadLine();
        }
    }

    private void CreateArray()
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] array = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Введите элемент [{i}, {j}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        controller.SetArray(array);
        Console.WriteLine("Массив успешно создан!");
    }

    private void SumRows()
    {
        int sum = controller.GetSumRows();
        Console.WriteLine("Сумма элементов в строках без отрицательных элементов: " + sum);
    }

    private void MinSum()
    {
        int minSum = controller.GetMinSum();
        Console.WriteLine("Минимум среди сумм элементов параллельных диагоналей: " + minSum);
    }
}

class MyArray
{
    private int[,] array;

    public MyArray()
    {
        array = null;
    }

    public MyArray(int[,] array)
    {
        this.array = array;
    }

    public void SetArray(int[,] array)
    {
        this.array = array;
    }

    public int[,] GetArray()
    {
        return array;
    }

    public static MyArray operator +(MyArray a, MyArray b)
    {
        int rows = a.array.GetLength(0);
        int cols = a.array.GetLength(1);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = a.array[i, j] + b.array[i, j];
            }
        }

        return new MyArray(result);
    }

    public static MyArray operator -(MyArray a, MyArray b)
    {
        int rows = a.array.GetLength(0);
        int cols = a.array.GetLength(1);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = a.array[i, j] - b.array[i, j];
            }
        }

        return new MyArray(result);
    }

    public static MyArray operator *(MyArray a, MyArray b)
    {
        int rowsA = a.array.GetLength(0);
        int colsA = a.array.GetLength(1);
        int rowsB = b.array.GetLength(0);
        int colsB = b.array.GetLength(1);

        if (colsA != rowsB)
        {
            throw new ArgumentException("Несовместимые размеры матриц!");
        }
        int[,] result = new int[rowsA, colsB];
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += a.array[i, k] * b.array[k, j];
                }
                result[i, j] = sum;
            }
        }

        return new MyArray(result);
    }

    public static MyArray operator /(MyArray a, int scalar)
    {
        int rows = a.array.GetLength(0);
        int cols = a.array.GetLength(1);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = a.array[i, j] / scalar;
            }
        }

        return new MyArray(result);
    }
}

class ControlMyArray
{
    private MyArray model;
    private ViewMyArray view;

    public ControlMyArray(MyArray model, ViewMyArray view)
    {
        this.model = model;
        this.view = view;
    }

    public void SetArray(int[,] array)
    {
        model.SetArray(array);
    }

    public int GetSumRows()
    {
        int[,] array = model.GetArray();
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += array[i, j];
                }
            }
        }

        return sum;
    }

    public int GetMinSum()
    {
        int[,] array = model.GetArray();
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        if (rows != cols)
        {
            throw new ArgumentException("Матрица должна быть квадратной!");
        }

        int minSum = int.MaxValue;
        for (int k = 1 - rows; k < cols; k++)
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int j = i + k;
                if (j >= 0 && j < cols)
                {
                    sum += array[i, j];
                }
            }
            if (sum < minSum)
            {
                minSum = sum;
            }
        }

        return minSum;
    }
}

class ViewMyArray
{
    public void DisplayArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        Console.WriteLine("Массив:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CMD cmd = new CMD();
        cmd.Run();
    }
}