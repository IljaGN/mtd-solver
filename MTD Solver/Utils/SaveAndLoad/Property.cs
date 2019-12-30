using MTD_Solver.Configs;
using MTD_Solver.Models;
using MTD_Solver.Models.Exchangers;

namespace MTD_Solver.Utils
{
  public class Property
  {
    public AppConfig AppConfig { get; set; }
    public WindowData WindowData { get; set; }

    public Property() { }

    public Property(AppConfig config, WindowData data)
    {
      AppConfig = config;
      WindowData = data;
    }

    public static Property GetDefault()
    {
      var config = new AppConfig
      {
        DecimalPlaces = 2,
        Locale = "RU"
      };
      var data = new WindowData
      {
        ExchangerType = Type.COCURRENT,
        ShellAndTubeSettings = new ShellAndTubeExchangerSettings
        {
          ShellCount = 1
        },
        CrossFlowSettings = new CrossFlowExchangerSettings
        {
          Pass = PassCount.ONE,
          Fluids = FluidsBehavior.ONE_MIXED,
          FluidAcrossTubes = ShellFluidAcrossTubes.FIRST
        }
      };
      return new Property(config, data);
    }
  }
}
