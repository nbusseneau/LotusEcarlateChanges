using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class Lightsources : ManualChangesBase
{
  private const float LightRangeMultiplier = 2f;
  private static readonly Dictionary<string, float[]> s_lightRangesCache = [];
  private const float TorchDurability = 50f;

  protected override void ApplyApplyOnObjectDBAwakeInternal()
  {
    // Light ranges
    var fireplacePieces = this.ItemManager["Hammer"].Pieces.Where(p => p.GetComponentInChildren<Fireplace>() is not null);
    ApplyLightRangeMultiplier(fireplacePieces);

    string[] nonFireplacePieces = [
      "piece_dvergr_lantern",
      "piece_dvergr_lantern_pole",
      "piece_Lavalantern",
    ];
    ApplyLightRangeMultiplier(this.PieceManager[nonFireplacePieces].Select(piece => piece.Prefab));

    string[] items = [
      // Vanilla items
      "Torch",
      "HelmetDverger",
      "Lantern",
      // BowsBeforeHoes arrows
      "TorchArrow",
      "MistTorchArrow",
    ];
    ApplyLightRangeMultiplier(this.ItemManager[items].Select(item => item.Prefab));

    // Torch durability
    var torch = this.ItemManager["Torch"];
    torch.ItemData.m_durability = TorchDurability;
    torch.SharedData.m_maxDurability = TorchDurability;
  }

  private static void ApplyLightRangeMultiplier(IEnumerable<GameObject> prefabs)
  {
    foreach (var prefab in prefabs)
    {
      var lights = prefab.GetComponentsInChildren<Light>(includeInactive: true);
      if (!s_lightRangesCache.TryGetValue(prefab.name, out var cached))
      {
        cached = lights.Select(l => l.range).ToArray();
        s_lightRangesCache[prefab.name] = cached;
      }
      for (int i = 0; i < lights.Length; i++) lights[i].range = cached[i] * LightRangeMultiplier;
    }
  }
}
