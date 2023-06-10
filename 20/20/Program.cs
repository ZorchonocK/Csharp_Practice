using System;
using System.Linq;
using System.Xml.Linq;

namespace StudentGroupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "StudentGroup.xml";
            XDocument xmlDoc = XDocument.Load(xmlFilePath);

            Console.WriteLine("Доступные действия:");
            Console.WriteLine("1. Просмотреть список книг");
            Console.WriteLine("2. Добавить новую книгу");
            Console.WriteLine("3. Редактировать информацию о книге");
            Console.WriteLine("4. Удалить книгу");
            Console.WriteLine("5. Выход");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Введите номер действия (1-5):");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayBooks(xmlDoc);
                        break;
                    case "2":
                        AddBook(xmlDoc);
                        xmlDoc.Save(xmlFilePath);
                        break;
                    case "3":
                        EditBook(xmlDoc);
                        xmlDoc.Save(xmlFilePath);
                        break;
                    case "4":
                        DeleteBook(xmlDoc);
                        xmlDoc.Save(xmlFilePath);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный номер действия. Попробуйте ещё раз.");
                        break;
                }
            }

            Console.WriteLine("Работа с приложением завершена.");
        }

        static void DisplayBooks(XDocument xmlDoc)
        {
            var books = xmlDoc.Descendants("книга");
            Console.WriteLine("Список книг:");
            foreach (var book in books)
            {
                string lastName = book.Element("фамилия").Value;
                string firstName = book.Element("имя").Value;
                string birthDate = book.Element("дата_рождения").Value;

                Console.WriteLine($"Фамилия: {lastName}, Имя: {firstName}, Дата рождения: {birthDate}");
            }
        }

        static void AddBook(XDocument xmlDoc)
        {
            Console.WriteLine("Введите фамилию:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите имя:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите дату рождения (ГГГГ-ММ-ДД):");
            string birthDate = Console.ReadLine();

            XElement newBook = new XElement("книга",
                new XElement("фамилия", lastName),
                new XElement("имя", firstName),
                new XElement("дата_рождения", birthDate));

            xmlDoc.Element("Студенческая_группа").Add(newBook);

            Console.WriteLine("Новая книга добавлена.");
        }

        static void EditBook(XDocument xmlDoc)
        {
            Console.WriteLine("Введите фамилию книги, которую нужно отредактировать:");
            string targetLastName = Console.ReadLine();

            var book = xmlDoc.Descendants("книга")
                .FirstOrDefault(b => b.Element("фамилия").Value == targetLastName);

            if (book != null)
            {
                Console.WriteLine("Введите новую фамилию:");
                string newLastName = Console.ReadLine();

                Console.WriteLine("Введите новое имя:");
                string newFirstName = Console.ReadLine();

                Console.WriteLine("Введите новую дату рождения (ГГГГ-ММ-ДД):");
                string newBirthDate = Console.ReadLine();

                book.Element("фамилия").Value = newLastName;
                book.Element("имя").Value = newFirstName;
                book.Element("дата_рождения").Value = newBirthDate;

                Console.WriteLine("Книга отредактирована.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        static void DeleteBook(XDocument xmlDoc)
        {
            Console.WriteLine("Введите фамилию книги, которую нужно удалить:");
            string targetLastName = Console.ReadLine();

            var book = xmlDoc.Descendants("книга")
                .FirstOrDefault(b => b.Element("фамилия").Value == targetLastName);

            if (book != null)
            {
                book.Remove();
                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }
}