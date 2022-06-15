using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Statistic
{
    public class FormStatistic
    {
        public static void LoadSourseStatistic(ListView lvSourceStatistic)
        {
            lvSourceStatistic.Clear();
            lvSourceStatistic.Columns.Add("Источник");
            lvSourceStatistic.Columns.Add("Первичных");
            lvSourceStatistic.Columns.Add("Уникальных");
            lvSourceStatistic.Columns.Add("Релевантных");
            lvSourceStatistic.Columns[0].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[1].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[2].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[3].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Items.AddRange(
                Stat.Sources.OrderBy(i => i.Key).
                Select(i => new ListViewItem(
                    new string[] {
                        (i.Key == "") ? "Неизвестный источник" : i.Key,
                        i.Value.ToString(),
                        Stat.SourcesUnique.ContainsKey(i.Key) ?
                        Stat.SourcesUnique[i.Key].ToString() : 0.ToString(),
                        Stat.SourcesRelevance.ContainsKey(i.Key) ?
                        Stat.SourcesRelevance[i.Key].ToString(): 0.ToString(),
                    })
                )
                .ToArray()
            );
            lvSourceStatistic.Items.Add(new ListViewItem(
                new string[] {
                    "ИТОГО",
                    Stat.Sources.Sum(i => i.Value).ToString(),
                    Stat.SourcesUnique.Sum(i => i.Value).ToString(),
                    Stat.SourcesRelevance.Sum(i => i.Value).ToString()
                }
            ));
        }

        public static void LoadAuthorsCountStatistic(ListView lvAuthorsCountStatistic)
        {
            lvAuthorsCountStatistic.Clear();
            lvAuthorsCountStatistic.Columns.Add("Количество авторов");
            lvAuthorsCountStatistic.Columns.Add("Количество");
            lvAuthorsCountStatistic.Items.AddRange(
                Stat.AuthorsCount.OrderBy(i => i.Key).
                Select(i => new ListViewItem(
                    new string[] { i.Key.ToString(), i.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvAuthorsCountStatistic.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.AuthorsCount.Sum(i => i.Value).ToString(),
            }));
            lvAuthorsCountStatistic.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvAuthorsCountStatistic.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static void LoadYearStatistic(ListView lvYearStatistic)
        {
            lvYearStatistic.Clear();
            lvYearStatistic.Columns.Add("Год");
            lvYearStatistic.Columns.Add("Количество");
            lvYearStatistic.Items.AddRange(
                Stat.Years.OrderBy(i => i.Key).
                Select(i => new ListViewItem(
                    new string[] { (i.Key == "") ? "Без года" : i.Key, i.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvYearStatistic.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Years.Sum(i => i.Value).ToString(),
            }));
            lvYearStatistic.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvYearStatistic.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static void LoadTypeStatistic(ListView lvTypeOfDoc)
        {
            lvTypeOfDoc.Clear();
            lvTypeOfDoc.Columns.Add("Тип документа");
            lvTypeOfDoc.Columns.Add("Количество");
            lvTypeOfDoc.Items.AddRange(
                Stat.Types.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvTypeOfDoc.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Types.Sum(i => i.Value).ToString(),
            }));
            lvTypeOfDoc.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            lvTypeOfDoc.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvTypeOfDoc.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static void LoadJournalStatistic(ListView lvJournalStat)
        {
            lvJournalStat.Clear();
            lvJournalStat.Columns.Add("Название журнала");
            lvJournalStat.Columns.Add("Количество");
            lvJournalStat.Columns[0].Width = lvJournalStat.Width / 2;
            lvJournalStat.Columns[1].Width = lvJournalStat.Width / 2;
            lvJournalStat.Items.AddRange(
                Stat.Journal.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Без названия" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvJournalStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Journal.Sum(i => i.Value).ToString(),
            }));
            lvJournalStat.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvJournalStat.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvJournalStat.Columns[1].Width = lvJournalStat.Width / 6;
            lvJournalStat.Columns[0].Width = (int)((lvJournalStat.Width - lvJournalStat.Columns[1].Width) * 0.94);
        }

        public static void LoadConferenceStatistic(ListView lvConferenceStat)
        {
            lvConferenceStat.Clear();
            lvConferenceStat.Columns.Add("Название конференции");
            lvConferenceStat.Columns.Add("Количество");
            lvConferenceStat.Columns[0].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Columns[1].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Items.AddRange(
                Stat.Conference.OrderBy(i => i.Key)
                .Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Без названия" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvConferenceStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Conference.Sum(i => i.Value).ToString(),
            }));
            lvConferenceStat.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvConferenceStat.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvConferenceStat.Columns[1].Width = lvConferenceStat.Width / 6;
            lvConferenceStat.Columns[0].Width = (int)((lvConferenceStat.Width - lvConferenceStat.Columns[1].Width)*0.94);
        }

        public static void LoadGeographyStatistic(ListView lvGeography)
        {

            lvGeography.Clear();
            lvGeography.Columns.Add("Страна");
            lvGeography.Columns.Add("Количество");
            lvGeography.Columns[0].Width = lvGeography.Width / 2;
            lvGeography.Columns[1].Width = lvGeography.Width / 2;
            lvGeography.Items.AddRange(
                Stat.Geography.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Без географии" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvGeography.Items.Add(new ListViewItem(
                new string[] { "ИТОГО",
                Stat.Geography.Sum(i => i.Value).ToString(),
            }));
            lvGeography.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvGeography.Columns[1].TextAlign = HorizontalAlignment.Right;
            lvGeography.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
