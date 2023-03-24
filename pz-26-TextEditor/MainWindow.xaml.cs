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

namespace pz_26_TextEditor
{
    public partial class MainWindow : Window
    {
        private string filename;
        string path = @"C:\Users\Александр\Source\Repos\eeisler\Sharp_2pk2_AbdulllinaER\pz-26-TextEditor\data\";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void newMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateFileWindow createFileWindow = new CreateFileWindow();

            try
            {
                if (createFileWindow.ShowDialog() == true)
                {
                    filename = createFileWindow.FileName;
                    FileStream file = new FileStream(path + filename + ".txt", FileMode.CreateNew);
                }
            }
            catch (System.IO.IOException)
            {
                Error error = new Error();
                error.ShowDialog();
            }
        }

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.FileName = "Document"; // Default file name
            fd.DefaultExt = ".txt"; // Default file extension
            fd.Filter = "Text documents (.txt)|*.txt";// Filter files by extension
            if (fd.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(fd.FileName, FileMode.Open);
                TextRange range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Text);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = "Document"; // Default file name
            fd.DefaultExt = ".txt"; // Default file extension
            fd.Filter = "Text documents (.txt)|*.txt";// Filter files by extension
            if (fd.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(fd.FileName, FileMode.Create);
                TextRange range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Text);
            }
        }
        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
