using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public struct SolutionFormInfo
    {
        public int MaxBench { get; set; }
        public string Unit { get; set; }


        public SolutionFormInfo(int maxBench, string unit)
        {
            this.MaxBench = maxBench;
            this.Unit = unit;


        }
    }
}
