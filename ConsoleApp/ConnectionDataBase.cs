using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ConnectionDataBase
    {
        //Подключение
        public static string stringConnection = "Host=localhost; Port=5432; Username=postgres; Password=12341; Database=practice2024";
        private readonly NpgsqlConnection _connection = new(stringConnection);
    }

    public class Repository
    {
        public static void showUser(NpgsqlConnection connection)
        {
            var sql = "SELECT * FROM \"USER\";";
            var users = connection.Query<USER>(sql);
            foreach (var user in users)
            {
                Console.WriteLine($"ИН: {user.id_user}, Имя: {user.name_user}");
            }
            Console.WriteLine();
        }
        public static void showRole(NpgsqlConnection connection)
        {
            var sql = "SELECT * FROM \"ROLE\";";
            var roles = connection.Query<ROLE>(sql);
            foreach (var role in roles)
            {
                Console.WriteLine($"ИН: {role.id_role}, Роль: {role.name_role}");
            }
            Console.WriteLine();
        }
        public static void showUserHisRole(NpgsqlConnection connection)
        {
            var sql = "select \"USER\".name_user, \"ROLE\".name_role " +
                      "from \"USER\" " +
                      "inner join \"USER_ROLE\" on \"USER\".id_user = \"USER_ROLE\".id_user " +
                      "inner join \"ROLE\" on \"ROLE\".id_role = \"USER_ROLE\".id_role;";
            var roles = connection.Query(sql);
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.name_user} \t-\t {role.name_role}");
            }
            Console.WriteLine();
        }
        public static void showCountRole(NpgsqlConnection connection)
        {
            var sql = "select \"ROLE\".name_role, count(\"USER_ROLE\".id_role )" +
                      "from \"ROLE\" " +
                      "left join \"USER_ROLE\" on \"USER_ROLE\".id_role = \"ROLE\".id_role " +
                      "group by \"ROLE\".id_role; ";
            var roles = connection.Query(sql);
            foreach (var role in roles)
            {
                if (role.count == 1)
                    Console.WriteLine($"Роль <{role.name_role}> имеет {role.count} Пользователя");
                else
                    Console.WriteLine($"Роль <{role.name_role}> имеет {role.count} Пользователей");
            }
            Console.WriteLine();
        }

    }

    public class Menu: Repository
    {
        public static void MenuBorder(string name)
        {
            Console.WriteLine(name);
            Console.WriteLine("+----------------+");
        }
        public static new void showUser(NpgsqlConnection connection)
        {
            MenuBorder("Пользователь");
            Repository.showUser(connection);
        }
        public static new void showRole(NpgsqlConnection connection)
        {
            MenuBorder("Роль");
            Repository.showRole(connection);
        }
        public static new void showUserHisRole(NpgsqlConnection connection)
        {
            MenuBorder("Пользователь и его роль");
            Repository.showUserHisRole(connection);
        }
        public static new void showCountRole(NpgsqlConnection connection)
        {
            MenuBorder("Роль и ее количество Пользователей");
            Repository.showCountRole(connection);
        }
        public static void showMenu()
        {
            Console.WriteLine("Функционал консольного приложения:");
            Console.WriteLine("Нажмите <1> для демонтрации всех Пользователей");
            Console.WriteLine("Нажмите <2> для демонтрации всех Ролей");
            Console.WriteLine("Нажмите <3> для демонтрации Пользователей и соответствующих им Ролей");
            Console.WriteLine("Нажмите <4> для демонтрации количества участников каждой из Ролей");
            Console.WriteLine("Нажмите <5> для завершения работы");
        }
    }

    public class USER
    {
        public int id_user { get; set; }
        public string name_user { get; set; }
    }
    public class ROLE
    {
        public int id_role { get; set; }
        public string name_role { get; set; }
    }
}
