using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOMSample
{
    class Sample
    {
        private List<Part> SourceData { get; set; }
        private List<Part> TargetData { get; set; }
        private const string sourceName = "Source.csv";
        private const string targetName = "Target.csv";
        public Sample()
        {
            this.SourceData = ReadCSV(sourceName);
            this.TargetData = ReadCSV(targetName);
        }
        private List<Part> ReadCSV(string path)
        {
            SourceReader csv = new SourceReader(path);
            return csv.BOM;
        }
        public void Compare()
        {

        }
    }
}
