using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Utils
{
  static class Exchanger
  {
    public enum Types
    {
      COCURRENT,
      COUNTERCURRENT,
      SHELL_AND_TUBE,
      CROSS_FLOW
    }

    public static Types TypeValueOf(string typeName)
    {
      return (Types)Enum.Parse(typeof(Types), typeName, true);
    }

    private static readonly Dictionary<Types, string> captions = new Dictionary<Types, string>
    {
      [Types.COCURRENT] = Types.COCURRENT.ToString().ToLower(),
      [Types.COUNTERCURRENT] = Types.COUNTERCURRENT.ToString().ToLower(),
      [Types.SHELL_AND_TUBE] = Types.SHELL_AND_TUBE.ToString().ToLower(),
      [Types.CROSS_FLOW] = Types.CROSS_FLOW.ToString().ToLower()
    };

    public static string GetCaptions(Types type)
    {
      return captions[type];
    }

    public static List<string> GetCaptions()
    {
      return captions.Values.ToList<string>();
    }
  }
}
