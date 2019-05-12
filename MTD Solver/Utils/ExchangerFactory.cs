using MTD_Solver.Api;
using MTD_Solver.Models.Exchangers;

namespace MTD_Solver.Utils
{
  static class ExchangerFactory
  {
    public static IHeatExchanger Create(Types type, string exchangerSettings)
    {
      switch (type)
      {
        case Types.COCURRENT:
          return new CocurrentExchanger();
        case Types.COUNTERCURRENT:
          return new CountercurrentExchanger();
        //case Exchanger.Types.SHELL_AND_TUBE:
        //  return new ShellAndTubeExchanger();
        //case Exchanger.Types.CROSS_FLOW:
        //  return new CrossFlowExchanger();
        default:
          return new CocurrentExchanger();
      }
    }
  }
}
