using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballagas
{
    internal class Database
    {
        private MySqlConnection getConnection()
        {
            try
            {
                string connStr = "server=localhost;user=root;database=graduation;port=3306;password=";
                MySqlConnection conn = new MySqlConnection(connStr);
            } catch (Exception ex)
            {
                throw new Exception("[!] Error: " + ex.Message);
            }
        }
    }
}
