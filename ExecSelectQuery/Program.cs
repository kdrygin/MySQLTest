// MySQL Select Query Test
// https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-sql-command.html

using System;
using System.Data;
using System.Configuration;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLTest
{
    class Program
    {
        public static void Main()
        {
            // Connection string format
            // "server=SERVER_IP_ADDRESS;user=USER;database=SCHEMA;port=3306;password=USER_PASSWORD";

            string connStr = ConfigurationManager.AppSettings["DBConnectionString"].ToString();
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