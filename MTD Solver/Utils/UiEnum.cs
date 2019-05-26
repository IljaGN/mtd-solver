namespace MTD_Solver.Utils
{
  public abstract class UiEnum<T>
  {
    public T Type { get; private set; }
    public string Caption { get; private set; }

    protected UiEnum(T type, string caption)
    {
      Type = type;
      Caption = caption;
    }
  }
}
