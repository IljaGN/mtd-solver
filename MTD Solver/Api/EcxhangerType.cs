namespace MTD_Solver.Api
{
  public class EcxhangerType
  {
    public Type Type { get; private set; }
    public string Caption { get; private set; }
    public string Image { get; private set; }

    public EcxhangerType(Type type, string caption, string image)
    {
      Type = type;
      Caption = caption;
      Image = image;
    }
  }

  public enum Type
  {
    COCURRENT,
    COUNTERCURRENT,
    SHELL_AND_TUBE,
    CROSS_FLOW
  }
}
