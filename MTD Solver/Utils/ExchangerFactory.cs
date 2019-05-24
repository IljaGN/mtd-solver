using MTD_Solver.Api;
using MTD_Solver.Models.Exchangers;

namespace MTD_Solver.Utils
{
  static class ExchangerFactory
  {
    public static IHeatExchanger Create(Type type, IExchangerSettings settings)
    {
      switch (type)
      {
        case Type.COCURRENT:
          return new CocurrentExchanger();
        case Type.COUNTERCURRENT:
          return new CountercurrentExchanger();
        case Type.SHELL_AND_TUBE:
          return new ShellAndTubeExchanger((ShellAndTubeExchangerSettings)settings);
        case Type.CROSS_FLOW:
          return CrossFlowExchanger((CrossFlowExchangerSettings)settings);
        default:
          return new CocurrentExchanger();
      }
    }

    private static IHeatExchanger CrossFlowExchanger(CrossFlowExchangerSettings settings)
    {
      return new CocurrentExchanger();
    }
  }
}
