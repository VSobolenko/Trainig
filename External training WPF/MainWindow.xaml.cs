using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace External_training_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenFile();
        }

        public void OpenFile(string path = @"E:\Work\EPAM Training\test file\new text for read.txt")
        {
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            outputListBox.ItemsSource = lines;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog newTextFile = new OpenFileDialog();
            newTextFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            newTextFile.InitialDirectory = @"E:\Work\EPAM Training\test file\new text for read.txt";
            if (newTextFile.ShowDialog() == true)
                OpenFile(newTextFile.FileName);
        }
    }
}
