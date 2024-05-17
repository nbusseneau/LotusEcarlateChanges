using System.Collections;
using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Manager;

public interface IManager : IEnumerable
{
  public void RemoveAll(HashSet<string> toRemove);
  public void KeepOnly(HashSet<string> toKeep);
}
