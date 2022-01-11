using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Finder.Collection
{
    class Collection
    {
        public static List<int> MakeListOfIndexes(string findedText, ListView listView, int columnNumber)
        {
            return
                listView.Items.Cast<ListViewItem>()
                .Where(
                    item =>
                    item.SubItems[columnNumber].Text.ToLower().IndexOf(findedText.ToLower()) >= 0
                )
                .Select(item => item.Index)
                .ToList();
        }

        public static List<int> MakeListOfIndexes(string findedText, List<string> list)
        {
            return
                list
                .Select((item, index) => new Tuple<string, int>(item, index))
                .Where(
                    item =>
                    item.Item1.ToLower().IndexOf(findedText.ToLower()) >= 0
                )
                .Select(item => item.Item2)
                .ToList();
        }

        public static void SelectItem(ListView listView, int currentIndex)
        {
            if (currentIndex != -1)
            {
                listView.Select();
                foreach (ListViewItem item in listView.SelectedItems)
                    item.Selected = false;
                listView.Items[currentIndex].Selected = true;
                listView.EnsureVisible(currentIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
        }
    }
}
