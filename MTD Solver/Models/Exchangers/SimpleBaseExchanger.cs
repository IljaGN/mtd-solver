using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Models.Exchangers
{
  abstract class SimpleBaseExchanger : IHeatExchanger
  {
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
      result.Update(getP(), getR(), 1, mtd);
    }

    public ExchangerOut GetResult()
    {
      return result;
    }

    private double getP()
    {
      return temperature.ColdFluid.Difference / (temperature.HotFluid.Inlet - temperature.ColdFluid.Inlet);
    }

    private double getR()
    {
      return temperature.HotFluid.Difference / temperature.ColdFluid.Difference;
    }

    abstract protected double GetGreatTemperatureDifference();
    abstract protected double GetSmallTemperatureDifference();
  }
}
