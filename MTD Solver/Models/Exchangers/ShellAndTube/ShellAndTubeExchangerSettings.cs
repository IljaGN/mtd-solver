using MTD_Solver.Api;
using System;

namespace MTD_Solver.Models.Exchangers
{
  public class ShellAndTubeExchangerSettings : IExchangerSettings
  {
    private int shellCount;
    public int ShellCount {
      get => shellCount;
      set
      {
        if (value < 1 || value > 8)
        {
          throw new ArgumentException();
        }
        shellCount = value;
      }
    }
  }
}
