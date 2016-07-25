using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IStateTaxInfoRepo
    {
        List<StateTaxInfo> GetAllStateTaxInfos();
    }

    class StateTaxInfoRepo : IStateTaxInfoRepo
    {
        private List<StateTaxInfo> _stateTaxInfos;
        public StateTaxInfoRepo()
        {
            Decode();
        }

        private void Decode()
        {

            _stateTaxInfos = new List<StateTaxInfo>();
            string[] records = File.ReadAllLines(@"textfilereferences\taxes.txt");
            {
                for (int i = 1; i < records.Length; i++)
               
                {
                    string[] fields = records[i].Split(',');
                    StateTaxInfo temp = new StateTaxInfo();
                    temp.StateAbb = fields[0];
                    temp.StateName = fields[1];
                    temp.TaxRate = Convert.ToDecimal(fields[2]);
                    _stateTaxInfos.Add(temp);
                }
            }
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            return _stateTaxInfos;

        }
    }
}
