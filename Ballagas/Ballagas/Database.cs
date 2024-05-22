using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ballagas
{
    internal class Database
    {
        public MySqlConnection getConnection()
        {
            try
            {
                const string server = "localhost";
                const string ab = "graduation";
                const string user = "root";
                const string pass = "";
                string connString = $"server = {server}; " +
                    $"database = {ab}; uid={user}; " +
                    $"pw = {pass} ";


                MySqlConnection conn = new MySqlConnection(connString);

                return conn;
            } catch (Exception ex)
            {
                MessageBox.Show("[!] Error: " + ex.Message);
                return null;
            }
        }
    }
}
