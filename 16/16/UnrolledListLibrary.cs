using System;

namespace UnrolledListLibrary
{
    public class UnrolledList<T>
    {
        private class Node
        {
            public T[] Array { get; set; }
            public int FilledCount { get; set; }
            public Node Next { get; set; }

            public Node(int size)
            {
                Array = new T[size];
                FilledCount = 0; 
                Next = null; 
            }
        }

        private Node head;
        private int arraySize;
        private int totalCount;

        public UnrolledList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Array size must be greater than zero.");
            }

            head = new Node(size); 
            arraySize = size; 
            totalCount = 0; 
        }

        public void Add(T item)
        {
            Node currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next; // Переход к следующему узлу списка
            }

            if (currentNode.FilledCount < arraySize) // Если в текущем массиве есть место
            {
                currentNode.Array[currentNode.FilledCount] = item; // Добавление элемента в текущий массив
                currentNode.FilledCount++; // Увеличение счетчика заполненных элементов в массиве
            }
            else // Если текущий массив полностью заполнен
            {
                Node newNode = new Node(arraySize); // Создание нового узла
                newNode.Array[0] = item; // Добавление элемента в новый массив
                newNode.FilledCount++; // Увеличение счетчика заполненных элементов в новом массиве
                currentNode.Next = newNode; // Связывание текущего узла со следующим узлом
            }

            totalCount++; // Увеличение общего счетчика элементов в списке
        }

        public T Get(int index)
        {
            if (index < 0 || index >= totalCount) // Проверка допустимости индекса
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node currentNode = head;
            int currentIndex = index;

            while (currentIndex >= arraySize) // Поиск узла, содержащего нужный элемент
            {
                currentNode = currentNode.Next; // Переход к следующему узлу списка
                currentIndex -= arraySize; // Уменьшение индекса на размер массива
            }

            return currentNode.Array[currentIndex]; // Возвращение элемента из соответствующего массива по индексу
        }
    }
}
