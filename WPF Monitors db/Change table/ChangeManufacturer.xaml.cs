using System;
using System.Data.OleDb;
using System.Windows;

namespace WPF_Monitors_db.Change_table
{
    /// <summary>
    /// Логика взаимодействия для ChangeManufacturer.xaml
    /// </summary>
    public partial class ChangeManufacturer : Window
    {
        private OleDbConnection connection;
        private string sql;
        private string brand;
        private int id;
        public ChangeManufacturer(OleDbConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add
            brand = brandInput.Text;
            sql = "INSERT INTO Manufacturer (Brand) VALUES ('" + brand + "')";
            MakeQuery(sql);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Change
            brand = brandInput.Text;
            id = Convert.ToInt32(idInput.Text);
            sql = "UPDATE Manufacturer SET Brand = '" + brand + "' WHERE id_manufacturer = " + id + ";";
            MakeQuery(sql);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Delete
            id = Convert.ToInt32(idInput.Text);
            sql = "DELETE FROM Manufacturer WHERE id_manufacturer = " + id + ";";
            MakeQuery(sql);
        }
        private void MakeQuery(string query)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Выполнено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
