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
        public string currentfilename;
        string path = @"C:\Users\Александр\Source\Repos\eeisler\Sharp_2pk2_AbdulllinaER\pz-26-TextEditor\data\";
        public MainWindow()
        {
            InitializeComponent();
            ListFunction();
        }
        
        private void newMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateFileWindow createFileWindow = new CreateFileWindow();

            try
            {
                if (createFileWindow.ShowDialog() == true)
                {
                    filename = createFileWindow.FileName;
                    FileFunctional.CreateFile(path, filename);
                    ListFunction();
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
            RTB.Document.Blocks.Clear();
            FileFunctional.OpenFile(path, currentfilename, RTB);
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Saved saved = new Saved();
            FileFunctional.SaveFile(path, currentfilename, RTB);
            saved.ShowDialog();
        }
        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RTB.Document.Blocks.Clear();
            FileFunctional.DeleteFile(currentfilename);
            ListFunction();
        }
        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        internal void ListFunction()
        {
            var dir = new DirectoryInfo("C:\\Users\\Александр\\Source\\Repos\\eeisler\\Sharp_2pk2_AbdulllinaER\\pz-26-TextEditor\\data\\");
            FileInfo[] files = dir.GetFiles("*.txt");
            List.ItemsSource = files;
            List.DisplayMemberPath = "Name";
        }
        internal void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RTB.Document.Blocks.Clear();

            if (List.SelectedItem != null)
            {
                currentfilename = List.SelectedItem.ToString();
            }
        }

        private void Italics_Click(object sender, RoutedEventArgs e)
        {
            if (RTB.Selection != null)
            {
                RTB.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else
                RTB.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, null);
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            if (RTB.Selection != null)
            {
                RTB.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
                RTB.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, null);
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            if (RTB.Selection != null)
            {
                RTB.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
                RTB.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
        }
    }
}
