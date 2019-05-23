using System;
using MTD_Solver.Api;

namespace MTD_Solver.Models.Exchangers
{
  abstract class SimpleBaseExchanger : IHeatExchanger
  {
    private const double CORRECTION_FACTOR = 1;
    private double P => temperature.ColdFluid.Difference / (temperature.HotFluid.Inlet - temperature.ColdFluid.Inlet);
    private double R => temperature.HotFluid.Difference / temperature.ColdFluid.Difference;

    protected ExchangerIn temperature;
    protected ExchangerOut result;

    public void BindSourceData(ExchangerIn data)
    {
      temperature = data;
    }

    public void BindResultData(ExchangerOut data)
    {
      result = data;
    }

    public void Execute()
    {
      double greatDifference = GetGreatTemperatureDifference();
      double smallDifference = GetSmallTemperatureDifference();
      double logarithmicDifference = Math.Log(greatDifference / smallDifference);
      double mtd = (greatDifference - smallDifference) / logarithmicDifference;
      result.Update(P, R, CORRECTION_FACTOR, mtd);
    }

    abstract protected double GetGreatTemperatureDifference();
    abstract protected double GetSmallTemperatureDifference();
  }
}
