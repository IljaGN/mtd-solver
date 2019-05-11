using MTD_Solver.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Utils
{
  static class Exchanger
  {
    private static readonly List<EcxhangerType> types = new List<EcxhangerType>
    {
      new EcxhangerType(Types.COCURRENT, Properties.Resources.CocurrentExchanger, ""),
      new EcxhangerType(Types.COUNTERCURRENT, Properties.Resources.CountercurrentExchanger, ""),
      new EcxhangerType(Types.SHELL_AND_TUBE, Properties.Resources.ShellAndTubeExchanger, ""),
      new EcxhangerType(Types.CROSS_FLOW, Properties.Resources.CrossFlowExchanger, "")
    };

    //public static Types TypeValueOf(string typeName)
    //{
    //  return (Types)Enum.Parse(typeof(Types), typeName, true);
    //}

    //public static string GetCaptions(Types type)
    //{
    //  return captions[type];
    //}

    public static List<string> GetCaptions()
    {
      return types.ConvertAll(t => t.Caption).ToList();
    }
  }
}
