using System;
using System.Data.SqlClient;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source = DESKTOP-Q3UVIVB;Initial Catalog = mylibrary;Integrated Security = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                bool cycle = true;
                while (cycle)
                {
                    try
                    {
                        Console.WriteLine("\nВыберите действие:");
                        Console.WriteLine("1. Добавить читателя в базу");
                        Console.WriteLine("2. Добавить книгу в базу");

                        Console.WriteLine("\n3. Взять книгу");
                        Console.WriteLine("4. Отдать книгу");

                        Console.WriteLine("\n5. Удалить книгу из базы");
                        Console.WriteLine("6. Удалить читателя из базы");

                        Console.WriteLine("\n7. Изменить данные книги");
                        Console.WriteLine("8. Изменить данные о читателе");

                        Console.WriteLine("\n9. Выйти");

                        int sol = Convert.ToInt32(Console.ReadLine());

                        switch (sol)
                        {
                            //Добавление данных в таблицу
                            case 1:
                                Console.WriteLine("Введите имя");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите фамилия");
                                string familiya = Console.ReadLine();
                                Console.WriteLine("Введите номер");
                                string phnumber = Console.ReadLine();

                                AddReader(connection, name, familiya, new DateTime(1990, 5, 15), "123 Main St", phnumber);
                                break;
                            case 2:
                                Console.WriteLine("Введите название книги");
                                string bookname = Console.ReadLine();
                                Console.WriteLine("Введите писателя");
                                string pisately = Console.ReadLine();

                                AddBook(connection, bookname, pisately, "Scribner", 1925);
                                break;

                            //Добавление и удаление взятой книги
                            case 3:
                                Console.WriteLine("Введите Id читателя");
                                int readerId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите Id книги");
                                int bookId = Convert.ToInt32(Console.ReadLine());

                                AddMest(connection, bookId, readerId);
                                break;
                            case 4:
                                Console.WriteLine("Введите id к");
                                int idexemp = Convert.ToInt32(Console.ReadLine());

                                DeleteMest(connection, idexemp);
                                break;

                            //Удаление данных с таблицы
                            case 5:
                                Console.WriteLine("Введите id Книги");
                                int idbook = Convert.ToInt32(Console.ReadLine());

                                DeleteBook(connection, idbook);
                                break;
                            case 6:
                                Console.WriteLine("Введите id Читателя");
                                int idpers = Convert.ToInt32(Console.ReadLine());

                                DeletePerson(connection, idpers);
                                break;

                            //Обновление данных
                            case 7:
                                Console.WriteLine("Введите id Книги");
                                idbook = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Что хотите изменить?");
                                Console.WriteLine("1. Название");
                                Console.WriteLine("2. Автора");
                                Console.WriteLine("3. Издательство");
                                Console.WriteLine("4. Год издания");

                                int sol1 = Convert.ToInt32(Console.ReadLine());
                                switch (sol1)
                                {
                                    case 1:
                                        Console.WriteLine("Введите название");
                                        string nameb = Console.ReadLine();

                                        UpdateBookName(connection, idbook, nameb);
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите автора");
                                        string avtor = Console.ReadLine();

                                        UpdateBookAvtor(connection, idbook, avtor);
                                        break;
                                    case 3:
                                        Console.WriteLine("Введите издательство");
                                        string izdately = Console.ReadLine();

                                        UpdateBookIzdately(connection, idbook, izdately);
                                        break;
                                    case 4:
                                        Console.WriteLine("Введите год издания");
                                        string godIzdan = Console.ReadLine();

                                        UpdateBookGod(connection, idbook, godIzdan);
                                        break;
                                    default:
                                        Console.WriteLine("Неправильный выбор");
                                        break;
                                }
                                break;

                            case 8:
                                Console.WriteLine("Введите id Читателя");
                                idpers = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Что хотите изменить?");
                                Console.WriteLine("1. Имя");
                                Console.WriteLine("2. Фамилию");
                                Console.WriteLine("3. Адрес");
                                Console.WriteLine("4. Номер");

                                int sol2 = Convert.ToInt32(Console.ReadLine());
                                switch (sol2)
                                {
                                    case 1:
                                        Console.WriteLine("Введите новое имя");
                                        string newname = Console.ReadLine();

                                        UpdateReaderName(connection, idpers, newname);
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите новую фамилию");
                                        string newSurname = Console.ReadLine();

                                        UpdateReaderSurname(connection, idpers, newSurname);
                                        break;
                                    case 3:
                                        Console.WriteLine("Введите новый адрес");
                                        string address = Console.ReadLine();

                                        UpdateReaderAddress(connection, idpers, address);
                                        break; 
                                    case 4:
                                        Console.WriteLine("Введите новый номер");
                                        string phoneNum = Console.ReadLine();

                                        UpdateReaderNumber(connection, idpers, phoneNum);
                                        break;
                                    default:
                                        Console.WriteLine("Неправильный выбор");
                                        break;
                                }

                                break;

                            //Выход
                            case 9:
                                Console.WriteLine("Досвидания!");
                                cycle = false;
                                break;

                            default:
                                Console.WriteLine("Неправильный выбор");
                                break;
                        }
                    }
                    catch (Exception) { }
                }


                connection.Close();
            }

            Console.WriteLine("Все операции выполнены успешно.");
            Console.ReadLine();
        }

        //Функции добавления данных
        static void AddReader(SqlConnection connection, string firstName, string lastName, DateTime birthDate, string address, string contactNumber)
        {
            string query = "INSERT INTO Читатели (ID_Читателя, Имя, Фамилия, Дата_рождения, Адрес, Контактный_номер) " +
                           "VALUES (@ID_Читателя, @Имя, @Фамилия, @Дата_рождения, @Адрес, @Контактный_номер)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Читателя", GetNextReaderId(connection));
            command.Parameters.AddWithValue("@Имя", firstName);
            command.Parameters.AddWithValue("@Фамилия", lastName);
            command.Parameters.AddWithValue("@Дата_рождения", birthDate);
            command.Parameters.AddWithValue("@Адрес", address);
            command.Parameters.AddWithValue("@Контактный_номер", contactNumber);

            command.ExecuteNonQuery();
        }
        static void AddBook(SqlConnection connection, string title, string author, string publisher, int year)
        {
            string query = "INSERT INTO Книги (ID_Книги, Название, Автор, Издательство, Год_издания) " +
                           "VALUES (@ID_Книги, @Название, @Автор, @Издательство, @Год_издания)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Книги", GetNextBookId(connection)); // Получение следующего доступного ID_Книги
            command.Parameters.AddWithValue("@Название", title);
            command.Parameters.AddWithValue("@Автор", author);
            command.Parameters.AddWithValue("@Издательство", publisher);
            command.Parameters.AddWithValue("@Год_издания", year);

            command.ExecuteNonQuery();
        }
        static void AddMest(SqlConnection connection, int bookId, int readerId)
        {
            string query = "INSERT INTO Местонахождения (ID_Местонахождения, ID_Книги, ID_Читателя) " +
                           "VALUES (@ID_Местонахождения, @ID_Книги, @ID_Читателя)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Местонахождения", GetNextMestId(connection));
            command.Parameters.AddWithValue("@ID_Книги", bookId);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }


        //Функции обновления данных читателя
        static void UpdateReaderName(SqlConnection connection, int readerId, string newName)
        {
            string query = "UPDATE Читатели SET Имя = @Новое_имя WHERE ID_Читателя = @ID_Читателя";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новое_имя", newName);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateReaderSurname(SqlConnection connection, int readerId, string newSurname)
        {
            string query = "UPDATE Читатели SET Фамилия = @Новая_фамилия WHERE ID_Читателя = @ID_Читателя";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новая_фамилия", newSurname);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateReaderAddress(SqlConnection connection, int readerId, string newAddress)
        {
            string query = "UPDATE Читатели SET Адрес = @Новый_адрес WHERE ID_Читателя = @ID_Читателя";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новый_адрес", newAddress);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateReaderNumber(SqlConnection connection, int readerId, string newNum)
        {
            string query = "UPDATE Читатели SET Контактный_номер = @Новый_номер WHERE ID_Читателя = @ID_Читателя";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новый_номер", newNum);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }

        //Функции обновления данных книги
        static void UpdateBookName(SqlConnection connection, int readerId, string newNameBook)
        {
            string query = "UPDATE Книги SET Название = @Новое_название WHERE ID_Книги = @ID_Книги";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новое_название", newNameBook);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateBookAvtor(SqlConnection connection, int readerId, string newAvtor)
        {
            string query = "UPDATE Книги SET Автор = @Новый_автор WHERE ID_Книги = @ID_Книги";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новый_автор", newAvtor);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateBookIzdately(SqlConnection connection, int readerId, string newIzdately)
        {
            string query = "UPDATE Книги SET Издательство = @Новый_издатель WHERE ID_Книги = @ID_Книги";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новый_издатель", newIzdately);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }
        static void UpdateBookGod(SqlConnection connection, int readerId, string newGodIzdan)
        {
            string query = "UPDATE Книги SET Год_издания = @Новый_годИздания WHERE ID_Книги = @ID_Книги";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Новый_годИздания", newGodIzdan);
            command.Parameters.AddWithValue("@ID_Читателя", readerId);

            command.ExecuteNonQuery();
        }

        //Функции удаления данных
        static void DeleteMest(SqlConnection connection, int copyId)
        {
            string query = "DELETE FROM Местонахождения WHERE ID_Местонахождения = @ID_Местонахождения";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Местонахождения", copyId);

            command.ExecuteNonQuery();
        }
        static void DeleteBook(SqlConnection connection, int copyId)
        {
            string query = "DELETE FROM Книги WHERE ID_Книги = @ID_Книги";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Книги", copyId);

            command.ExecuteNonQuery();
        }
        static void DeletePerson(SqlConnection connection, int copyId)
        {
            string query = "DELETE FROM Читателя WHERE ID_Читателя = @ID_Читателя";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID_Читателя", copyId);

            command.ExecuteNonQuery();
        }


        //Получение след. Id
        static int GetNextMestId(SqlConnection connection)
        {
            string query = "SELECT MAX(ID_Местонахождения) FROM Местонахождения";

            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();

            if (result != DBNull.Value)
                return Convert.ToInt32(result) + 1;
            else
                return 1;
        }
        static int GetNextReaderId(SqlConnection connection)
        {
            string query = "SELECT MAX(ID_Читателя) FROM Читатели";

            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();

            if (result != DBNull.Value)
                return Convert.ToInt32(result) + 1;
            else
                return 1;
        }
        static int GetNextBookId(SqlConnection connection)
        {
            string query = "SELECT MAX(ID_Книги) FROM Книги";

            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();

            if (result != DBNull.Value)
                return Convert.ToInt32(result) + 1;
            else
                return 1;
        }
    }
}
