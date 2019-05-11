using System.ComponentModel;

namespace MTD_Solver.Models
{
  public class FluidTemperature : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private double inlet;
    public double Inlet
    {
      get => inlet;
      set
      {
        inlet = value;
        OnPropertyChanged(nameof(Inlet));
      }
    }
    private double outlet;
    public double Outlet
    {
      get => outlet;
      set
      {
        outlet = value;
        OnPropertyChanged(nameof(Outlet));
      }
    }
    public double Difference => Inlet > Outlet ? Inlet - Outlet : Outlet - Inlet;

    private void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
