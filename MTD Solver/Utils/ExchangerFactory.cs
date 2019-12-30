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
      switch (settings.Pass)
      {
        case PassCount.ONE:
          return SinglePassCrossFlowExchanger(settings);
        case PassCount.TWO:
          return TwoPassCrossFlowExchanger(settings);
        default:
          return new SinglePassOneMixedCfe();
      }
    }

    private static IHeatExchanger SinglePassCrossFlowExchanger(CrossFlowExchangerSettings settings)
    {
      switch (settings.Fluids)
      {
        case FluidsBehavior.BOTH_UNMIXED:
          return new SinglePassBothUnmixedCfe();
        case FluidsBehavior.ONE_MIXED:
          return new SinglePassOneMixedCfe();
        case FluidsBehavior.BOTH_MIXED:
          return new SinglePassBothMixedCfe();
        default:
          return new SinglePassOneMixedCfe();
      }
    }

    private static IHeatExchanger TwoPassCrossFlowExchanger(CrossFlowExchangerSettings settings)
    {
      switch (settings.FluidAcrossTubes)
      {
        case ShellFluidAcrossTubes.FIRST:
          return new ShellFluidAcrossFirstTubeBundleTpomCfe();
        case ShellFluidAcrossTubes.SECOND:
          return new ShellFluidAcrossSecondTubeBundleTpomCfe();
        default:
          return new ShellFluidAcrossFirstTubeBundleTpomCfe();
      }
    }
  }
}
