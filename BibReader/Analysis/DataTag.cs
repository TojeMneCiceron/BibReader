using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Analysis
{
    public class DataTag
    {
        public int count { get; set; }
        public List<string> neighbors { get; set; }
        public PointF point { get; set; }



        public DataTag(int _count, List<string> _neighbors)
        {
            count = _count;
            neighbors = _neighbors;
        }
    }
}
