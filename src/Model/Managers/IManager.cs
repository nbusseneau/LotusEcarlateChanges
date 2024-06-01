using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Managers;

public interface IManager
{
  /// <summary>
  /// Mark given names for removal from the manager. Exclusive with KeepOnly(...).
  /// </summary>
  public void Remove(params string[] names);

  /// <summary>
  /// Mark given names for removal from the manager. Exclusive with KeepOnly(...).
  /// </summary>
  public void Remove(IEnumerable<string> names);

  /// <summary>
  /// Mark given names to be kept with the manager. All non-marked names will be removed. Exclusive with Remove(...).
  /// </summary>
  public void Keep(params string[] names);

  /// <summary>
  /// Mark given names to be kept with the manager. All non-marked names will be removed. Exclusive with Remove(...).
  /// </summary>
  public void Keep(IEnumerable<string> names);

  /// <summary>
  /// Apply remove / keep marks by removing / keeping managed objects with corresponding names.
  /// </summary>
  public void Apply();
}
