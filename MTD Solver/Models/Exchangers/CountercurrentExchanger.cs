using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  class CountercurrentExchanger : SimpleBaseExchanger
  {
    protected override double GetGreatTemperatureDifference()
    {
      return temperature.HotFluid.Inlet - temperature.ColdFluid.Outlet;
    }

    protected override double GetSmallTemperatureDifference()
    {
      return temperature.HotFluid.Outlet - temperature.ColdFluid.Inlet;
    }
  }
}
