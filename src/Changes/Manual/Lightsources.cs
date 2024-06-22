using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class Lightsources : ManualChangesBase
{
  private const float LightRangeMultiplier = 2f;
  private static readonly Dictionary<string, (float?, float?)> s_fireplaceRangesCache = [];
  private static readonly Dictionary<string, float> s_torchlikeRangesCache = [];
  private const float TorchDurability = 50f;

  protected override void ApplyApplyOnObjectDBAwakeInternal()
  {
    // Fireplace pieces ranges
    // Do a first pass to build range cache
    var hammer = this.ItemManager["Hammer"];
    var fireplacePrefabs = hammer.Pieces.Where(p => p.GetComponent<Fireplace>() is not null);
    foreach (var prefab in fireplacePrefabs)
    {
      var fireplace = prefab.GetComponent<Fireplace>();
      // Wall torches and ground torches only have a single light
      if (fireplace.m_enabledObject is { } enabled && enabled.GetComponentInChildren<Light>() is { } light)
      {
        if (!s_fireplaceRangesCache.ContainsKey(prefab.name)) s_fireplaceRangesCache[prefab.name] = (light.range, null);
      }
      // Most fireplaces have a high (default) light and a low light
      else if (fireplace.m_enabledObjectHigh is { } enabledHigh && enabledHigh.GetComponentInChildren<Light>() is { } lightHigh)
      {
        float? high = lightHigh.range;
        float? low = null;
        if (fireplace.m_enabledObjectLow is { } enabledLow && enabledLow.GetComponentInChildren<Light>() is { } lightLow)
        {
          low = lightLow.range;
        }
        if (!s_fireplaceRangesCache.ContainsKey(prefab.name)) s_fireplaceRangesCache[prefab.name] = (high, low);
      }
    }

    // Do a second pass to set light values
    // We don't do it in one pass because some lights seem to share the same underlying objects and
    // we don't want to multiply their ranges more than once
    foreach (var prefab in fireplacePrefabs)
    {
      var fireplace = prefab.GetComponent<Fireplace>();
      var (high, low) = s_fireplaceRangesCache[prefab.name];
      if (fireplace.m_enabledObject is { } enabled && enabled.GetComponentInChildren<Light>() is { } light)
      {
        light.range = high.Value * LightRangeMultiplier;
      }
      else if (fireplace.m_enabledObjectHigh is { } enabledHigh && enabledHigh.GetComponentInChildren<Light>() is { } lightHigh)
      {
        lightHigh.range = high.Value * LightRangeMultiplier;
        if (fireplace.m_enabledObjectLow is { } enabledLow && enabledLow.GetComponentInChildren<Light>() is { } lightLow)
        {
          lightLow.range = low.Value * LightRangeMultiplier;
        }
      }
    }

    // Torch-like items ranges
    string[] torchlike = [
      // Vanilla items
      "Torch",
      "HelmetDverger",
      // BowsBeforeHoes arrows
      "TorchArrow",
      "MistTorchArrow",
    ];
    foreach (var item in this.ItemManager[torchlike])
    {
      var light = item.Prefab.GetComponentInChildren<Light>(includeInactive: true);
      if (!s_torchlikeRangesCache.TryGetValue(item.PrefabName, out var cached))
      {
        cached = light.range;
        s_torchlikeRangesCache[item.PrefabName] = cached;
      }
      light.range = cached * LightRangeMultiplier;
    }

    // Torch durability
    var torch = this.ItemManager["Torch"];
    torch.ItemData.m_durability = TorchDurability;
    torch.SharedData.m_maxDurability = TorchDurability;
  }
}
