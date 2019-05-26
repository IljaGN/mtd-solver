using System.Collections.Generic;
using MTD_Solver.Models.Exchangers;
using MTD_Solver.Utils;

namespace MTD_Solver.View
{
  public class UiType : UiEnum<Type>
  {
    private UiType(Type type, string caption) : base(type, caption) { }

    public static List<UiType> Get()
    {
      return new List<UiType>
      {
        new UiType(Type.COCURRENT, Properties.Resources.CocurrentExchanger),
        new UiType(Type.COUNTERCURRENT, Properties.Resources.CountercurrentExchanger),
        new UiType(Type.SHELL_AND_TUBE, Properties.Resources.ShellAndTubeExchanger),
        new UiType(Type.CROSS_FLOW, Properties.Resources.CrossFlowExchanger)
      };
    }
  }
}
