using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BibReader.Log
{
    class Log
    {
        string Name = "logs.log";

        public void Write(string @string)
        {
            var writer = new StreamWriter(Name, true);
            writer.WriteLine(@string);
            writer.Close();
        }
    }
}
