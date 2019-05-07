using MTD_Solver.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  abstract class SimpleBaseExchanger : IHeatExchanger
  {
    private const double CORRECTION_FACTOR = 1;
    private double P => temperature.ColdFluid.Difference / (temperature.HotFluid.Inlet - temperature.ColdFluid.Inlet);
    private double R => temperature.HotFluid.Difference / temperature.ColdFluid.Difference;

    protected ExchangerIn temperature;
    protected ExchangerOut result;

    public SimpleBaseExchanger()
    {
      result = new ExchangerOut();
    }

    public void SetSourceData(ExchangerIn data)
    {
      temperature = data;
    }

    public void Execute()
    {
      double greatDifference = GetGreatTemperatureDifference();
      double smallDifference = GetSmallTemperatureDifference();
      double logarithmicDifference = Math.Log(greatDifference / smallDifference);
      double mtd = (greatDifference - smallDifference) / logarithmicDifference;
      result.Update(P, R, CORRECTION_FACTOR, mtd);
    }

    public ExchangerOut GetResult()
    {
      return result;
    }

    abstract protected double GetGreatTemperatureDifference();
    abstract protected double GetSmallTemperatureDifference();
  }
}
