using MTD_Solver.Api;
using MTD_Solver.Models.Exchangers;

namespace MTD_Solver.Utils
{
  static class ExchangerFactory
  {
    public static IHeatExchanger Create(ExchangerType type)
    {
      switch (type)
      {
        case ExchangerType.COCURRENT:
          return new CocurrentExchanger();
        case ExchangerType.COUNTERCURRENT:
          return new CountercurrentExchanger();
        case ExchangerType.SHELLANDTUBE:
          return new ShellAndTubeExchanger();
        case ExchangerType.CROSSFLOW:
          return new CrossFlowExchanger();
        default:
          return new CocurrentExchanger();
      }
    }
  }
}
