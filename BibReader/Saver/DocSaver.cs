using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Saver
{
    class DocSaver
    {
        public static void Save(RichTextBox richTextBox)
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                saveFile.Filter = "Файлы doc|*.doc";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    richTextBox.SaveFile(filePath);
                    MessageBox.Show("Файл сохранен!");
                }
            }
            
        }
    }
}
