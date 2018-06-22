using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData
{
    public class SortResult
    {
        public String resultName { get; set; }
        public List<String> resultLines { get; set; }

        public SortResult(String name)
        {
            this.resultName = name;
            this.resultLines = new List<string>();
        }
    }
}
