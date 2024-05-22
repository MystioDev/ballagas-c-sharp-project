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
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {

        private List<Order> ordersList;
        private List<Order> updateDataGrid() {
            Tools tools = new Tools();

            return tools.listData(ListData);
        }

        private void uploadStatucComboList() {
            List<string> temp = new List<string>();

            temp.Add("Beérkezett");
            temp.Add("Függőben");
            temp.Add("Kézbesítve");

            statusCombo.ItemsSource = temp;
        }

        public EditForm()
        {
            InitializeComponent();

            ordersList = updateDataGrid();

            uploadStatucComboList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) {
            try {
                try {
                    int piecesBoxText = Convert.ToInt32(piecesBox.Text);
                }
                catch (Exception ex) {
                    throw new Exception("Csak szám lehet a darabszám!");
                }

                int pieces = Convert.ToInt32(piecesBox.Text);

                if (statusCombo.SelectedIndex == -1) throw new Exception("Nincs kiválasztva vásárló!");


                Database db = new Database();

                MySqlConnection conn = db.getConnection();
                conn.Open();

                Order orderSelected = ListData.SelectedItem as Order;

                string ordersSql = $"UPDATE `orders` SET `status`='{statusCombo.SelectedItem}', `pieces`={pieces} WHERE id = {orderSelected.Id}";

                MySqlCommand cmd = new MySqlCommand(ordersSql, conn);
                cmd.ExecuteReader();

                conn.Close();

                MessageBox.Show("Rögzítés sikeres!");

                updateDataGrid();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ListData.SelectedIndex == -1) return;


            try {
                Order order = ListData.SelectedItem as Order;

                labelCurrentStatus.Content = $"Kiválasztott elem státusza: {order.Status}";
                labelCurrentPieces.Content = $"Kiválasztott elem darabszáma: {order.Pieces}";
            } catch (Exception ignored) {
                labelCurrentStatus.Content = $"Kiválasztott elem státusza: ---";
                labelCurrentPieces.Content = $"Kiválasztott elem darabszáma: ---";
            }
        }
    }
}
