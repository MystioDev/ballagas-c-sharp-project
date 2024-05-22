using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ballagas
{
    internal class Tools
    {
        public List<Order> listData(DataGrid ListGrid)
        {
            Database db = new Database();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            string sql = "SELECT `schoolName`, `className`, `classYears`, `message`, `status`, `pieces`, `customerId`, `id` FROM `orders` ORDER BY id;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<Order> temp = new List<Order>();

            while (reader.Read()) {
                temp.Add(new Order(
                    schoolName: reader.GetString(0), 
                    className: reader.GetString(1), 
                    classYears: reader.GetString(2), 
                    message: reader.GetString(3), 
                    status: reader.GetString(4), 
                    pieces: reader.GetInt32(5),
                    customerId: reader.GetInt32(6), 
                    id: reader.GetInt32(7)
                ));
            }


            ListGrid.ItemsSource = temp;

            conn.Close();

            return temp;
        }

        public List<Customer> listCombo(ComboBox combo) {
            Database db = new Database();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            string sql = "SELECT `name`, `phone`, `id` FROM `customers` ORDER BY id;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<Customer> temp = new List<Customer>();

            while (reader.Read()) {
                temp.Add(new Customer(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetInt32(2)
                ));
            }

            List<string> toCombo = new List<string>();

            foreach (Customer item in temp) {
                toCombo.Add(item.Name);
            }

            combo.ItemsSource = toCombo;

            return temp;
        }
    }
}
