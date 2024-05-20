using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Search
    {
        public string Word { get; set; }
        public List<Location> Results { get; set; }

        public DateTime Time { get; set; }
        public Search(string word, List<Location> results)
        {
            Word = word;
            Results = results;
            Time = DateTime.Now;
        }

    }
}
