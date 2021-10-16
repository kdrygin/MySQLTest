// MySQL Insert Query Test
// https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-sql-command.html

using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLTest
{
    class Program
    {
        public static void Main()
        {
            string connStr = "server=10.0.4.94;user=dky;database=test;port=3306;password=1qaz2wsx";
            //string connStr = "server=192.168.0.13;user=dky;database=test;port=3306;password=123";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "INSERT INTO `authors` (`id`, `first_name`, `last_name`, `email`, `birthdate`, `added`) " +
                             $"VALUES (0, 'Test', 'Test', '{RandomString()}@test.org', '2000-01-01', '2020-01-01 00:00:00');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        static string RandomString()
        {
            //https://stackoverflow.com/questions/730268/unique-random-string-generation
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }
    }
}
