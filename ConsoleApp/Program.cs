using System;
using Npgsql;
using ConsoleApp;

namespace ConsoleApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Practice2024";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Menu.showMenu();
            using (var connection = new NpgsqlConnection(ConnectionDataBase.stringConnection))
            {
                connection.Open();

                var flag = true;

                while (flag) 
                {
                    Console.Write("Ваш выбор: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice) 
                    { 
                        case 1: Menu.showUser(connection); break;
                        case 2: Menu.showRole(connection); break;
                        case 3: Menu.showUserHisRole(connection); break;
                        case 4: Menu.showCountRole(connection); break;
                        case 5: flag = !flag; Console.WriteLine("До свидания!"); break;
                        default: Console.WriteLine("Нет такой функции!\n"); break;
                    }

                }

                connection.Close();
            }
        }
    }
}