using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models
{
  public class ExchangerIn
  {
    public FluidTemperature ColdFluid { get; set; }
    public FluidTemperature HotFluid { get; set; }

    public ExchangerIn()
    {
      ColdFluid = new FluidTemperature();
      HotFluid = new FluidTemperature();
    }
  }
}
