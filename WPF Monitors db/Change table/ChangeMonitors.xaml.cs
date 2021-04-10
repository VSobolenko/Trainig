using System;
using System.Data.OleDb;
using System.Windows;


namespace WPF_Monitors_db.Change_table
{
    /// <summary>
    /// Логика взаимодействия для ChangeMonitors.xaml
    /// </summary>
    public partial class ChangeMonitors : Window
    {
        private OleDbConnection connection;
        private string sql;

        private int idMonitors;
        private string model;
        private int price;
        private string size;
        private string resolution;
        private int idManufacturer;

        public ChangeMonitors(OleDbConnection oleDbConnection)
        {
            connection = oleDbConnection;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add
            model = modelInput.Text;
            price = Convert.ToInt32(priceInput.Text);
            size = sizeInput.Text;
            resolution = resolutionInput.Text;
            idManufacturer = Convert.ToInt32(idManufacturerInput.Text);
            sql = "INSERT INTO Monitors (Model, Price, Display_Resolution_Max, manufacturer_id) " +
                "VALUES ('" + model + "', " + price + ", '" + resolution + "', " + idManufacturer + ");";
            MakeQuery(sql);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Change
            model = modelInput.Text;
            price = Convert.ToInt32(priceInput.Text);
            size = sizeInput.Text;
            resolution = resolutionInput.Text;
            idManufacturer = Convert.ToInt32(idManufacturerInput.Text);
            idMonitors = Convert.ToInt32(idMonitorsInput.Text);
            sql = "UPDATE Monitors SET " +
                "Model = '" + model + "', " +
                "Price = " + price + ", " +
                //"Size = '" + size + "', " +
                "Display_Resolution_Max = '" + resolution +"', " +
                "manufacturer_id = " + idManufacturer + " " + 
                "WHERE id_monitors = " + idMonitors + ";";
            MakeQuery(sql);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Delete
            idMonitors = Convert.ToInt32(idMonitorsInput.Text);
            sql = "DELETE FROM Monitors WHERE id_monitors = " + idMonitors + ";";
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
