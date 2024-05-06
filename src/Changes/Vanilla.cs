using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LotusEcarlateChanges.Model.Manual;
using LotusEcarlateChanges.Model;

namespace LotusEcarlateChanges.Changes;

public class Vanilla : ManualChangesBase
{
  const float LightRangeMultiplier = 2f;
  static readonly Dictionary<string, (float?, float?)> fireplaceRangesCache = [];
  static readonly Dictionary<string, float> torchlikeRangesCache = [];

  protected override void ApplyChangesInternal()
  {
    // Relocate some Misc pieces to Furniture for consistency
    var hammer = ItemManager["Hammer"];
    HashSet<string> toRelocate = [
      "darkwood_raven",
      "darkwood_wolf",
      "wood_dragon1",
    ];
    foreach (var prefab in hammer.Pieces.Where(p => toRelocate.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Furniture;
    }

    // Skills
    ItemManager["THSwordKrom"].SharedData.m_skillType = SkillManager.Skill.fromName(CustomSkills.TwoHandedSwords);

    // Fireplace ranges
    // Do a first pass to build range cache
    var fireplacePrefabs = hammer.Pieces.Where(p => p.GetComponent<Fireplace>() is not null);
    foreach (var prefab in fireplacePrefabs)
    {
      var fireplace = prefab.GetComponent<Fireplace>();
      // Wall torches and ground torches only have a single light
      if (fireplace.m_enabledObject is { } enabled && enabled.GetComponentInChildren<Light>() is { } light)
      {
        if (!fireplaceRangesCache.ContainsKey(prefab.name)) fireplaceRangesCache[prefab.name] = (light.range, null);
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
        if (!fireplaceRangesCache.ContainsKey(prefab.name)) fireplaceRangesCache[prefab.name] = (high, low);
      }
    }

    // Do a second pass to set light values
    // We don't do it in one pass because some lights seem to share the same underlying objects and
    // we don't want to multiply their ranges more than once
    foreach (var prefab in fireplacePrefabs)
    {
      var fireplace = prefab.GetComponent<Fireplace>();
      var (high, low) = fireplaceRangesCache[prefab.name];
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

    // Torch-like ranges
    HashSet<string> torchlike = [
      "Torch",
      "HelmetDverger",
    ];
    foreach (var itemName in torchlike)
    {
      var item = ItemManager[itemName];
      var light = item.Prefab.GetComponentInChildren<Light>(includeInactive: true);
      if (!torchlikeRangesCache.ContainsKey(itemName)) torchlikeRangesCache[itemName] = light.range;
      light.range = torchlikeRangesCache[itemName] * LightRangeMultiplier;
    }

    // Torch durability
    var torch = ItemManager["Torch"];
    torch.ItemData.m_durability = 40f;
    torch.SharedData.m_maxDurability = 40f;
  }
}
