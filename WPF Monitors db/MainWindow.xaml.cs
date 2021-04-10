using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using WPF_Monitors_db.Change_table;

namespace WPF_Monitors_db
{
    public partial class MainWindow : Window
    {
        // Работает в x64 архитектуре корректно !
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=monitors_db.mdb");
        public MainWindow()
        {
            InitializeComponent();

        }
        private void GetData(string sql)
        {
            DataTable dt = new DataTable();
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void listTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock comboBoxItem = (TextBlock)comboBox.SelectedItem;
            switch (comboBoxItem.Text)
            {
                // Size не вывожу!
                case "Мониторы":
                    GetData("SELECT Monitors.id_monitors, Monitors.Model, Monitors.Price, Monitors.Display_Resolution_Max, Manufacturer.Brand FROM Manufacturer INNER JOIN Monitors ON Manufacturer.id_manufacturer = Monitors.manufacturer_id;");
                    break;
                case "Производители":
                    GetData("SELECT * FROM Manufacturer;");
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock comboBoxItem = (TextBlock)comboBox.SelectedItem;
            switch (comboBoxItem.Text)
            {
                case "Мониторы":
                    ChangeMonitors changeMonitors = new ChangeMonitors(connection);
                    changeMonitors.Show();
                    break;
                case "Производители":
                    ChangeManufacturer changeManufacturer = new ChangeManufacturer(connection);
                    changeManufacturer.Show();
                    break;
            }
        }
    }
}

