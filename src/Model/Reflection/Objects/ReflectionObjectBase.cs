namespace LotusEcarlateChanges.Model.Reflection.Objects;

public abstract class ReflectionObjectBase(object obj)
{
  protected readonly object _obj = obj;
  public abstract string UniqueName { get; }
}
