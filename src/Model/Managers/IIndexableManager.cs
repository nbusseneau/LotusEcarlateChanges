using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Managers;

public interface IIndexableManager<T> : IManager, IEnumerable<T>
{
  /// <summary>
  /// Get managed object by name.
  /// </summary>
  public T this[string name] { get; }

  /// <summary>
  /// Get managed objects by name.
  /// </summary>
  public IEnumerable<T> this[params string[] names] { get; }
}
