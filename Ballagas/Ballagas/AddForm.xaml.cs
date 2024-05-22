using MySql.Data.MySqlClient;
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
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {

        private List<Customer> customersList;
        private List<Order> ordersList;
        private List<Order> updateDataGrid() {
            Tools tools = new Tools();

            return tools.listData(ListData);
        }

        private List<Customer> updateComboBox() {
            Tools tools = new Tools();

            return tools.listCombo(customersCombo);
        }

        public AddForm()
        {
            InitializeComponent();

            ordersList = updateDataGrid();
            customersList = updateComboBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) {
            try {
                try {
                    int piecesBoxText = Convert.ToInt32(piecesBox.Text);
                } catch (Exception ex) {
                    throw new Exception("Csak szám lehet a darabszám!");
                }

                Order order = new Order(
                    schoolName: schoolNameBox.Text,
                    className: classNameBox.Text,
                    classYears: classYearsBox.Text,
                    message: messageBox.Text,
                    pieces: Convert.ToInt32(piecesBox.Text)
                );

                if (customersCombo.SelectedIndex == -1) throw new Exception("Nincs kiválasztva vásárló!");

                Customer selectedCustomer = customersList[customersCombo.SelectedIndex];

                Database db = new Database();

                MySqlConnection conn = db.getConnection();
                conn.Open();

                string ordersSql = $"INSERT INTO `orders`(`schoolName`, `className`, `classYears`, `message`, `status`, `pieces`, `customerId`) VALUES ('{order.SchoolName}','{order.ClassName}','{order.ClassYears}','{order.Message}', 'Függőben', {order.Pieces}, {selectedCustomer.Id});";

                MySqlCommand cmd = new MySqlCommand(ordersSql, conn);
                cmd.ExecuteReader();

                conn.Close();

                MessageBox.Show("Rögzítés sikeres!");

                updateDataGrid();

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
