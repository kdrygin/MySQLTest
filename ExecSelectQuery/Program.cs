// MySQL Select Query Test
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

                string sql = "SELECT * FROM authors ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    Console.WriteLine($"{res[1]} {res[2]} {res[3]}");
                }
                res.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}