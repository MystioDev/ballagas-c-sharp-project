using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ballagas
{
    /// <summary>
    /// Interaction logic for DeleteForm.xaml
    /// </summary>
    public partial class DeleteForm : Window
    {

        private List<Order> ordersList;
        private List<Order> updateDataGrid() {
            Tools tools = new Tools();

            return tools.listData(ListData);
        }

        public DeleteForm()
        {
            InitializeComponent();

            ordersList = updateDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            conn.Open();

            Order orderSelected = ListData.SelectedItem as Order;

            string ordersSql = $"DELETE FROM `orders` WHERE id = {orderSelected.Id}";

            MySqlCommand cmd = new MySqlCommand(ordersSql, conn);
            cmd.ExecuteReader();

            conn.Close();

            MessageBox.Show("Rögzítés sikeres!");

            updateDataGrid();
        }

        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ListData.SelectedIndex == -1) return;

            try {
                Order order = ListData.SelectedItem as Order;

                labelCurrentStatus.Content = $"Kiválasztott elem státusza: {order.Status}";
                labelCurrentPieces.Content = $"Kiválasztott elem darabszáma: {order.Pieces}";
                labelCurrentSchoolName.Content = $"Kiválasztott elem iskolája: {order.SchoolName}";
                labelCurrentClassName.Content = $"Kiválasztott elem osztálya: {order.ClassName}";
            }
            catch (Exception ignored) {
                labelCurrentStatus.Content = $"Kiválasztott elem státusza: ---";
                labelCurrentPieces.Content = $"Kiválasztott elem darabszáma: ---";
                labelCurrentSchoolName.Content = $"Kiválasztott elem iskolája: ---";
                labelCurrentClassName.Content = $"Kiválasztott elem osztálya: ---";
            }
        }
    }
}
