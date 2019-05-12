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
