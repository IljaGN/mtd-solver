using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTD_Solver.Api
{
  public class EcxhangerType
  {
    public Types Type { get; private set; }
    public string Caption { get; private set; }
    public string Image { get; private set; }

    public EcxhangerType(Types type, string caption, string image)
    {
      Type = type;
      Caption = caption;
      Image = image;
    }
  }

  public enum Types
  {
    COCURRENT,
    COUNTERCURRENT,
    SHELL_AND_TUBE,
    CROSS_FLOW
  }
}
