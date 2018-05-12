using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Название базы данных: cyberforum
            //Название таблицы: example
            //Количество записей: 3
            //Порт: 5432
            //Пароль: 1
            String connectionString = "Server=localhost;Port=5432;User=postgres;Password=123456;Database=school1;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            Console.WriteLine("Соединение с БД открыто");
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT id_teacher,famil FROM teacher", npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            if (npgSqlDataReader.HasRows)
            {
                Console.WriteLine("Таблица: example");
                Console.WriteLine("id value");
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    Console.WriteLine(dbDataRecord["id_teacher"] + "   " + dbDataRecord["famil"]);
            }
            else
                Console.WriteLine("Запрос не вернул строк");
            Console.ReadKey(true);
        }
    }
}
