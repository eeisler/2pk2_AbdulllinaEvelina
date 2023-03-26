using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.IO.Pipes;

namespace pz_26_TextEditor
{
    static class FileFunctional
    {
        internal static void CreateFile(string path, string filename) 
        {
            FileStream file = new FileStream(path + filename + ".txt", FileMode.CreateNew);
        }
        internal static void SaveFile(string path, string currentfilename, System.Windows.Controls.RichTextBox RTB)
        {
            using (FileStream fileStream = new FileStream(currentfilename, FileMode.Append))
            {
                TextRange range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Text);
            }
        }
        internal static void OpenFile(string path, string currentfilename, System.Windows.Controls.RichTextBox RTB)
        {
            using (FileStream fileStream = new FileStream(currentfilename, FileMode.Open))
            {
                TextRange range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Text);
            }
        }
        internal static void DeleteFile(string path, string currentfilename)
        {
            File.Delete(currentfilename);
        }
    }
}
