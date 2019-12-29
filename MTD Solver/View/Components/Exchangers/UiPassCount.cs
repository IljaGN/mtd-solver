using System.Collections.Generic;
using MTD_Solver.Models.Exchangers;
using MTD_Solver.Properties;
using MTD_Solver.Utils;

namespace MTD_Solver.View.Components.Exchangers
{
  public class UiPassCount : UiEnum<PassCount>
  {
    private UiPassCount(PassCount type, string caption) : base(type, caption) { }

    public static List<UiPassCount> Get()
    {
      return new List<UiPassCount>
      {
        new UiPassCount(PassCount.ONE, Resources.SinglePass),
        new UiPassCount(PassCount.TWO, Resources.TwoPass)
      };
    }
  }
}
