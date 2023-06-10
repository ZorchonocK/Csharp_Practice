using System;
using System.Data;
using System.Data.SQLite;

namespace MuseumDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string databasePath = "museum.db";

            using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                connection.Open();

                // Создание таблиц
                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Сотрудники (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Position TEXT, ExcursionId INTEGER, FOREIGN KEY (ExcursionId) REFERENCES Экскурсии (Id))", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Экскурсии (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Date DATE)", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Экспонаты (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Description TEXT, RoomId INTEGER, FOREIGN KEY (RoomId) REFERENCES Залы (Id))", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Залы (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Description TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                //---------------------------------------------------//



                //Добавление данных в таблицу
                using (var command = new SQLiteCommand("INSERT INTO Сотрудники (Name, Position, ExcursionId) VALUES (@Name, @Position, @ExcursionId)", connection))
                {
                    command.Parameters.AddWithValue("@Name", "John Doe");
                    command.Parameters.AddWithValue("@Position", "Curator");
                    command.Parameters.AddWithValue("@ExcursionId", 1);
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("INSERT INTO Экскурсии (Name, Date) VALUES (@Name, @Date)", connection))
                {
                    command.Parameters.AddWithValue("@Name", "Ancient History");
                    command.Parameters.AddWithValue("@Date", DateTime.Parse("2023-06-15"));
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("INSERT INTO Экспонаты (Name, Description, RoomId) VALUES (@Name, @Description, @RoomId)", connection))
                {
                    command.Parameters.AddWithValue("@Name", "Egyptian Statue");
                    command.Parameters.AddWithValue("@Description", "Ancient statue from Egypt");
                    command.Parameters.AddWithValue("@RoomId", 1);
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("INSERT INTO Залы (Name, Description) VALUES (@Name, @Description)", connection))
                {
                    command.Parameters.AddWithValue("@Name", "Ancient Art");
                    command.Parameters.AddWithValue("@Description", "Exhibit of ancient artworks");
                    command.ExecuteNonQuery();
                }

                //---------------------------------------------------//



                // Вывод содержимого таблиц
                using (var command = new SQLiteCommand("SELECT Сотрудники.Id, Сотрудники.Name, Сотрудники.Position, Экскурсии.Name AS ExcursionName FROM Сотрудники LEFT JOIN Экскурсии ON Сотрудники.ExcursionId = Экскурсии.Id", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Сотрудники:");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string position = reader.GetString(2);
                            string excursionName = reader.IsDBNull(3) ? "No Excursion" : reader.GetString(3);
                            Console.WriteLine($"Id: {id}, Name: {name}, Position: {position}, Excursion: {excursionName}");
                        }
                    }
                }

                using (var command = new SQLiteCommand("SELECT * FROM Экскурсии", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nЭкскурсии:");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            DateTime date = reader.GetDateTime(2);
                            Console.WriteLine($"Id: {id}, Name: {name}, Date: {date}");
                        }
                    }
                }

                using (var command = new SQLiteCommand("SELECT Экспонаты.Id, Экспонаты.Name, Экспонаты.Description, Залы.Name AS RoomName FROM Экспонаты LEFT JOIN Залы ON Экспонаты.RoomId = Залы.Id", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nЭкспонаты:");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.GetString(2);
                            string roomName = reader.IsDBNull(3) ? "No Room" : reader.GetString(3);
                            Console.WriteLine($"Id: {id}, Name: {name}, Description: {description}, Room: {roomName}");
                        }
                    }
                }

                using (var command = new SQLiteCommand("SELECT * FROM Залы", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nЗалы:");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.GetString(2);
                            Console.WriteLine($"Id: {id}, Name: {name}, Description: {description}");
                        }
                    }
                }
                //---------------------------------------------------//
                Console.WriteLine("\nХотите произвести действие?");
                Console.WriteLine("1. Добавление");
                Console.WriteLine("2. Удаление");
                Console.WriteLine("3. Нет");


                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите имя сотрудника");
                        string newname = Console.ReadLine();
                        Console.WriteLine("Введите роль сотрудника");
                        string newposition = Console.ReadLine();

                        // Добавление элемента в таблицу "Сотрудники"
                        using (var command = new SQLiteCommand("INSERT INTO Сотрудники (Name, Position, ExcursionId) VALUES (@Name, @Position, @ExcursionId)", connection))
                        {
                            command.Parameters.AddWithValue("@Name", newname);
                            command.Parameters.AddWithValue("@Position", newposition);
                            command.Parameters.AddWithValue("@ExcursionId", 1); // Идентификатор связанной экскурсии
                            command.ExecuteNonQuery();
                        }

                        // Вывод содержимого таблиц
                        using (var command = new SQLiteCommand("SELECT Сотрудники.Id, Сотрудники.Name, Сотрудники.Position, Экскурсии.Name AS ExcursionName FROM Сотрудники LEFT JOIN Экскурсии ON Сотрудники.ExcursionId = Экскурсии.Id", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                Console.WriteLine("Сотрудники:");
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    string position = reader.GetString(2);
                                    string excursionName = reader.IsDBNull(3) ? "No Excursion" : reader.GetString(3);
                                    Console.WriteLine($"Id: {id}, Name: {name}, Position: {position}, Excursion: {excursionName}");
                                }
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите Id сотрудника");
                        int num = Convert.ToInt16(Console.ReadLine());

                        // Удаление элемента из таблицы "Сотрудники"
                        using (var command = new SQLiteCommand("DELETE FROM Сотрудники WHERE Id = @Id", connection))
                        {
                            command.Parameters.AddWithValue("@Id", num);
                            command.ExecuteNonQuery();
                        }

                        // Вывод содержимого таблиц
                        using (var command = new SQLiteCommand("SELECT Сотрудники.Id, Сотрудники.Name, Сотрудники.Position, Экскурсии.Name AS ExcursionName FROM Сотрудники LEFT JOIN Экскурсии ON Сотрудники.ExcursionId = Экскурсии.Id", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                Console.WriteLine("Сотрудники:");
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    string position = reader.GetString(2);
                                    string excursionName = reader.IsDBNull(3) ? "No Excursion" : reader.GetString(3);
                                    Console.WriteLine($"Id: {id}, Name: {name}, Position: {position}, Excursion: {excursionName}");
                                }
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Досвидания");
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор.");
                        break;
                }
                

                

            }

            Console.WriteLine("\nНажмите любой кнопку для выхода...");
            Console.ReadKey();
        }
    }
}
