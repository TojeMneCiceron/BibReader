using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BibReaderTest
{
    

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        int EditDistance(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[,] ed = new int[m, n];

            ed[0, 0] = (s[0] == t[0]) ? 0 : 1;
            for (int i = 1; i < m; i++)
            {
                ed[i, 0] = ed[i - 1, 0] + 1;
            }

            for (int j = 1; j < n; j++)
            {
                ed[0, j] = ed[0, j - 1] + 1;
            }

            for (int j = 1; j < n; j++)
            {
                for (int i = 1; i < m; i++)
                {
                    if (s[i] == t[j])
                    {
                        // Операция не требуется
                        ed[i, j] = ed[i - 1, j - 1];
                    }
                    else
                    {
                        // Минимум между удалением, вставкой и заменой
                        ed[i, j] = Math.Min(ed[i - 1, j] + 1,
                            Math.Min(ed[i, j - 1] + 1, ed[i - 1, j - 1] + 1));
                    }
                }
            }

            return ed[m - 1, n - 1];
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void TestEdit()
        {
            var value = EditDistance("Lol My Test".ToLower(), "lol my  test".ToLower());
            Assert.AreEqual(1, value);
        }
    }
}
