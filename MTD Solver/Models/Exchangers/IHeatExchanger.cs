using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  interface IHeatExchanger
  {
    void SetSourceData(ExchangerIn data);
    void Execute();
    ExchangerOut GetResult();
  }
}
