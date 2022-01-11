using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace BibReader.Saver
{
    class ExcelSaver
    {
        static Dictionary<string, string> WorksheetNames = new Dictionary<string, string>()
        {
            {"lvSourceStatistic", "Источники" },
            {"lvYearStatistic", "Год" },
            {"lvTypeOfDoc", "Тип документа" },
            {"lvJournalStat", "Журналы" },
            {"lvConferenceStat", "Конференции" },
            {"lvGeography", "География" },
            {"lvFreqs", "Частоный словарь" },
        };

        public static void Save(List<ListView> listOfTables)
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                saveFile.Filter = "Файлы xls|*.xls";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;

                    var app = new Excel.Application();
                    var wb = app.Workbooks.Add(1);
                    foreach (ListView lv in listOfTables)
                    {
                        ToExcel(wb, lv);
                    }
                    wb.SaveAs(filePath);
                    wb.Close();
                    app.Quit();
                    MessageBox.Show("Файл сохранен!");
                }
            }
        }

        private static void ToExcel(Excel.Workbook wb, ListView list)
        {
            wb.Worksheets.Add();
            var ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = WorksheetNames.ContainsKey(list.Name) ? WorksheetNames[list.Name] : list.Name;
            int i = 1;
            foreach (ColumnHeader column in list.Columns)
            {
                ws.Cells[1, i] = column.Text;
                i++;
            }
            int j = 2;
            foreach (ListViewItem item in list.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    ws.Cells[j, i] = subitem.Text;
                    i++;
                }
                j++;
            }

        }

    }
}
