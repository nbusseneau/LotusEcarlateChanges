using System.Collections;
using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.StandaloneManagerInterceptors;

public interface IStandaloneManagerInterceptor : IEnumerable
{
  public void RemoveAll(HashSet<string> toRemove);
  public void KeepOnly(HashSet<string> toKeep);
}
