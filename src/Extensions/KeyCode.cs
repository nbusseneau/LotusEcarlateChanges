using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace LotusEcarlateChanges.Extensions;

public static class KeyCodeExtensions
{
  /// <summary>
  /// Utility extension method mimicking Valheim's internal behaviour for localizing keycodes. The original logic can be
  /// found in <c>ZInput.GetBoundKeyString(...)</c>, unfortunately it is intended for use with <c>ZInput.ButtonDef</c>
  /// button names and dispatches the underlying keycodes right away in the same function, hence why we had to duplicate
  /// the code.
  /// </summary>
  public static string ToLocalizableString(this KeyCode keyCode)
  {
    return ZInput.KeyCodeToDisplayName(keyCode);
  }
}
