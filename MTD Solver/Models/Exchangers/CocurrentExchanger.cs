using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  class CocurrentExchanger : SimpleBaseExchanger
  {
    protected override double GetGreatTemperatureDifference()
    {
      return temperature.HotFluid.Inlet - temperature.ColdFluid.Inlet;
    }

    protected override double GetSmallTemperatureDifference()
    {
      return temperature.HotFluid.Outlet - temperature.ColdFluid.Outlet;
    }
  }
}
