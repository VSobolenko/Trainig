using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;

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

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog newTextFile = new OpenFileDialog();

            newTextFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            newTextFile.InitialDirectory = @"E:\Work\EPAM Training\test file\new text for read.txt";

            if (newTextFile.ShowDialog() == true)
            {
                TextRange doc = new TextRange(outputRichTextBox.Document.ContentStart, outputRichTextBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(newTextFile.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(newTextFile.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(newTextFile.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
                doc.ApplyPropertyValue(Paragraph.MarginProperty, new Thickness(0));
                doc.ApplyPropertyValue(Paragraph.FontSizeProperty, 20D);
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(outputRichTextBox.Document.ContentStart, outputRichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }
    }
}
