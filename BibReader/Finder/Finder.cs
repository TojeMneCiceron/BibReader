using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Finder
{
    class Finder
    {
        int CurrentIndex = -1;

        public int GetIndex(List<int> indexes, Func<List<int>, int, int> func)
        {
            return
                CurrentIndex = 
                indexes.Count > 0
                ? func(indexes, CurrentIndex)
                : -1;
        }
    }
}
