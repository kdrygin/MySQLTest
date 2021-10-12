// MySQL Connection Test
// https://dev.mysql.com/doc/connector-net/en/connector-net-programming-getschema.html
//

using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string connStr = "server=192.168.0.13;user=dky;database=test;port=3306;password=123";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                //DataTable table = conn.GetSchema("MetaDataCollections");
                DataTable table = conn.GetSchema("Tables");

                foreach (System.Data.DataRow row in table.Rows)
                {
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                    }
                    Console.WriteLine("============================");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Done.");
        }
    }
}
