using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Saver
{
    class ImageSaver
    {
        public static void Save(Image image)
        {
            using (FileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "bmp(*.bmp) | *.bmp | jpeg(*.jpeg) | *.jpeg | png(*.png) | *.png | tiff(*.tiff) | *.tiff";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    image.Save(fileDialog.FileName);
            }
        }
    }
}
