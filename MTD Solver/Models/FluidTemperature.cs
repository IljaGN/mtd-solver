using MTD_Solver.Api;

namespace MTD_Solver.Models
{
  public class FluidTemperature : NotifyPropertyChangedBase
  {
    private double inlet;
    public double Inlet
    {
      get => inlet;
      set
      {
        inlet = value;
        OnPropertyChanged();
      }
    }
    private double outlet;
    public double Outlet
    {
      get => outlet;
      set
      {
        outlet = value;
        OnPropertyChanged();
      }
    }
    public double Difference => Inlet > Outlet ? Inlet - Outlet : Outlet - Inlet;
  }
}
