using MTD_Solver.Api;
using System.Collections.Generic;

namespace MTD_Solver.Utils
{
  static class Exchanger
  {
    private static readonly List<EcxhangerType> types = new List<EcxhangerType>
    {
      new EcxhangerType(Type.COCURRENT, Properties.Resources.CocurrentExchanger, ""),
      new EcxhangerType(Type.COUNTERCURRENT, Properties.Resources.CountercurrentExchanger, ""),
      new EcxhangerType(Type.SHELL_AND_TUBE, Properties.Resources.ShellAndTubeExchanger, ""),
      new EcxhangerType(Type.CROSS_FLOW, Properties.Resources.CrossFlowExchanger, "")
    };

    //public static Types TypeValueOf(string typeName)
    //{
    //  return (Types)Enum.Parse(typeof(Types), typeName, true);
    //}

    //public static string GetCaptions(Types type)
    //{
    //  return captions[type];
    //}

    public static List<EcxhangerType> GetTypes()
    {
      return types;
    }
  }
}
