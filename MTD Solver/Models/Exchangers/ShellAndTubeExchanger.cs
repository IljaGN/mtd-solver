using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  class ShellAndTubeExchanger : CompositeBaseExchanger
  {
    public override void Execute()
    {
      base.Execute();
      ExchangerOut pivotData = GetCountercurrentExchangerResult();
    }
  }
}
