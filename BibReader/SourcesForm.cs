using BibReader.Readers.BibReaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BibReader
{
    public partial class SourcesForm : Form
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Source>));
        public List<Source> Sources { get; set; }
        bool defaultSources;

        public SourcesForm(List<Source> sources, bool defaultSources)
        {
            InitializeComponent();

            if (!(sources is null))
                InitializeLV(sources);

            редактироватьToolStripMenuItem.Enabled = удалитьToolStripMenuItem.Enabled = lvSources.SelectedItems.Count > 0;
            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            this.defaultSources = defaultSources;
            Text = defaultSources ? "Источники по умолчанию" : "Пользовательские источники";
        }

        private void InitializeLV(List<Source> sources)
        {
            foreach (var source in sources)
            {
                var lvi = new ListViewItem(new[]
                {
                    source.Name,
                    source.Pattern,
                    source.FirstTag,
                    source.Features()
                })
                {
                    Tag = source
                };
                lvSources.Items.Add(lvi);
            }
        }

        private List<Source> GetSources()
        {
            List<Source> list = new List<Source>();

            foreach (ListViewItem lvi in lvSources.Items)
                list.Add((Source)lvi.Tag);

            return list;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addSource = new AddSourceForm(null, "");

            if (addSource.ShowDialog() != DialogResult.OK)
                return;

            var newSource = addSource.Source;
            var lvi = new ListViewItem(new[]
            {
                newSource.Name,
                newSource.Pattern,
                newSource.FirstTag,
                newSource.Features()
            })
            {
                Tag = newSource
            };
            lvSources.Items.Add(lvi);

            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = lvSources.SelectedIndices[0];

            var addSource = new AddSourceForm((Source)lvSources.Items[i].Tag, "");

            if (addSource.ShowDialog() != DialogResult.OK)
                return;

            var newSource = addSource.Source;
            //Sources.Add(newSource);
            var lvi = new ListViewItem(new[]
            {
                newSource.Name,
                newSource.Pattern,
                newSource.FirstTag,
                newSource.Features()
            })
            {
                Tag = newSource
            };

            lvSources.Items.RemoveAt(i);
            lvSources.Items.Insert(i, lvi);

            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvSources.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = lvSources.SelectedIndices[0];

            lvSources.Items.RemoveAt(i);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Sources = GetSources();

            string filename = defaultSources ? "defaultSources.xml" : "sources.xml";

            TextWriter textWriter = new StreamWriter(filename);
            xs.Serialize(textWriter, Sources);
            textWriter.Close();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lvSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            редактироватьToolStripMenuItem.Enabled = удалитьToolStripMenuItem.Enabled = lvSources.SelectedItems.Count > 0;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvSources.Items.Clear();

            var openFile = new OpenFileDialog();
            openFile.Filter = "Файл XML (*.xml)|*.xml";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            using (FileStream fs = new FileStream(openFile.FileName, FileMode.Open))
            {
                Sources = (List<Source>)xs.Deserialize(fs);
                InitializeLV(Sources);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sources = GetSources();

            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Файл XML (*.xml)|*.xml";

            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            TextWriter textWriter = new StreamWriter(saveFile.FileName);

            xs.Serialize(textWriter, Sources);

            textWriter.Close();

            MessageBox.Show("Источники успешно сохранены!", "Сохранение");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
