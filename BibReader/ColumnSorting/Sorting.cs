using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.ColumnSorting
{
    class Sorting
    {
        public static void SortingByColumn(ListView listView, int columnNumber)
        {
            var sorter = (ListViewItemComparer)listView.ListViewItemSorter;

            if (sorter == null)
            {
                sorter = new ListViewItemComparer(columnNumber);
                listView.ListViewItemSorter = sorter;
            }
            else
            {
                sorter.Column = columnNumber;
            }

            decimal val;
            if (listView.Items.Count != 0)
            if (Decimal.TryParse(listView.Items[0].SubItems[columnNumber].Text, out val))
                sorter.Numeric = true;
            else
                sorter.Numeric = false;

            listView.Sort();
        }

        public class ListViewItemComparer : IComparer
        {
            public int Column { get; set; }

            public bool Numeric { get; set; }

            public ListViewItemComparer(int columnIndex)
            {
                Column = columnIndex;
            }

            public int Compare(object x, object y)
            {
                var itemX = x as ListViewItem;
                var itemY = y as ListViewItem;

                if (itemX == null && itemY == null)
                    return 0;
                else if (itemX == null)
                    return -1;
                else if (itemY == null)
                    return 1;

                if (itemX == itemY) return 0;

                if (Numeric)
                {
                    decimal itemXVal, itemYVal;

                    if (!Decimal.TryParse(itemX.SubItems[Column].Text, out itemXVal))
                    {
                        itemXVal = decimal.MaxValue;
                    }
                    if (!Decimal.TryParse(itemY.SubItems[Column].Text, out itemYVal))
                    {
                        itemYVal = decimal.MaxValue;
                    }

                    return Decimal.Compare(itemXVal, itemYVal);
                }
                else
                {
                    string itemXText = itemX.SubItems[Column].Text;
                    string itemYText = itemY.SubItems[Column].Text;

                    return String.Compare(itemXText, itemYText);
                }
            }
        }
    }
}
