using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOMSample
{
    class SourceReader
    {
        private List<Record> Data { get; set; }
        private List<Part> Parts { get; set; }
        public List<Part> BOM { get; set; }

        public SourceReader(string path)
        {
            CSV csv = new CSV(path);
            Data = csv.Data;

            this.Parts = new List<Part>();
            MakeSampleData();

            this.BOM = new List<Part>();
            this.BOM = MakeBOMData(this.Parts);
        }
        private void MakeSampleData()
        {
            foreach (var item in Data)
            {
                this.Parts.Add(new Part { Level = item.Level, Name = item.No });
            }
        }
        private List<Part> MakeBOMData(List<Part> partsList)
        {
            Part last = new Part();
            for (int cnt = MaxLevel(); cnt > 0; cnt--)
            {
                Part current = new Part();
                List<Part> list = partsList;
                List<Part> delList = new List<Part>();
                List<Part> bar = new List<Part>();
                foreach (Part item in list)
                {
                    if (item.Level == cnt)
                    {
                        current.Parts.Add(item);
                        delList.Add(item);
                    }
                    else
                    {
                        current = item;
                        bar.Add(item);
                    }
                }

                partsList = bar;
            }
            return partsList;
        }
        private int MaxLevel()
        {
            return this.Parts.Max(x => x.Level);
        }
    }
}
