using BibReader.Analysis;
using OpenNLP.Tools.Parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BibReader
{
    public partial class ContextAnalysis : Form
    {
        private bool isLoadConcepts = false;
        private bool isLoadThesaurus = false;
        private bool isLoadNames = false;
        private bool isLoadOrganizations = false;

        private string stopword;
        private bool isValue = false;

        private Random rand;

        private Circle circle = new Circle();
        private Graphics gr;
        private Bitmap graphics;

        private int maxValue;
        private double averageValue;

        private Dictionary<PointF, int> circles;

        public string Info
        {
            set => tbContext.Text = value;
            get => tbContext.Text;
        }
        public object Stopworlds { get; private set; }

        public ContextAnalysis()
        {
            InitializeComponent();
            rand = new Random();
            circles = new Dictionary<PointF, int>();
        }

        private int[] orderByKeyValue(Dictionary<string, DataTag> analitics)
        {
            averageValue = TextAnalysis.getAverageValueConcepts();
            return analitics
                .OrderByDescending(i => i.Value.count)
                .Take(10)
                .Select(item => item.Value.count)
                .ToArray();
        }

        private string[] orderByKeyKey(Dictionary<string, DataTag> analitic)
        {
            averageValue = TextAnalysis.getAverageValueConcepts();
            return analitic
                .OrderByDescending(i => i.Value.count)
                .Take(10)
                .Select(item => item.Key)
                .ToArray();
        }

        private void LoadSynopsis()
        {
            lvSynopsis.Clear();
            lvSynopsis.Columns.Add("Понятие");
            lvSynopsis.Columns[0].Width = lvSynopsis.Width;

            if (TextAnalysis.Concepts.Count > 0)
            {
                lvSynopsis.Items.AddRange(TextAnalysis.Concepts
                    .OrderByDescending(i => i.Value.count)
                    .Take(10)
                    .Select(item =>
                    {
                        ListViewItem itm = new ListViewItem(
                            new string[] {
                            item.Key,
                         });
                        return itm;
                    }).ToArray());

                string[] xValues = orderByKeyKey(TextAnalysis.Concepts);
                int[] yValues = orderByKeyValue(TextAnalysis.Concepts);

                OpenDiagram(chSynopsis, xValues, yValues, "Встречаемость");
            }
        }

        private void LoadThesaurus()
        {
            lvThesaurus.Clear();

            lvThesaurus.Columns.Add("Понятие");
            lvThesaurus.Columns.Add("Часть речи");
            lvThesaurus.Columns[0].Width = lvThesaurus.Width / 2;
            lvThesaurus.Columns[1].Width = lvThesaurus.Width / 2;

            if (TextAnalysis.Concepts.Count > 0)
            {
                lvThesaurus.Items.AddRange(TextAnalysis.Concepts
                    .OrderByDescending(i => i.Value.count)
                    .Where(i => i.Value.count > averageValue)
                    .Select(item =>
                        new ListViewItem(
                            new string[] {
                        item.Key,
                        item.Value.count.ToString(),
                        //TextAnalysis.POS[item.Key]
                     })).ToArray());
            }
            isLoadThesaurus = true;
        }

        private double GetDistancePoints(PointF pos1, PointF pos2)
        {
            return (pos1.X - pos2.X) * (pos1.X - pos2.X) + (pos1.Y - pos2.Y) * (pos1.Y - pos2.Y);
        }

        private bool IsPoint(PointF pos, int radius)
        {
            foreach (KeyValuePair<PointF, int> circle in circles)
            {
                int maxRadius;
                PointF pointMaxCircle;
                PointF pointMinCircle;

                if (circle.Value > radius) {
                    maxRadius = circle.Value;
                    pointMaxCircle = circle.Key;
                    pointMinCircle = pos;
                }
                else
                {
                    maxRadius = radius;
                    pointMaxCircle = pos;
                    pointMinCircle = circle.Key;
                }

                if (GetDistancePoints(pointMinCircle, pointMaxCircle) < maxRadius * maxRadius)
                    return false;
            }
            return true;
        }

        private PointF GetPosition(int radius)
        {
            int x;
            int y;
            PointF pos;

            do
            {
                x = rand.Next(radius, pGraphic.Width - radius);
                y = rand.Next(radius, pGraphic.Height - radius);
                pos = new PointF(x, y);
            } while (!IsPoint(pos, radius));

            circles.Add(pos, radius);
            return pos;
        }

        private void LoadGraphics()
        {
            graphics = new Bitmap(pGraphic.Width, pGraphic.Height);
            gr = Graphics.FromImage(graphics);
            gr.Clear(Color.White);

            getGraphics();
        }

        private void LoadNames()
        {
            lvPerson.Clear();
            lvPerson.Columns.Add("Персона");
            lvPerson.Columns[0].Width = lvPerson.Width;

            if (TextAnalysis.Persons.Count > 0)
            {
                lvPerson.Items.AddRange(
                    TextAnalysis.Persons.Select(item =>
                        new ListViewItem(new string[] { item })
                    ).ToArray()
                );
            }
            isLoadNames = true;
        }

        private void LoadOrganizations()
        {
            lvOrganization.Clear();
            lvOrganization.Columns.Add("Организация");
            lvOrganization.Columns[0].Width = lvOrganization.Width;

            if (TextAnalysis.Organizations.Count > 0)
            {
                lvOrganization.Items.AddRange(
                    TextAnalysis.Organizations.Select(item =>
                        new ListViewItem(new string[] { item })
                    ).ToArray()
                );
            }
            isLoadOrganizations = true;
        }


        private void LoadConcepts()
        {
            lvConcepts.Clear();
            if (TextAnalysis.Concepts.Count > 0)
            {
                lvConcepts.Columns.Add("Понятие");
                lvConcepts.Columns.Add("Кол-во");
                lvConcepts.Columns.Add("Отношение");
                lvConcepts.Columns.Add("");
                lvConcepts.Columns[0].Width = lvConcepts.Width / 10 * 3;
                lvConcepts.Columns[1].Width = lvConcepts.Width / 10;
                lvConcepts.Columns[2].Width = lvConcepts.Width / 10 * 2;
                lvConcepts.Columns[3].Width = lvConcepts.Width / 10 * 4;

                int count = TextAnalysis.Concepts.Count;
                lvConcepts.Items.AddRange(TextAnalysis.Concepts
                    .OrderByDescending(i => i.Value.count)
                    .Where(i => i.Value.count > averageValue)
                    .Select(item =>
                    {
                        ListViewItem itm = new ListViewItem(
                            new string[] {
                        item.Key,
                        item.Value.count.ToString(),
                        Math.Round((double)item.Value.count / count * 100, 2).ToString() + "%"
                            });
                        itm.Tag = item.Value.count / count * 100;
                        return itm;
                    }).ToArray());
            }
            isLoadConcepts = true;
        }

        private void OpenDiagram(Chart chart, string[] xValues, int[] yValues, string seriesName)
        {
            chart.Series.Clear();

            chart.BackColor = Color.White;

            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineColor = Color.White;

            chart.Series.Add(new Series(seriesName)
            {
                ChartType = SeriesChartType.Bar
            });

            Array.Sort(yValues);
            chart.Series[seriesName].Points.DataBindXY(xValues, yValues);
            chart.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart.Series[seriesName].IsValueShownAsLabel = true;
        }

        private void ContextAnalysis_Load(object sender, EventArgs e)
        {
            LoadSynopsis();
        }

        private void ContextAnalysis_Shown(object sender, EventArgs e)
        {
            LoadGraphics();
        }

        private void ContextAnalysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            gr.Dispose();
        }

        private void lvSynopsis_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (e.ColumnIndex == 2)
                {
                    e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        e.Bounds,
                        Color.Orange,
                        Color.Maroon,
                        LinearGradientMode.Horizontal
                        )
                    )
                    {
                        e.Graphics.FillRectangle(
                            brush, 
                            e.SubItem.Bounds.X,
                            e.SubItem.Bounds.Y - e.Bounds.Height,
                            float.Parse(e.Item.Text.Trim('%')),
                            e.Bounds.Height
                            );

                        Pen pen = new Pen(Color.White);
                        e.Graphics.DrawRectangle(pen, e.Bounds);
                    }
                    e.Graphics.DrawString(e.SubItem.Text, lvSynopsis.Font, Brushes.Black, e.Bounds, sf);
                }
                else
                {
                    e.Graphics.DrawString(e.SubItem.Text, lvSynopsis.Font, Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        private void lvConcepts_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (e.ColumnIndex == 3)
                {
                    e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        e.Bounds,
                        Color.Orange,
                        Color.Maroon,
                        LinearGradientMode.Horizontal
                        )
                    )
                    {
                        e.Graphics.FillRectangle(
                            brush, 
                            e.SubItem.Bounds.X,
                            e.SubItem.Bounds.Y - e.Bounds.Height,
                            float.Parse(e.Item.Text.Trim('%')),
                            e.Bounds.Height
                            );

                        Pen pen = new Pen(Color.White);
                        e.Graphics.DrawRectangle(pen, e.Bounds);
                    }
                    e.Graphics.DrawString(e.SubItem.Text, lvConcepts.Font, Brushes.Black, e.Bounds, sf);
                }
                else
                {
                    e.Graphics.DrawString(e.SubItem.Text, lvConcepts.Font, Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        private void lvSynopsis_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
               
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                    new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        private void lvConcepts_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {

                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                    new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        private void saveDiagram()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "png files (*.png)|*.png|all files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               graphics.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void btSaveDiagram_Click(object sender, EventArgs e)
        {
            PictureBox pb = pGraphic;
            if (pb != null)
            {
                saveDiagram();
            }
        }

        private void InitializeStopWords()
        {
            lvStopwords.Clear();

            lvStopwords.Columns.Add("Стоп-слово");
            lvStopwords.Columns[0].Width = lvStopwords.Width - 5;

            if (Stopwords.userStopwords.Count < 1)
            {
                return;
            }

            foreach (string word in Stopwords.userStopwords)
            {
                lvStopwords.Items.Add(word);
            }
        }

        private void setParameters(TextBox tb, ref bool parametr)
        {
            if (tb.Text.Length > 0)
            {
                parametr = true;
            }
            else
            {
                parametr = false;
            }
        }


        private void isButtonEnable(Button button, bool isValue)
        {
            if (isValue)
            {
                button.Enabled = true;
            }
            else
            {
                button.Enabled = false;
            }
        }

        private void btAddStopword_Click(object sender, EventArgs e)
        {
            if (!Stopwords.userStopwords.Contains(tbValue.Text))
            {
                Stopwords.userStopwords.Add(tbValue.Text);
                tbValue.Text = "";
                InitializeStopWords();
            }
            else
            {
                MessageBox.Show("Такое значение уже существует. Назовите, пожалуйста, дугое слово", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbValue.SelectAll();
                tbValue.Focus();
            }
            isButtonEnable(btReAnalysis,  Stopwords.userStopwords.Count > 0);
        }

        private void btDeleteStopword_Click(object sender, EventArgs e)
        {
            Stopwords.userStopwords.Remove(stopword);
            btDelete.Enabled = false;
            InitializeStopWords();
            isButtonEnable(btReAnalysis, Stopwords.userStopwords.Count > 0);
        }

        private void lvStopwords_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedStopwords = this.lvStopwords.SelectedItems;
            if (selectedStopwords.Count < 1)
            {
                btDelete.Enabled = false;
            }
            else
            {
                foreach (ListViewItem item in selectedStopwords)
                {
                    stopword = item.Text;
                    btDelete.Enabled = true;
                }
            }
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            setParameters(tbValue, ref isValue);
            isButtonEnable(btAdd, isValue);
        }

        private void getGraphics()
        {
            int count = TextAnalysis.Concepts.Count;

            if (count > 0)
            {
                maxValue = TextAnalysis.getMaxVvalueConcepts();
                int minValue = TextAnalysis.getMinVvalueConcepts();

                int countCircles = 0;

                foreach (KeyValuePair<string, DataTag> item in TextAnalysis.Concepts.OrderByDescending(i => i.Value.count))
                {
                    if (item.Value.count > averageValue && countCircles < 20)
                    {
                        Color fullColor = Color.FromArgb(45, rand.Next(255), rand.Next(255), rand.Next(255));

                        double norma = (item.Value.count - minValue) / (double)maxValue;

                        int radius = (int)((norma * 200) > 30 ? norma * 200 : 50);

                        Font font = new Font(FontFamily.GenericSansSerif, 9);

                        PointF pos = GetPosition(radius);

                        item.Value.point = new PointF(pos.X - radius / 2, pos.Y - radius / 2);

                        circle.Draw(gr, item.Key, radius, fullColor, fullColor, font, pos);
                        pGraphic.Image = graphics;
                        countCircles++;
                    }
                    else break;
                }
            }
        }

        private void getGraphicsConnections()
        {
            int count = TextAnalysis.Concepts.Count;

            if (count > 0)
            {
                int countCircles = 0;

                foreach (KeyValuePair<string, DataTag> item in TextAnalysis.Concepts.OrderByDescending(i => i.Value.count))
                {
                    if (item.Value.count > averageValue && countCircles < 20)
                    {
                        foreach (string neighbor in item.Value.neighbors)
                        {
                            if (TextAnalysis.Concepts[neighbor].count > averageValue && 
                                TextAnalysis.Concepts[neighbor].point != new PointF(0,0))
                            {
                                using (Pen pen = new Pen(Color.FromArgb(70, 105, 105, 105), 1.5F))
                                {
                                    gr.DrawLine(
                                        pen,
                                        item.Value.point.X, 
                                        item.Value.point.Y,
                                        TextAnalysis.Concepts[neighbor].point.X,
                                        TextAnalysis.Concepts[neighbor].point.Y
                                        );
                                }
                                pGraphic.Image = graphics;
                            }
                        }
                        countCircles++;
                    } else
                    {
                        return;
                    }
                }
            }
        }

        private void btReAnalysis_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            circles.Clear();
            TextAnalysis.setConceptsAnalysisWithStopwords();
            getGraphics();
        }

        private void tabControlForAnalisys_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlForAnalisys.SelectedIndex)
            {
                case 1:
                    {
                        if (isLoadConcepts)
                        {
                            break;
                        }
                        LoadConcepts();
                        break;
                    }
                case 2:
                    {
                        if (isLoadThesaurus)
                        {
                            break;
                        }
                        //TextAnalysis.(titles);
                        LoadThesaurus();
                        break;
                    }
                case 3:
                    {
                        if (isLoadNames && isLoadOrganizations)
                        {
                            break;
                        }
                        //TextAnalysis.getNames(Info);
                        //TextAnalysis.SetNamesAnalysis();
                        //LoadNames();
                        //TextAnalysis.SetOrganizationAnalysis();
                        //LoadOrganizations();
                        break;
                    }
            }
        }

        private void btConnection_Click(object sender, EventArgs e)
        {
            TextAnalysis.GetParseTree(Info);
            getGraphicsConnections();
        }
    }
}