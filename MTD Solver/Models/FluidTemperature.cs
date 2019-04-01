namespace MTD_Solver.Models
{
  struct FluidTemperature
  {
    public double Inlet { get; set; }
    public double Outlet { get; set; }
    public double Difference => Inlet > Outlet ? Inlet - Outlet : Outlet - Inlet;
  }
}
