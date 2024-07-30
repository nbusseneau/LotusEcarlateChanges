extern alias WorldAdvancementProgression;

using System.Linq;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using WorldAdvancementProgression::VentureValheim.Progression;

namespace LotusEcarlateChanges.Changes.Manual;

public class WorldAdvancementProgression : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Fix world keys for chicken farming
    KeyManager.Instance.FoodKeysList["ChickenMeat"] = KeyManager.BOSS_KEY_SWAMP;
    KeyManager.Instance.FoodKeysList["ChickenEgg"] = KeyManager.BOSS_KEY_SWAMP;

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(KeyManager), nameof(KeyManager.IsActionBlocked), [typeof(ItemDrop.ItemData), typeof(int), typeof(bool), typeof(bool), typeof(bool)]),
      prefix: new HarmonyMethod(this.GetType(), nameof(AllowPoisonArrowsAfterTheElder))
    );

    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(KeyManager), nameof(KeyManager.IsActionBlocked), [typeof(Recipe), typeof(int), typeof(bool), typeof(bool), typeof(bool)]),
      prefix: new HarmonyMethod(this.GetType(), nameof(AllowOneIngredientRecipes))
    );
  }

  private static void AllowPoisonArrowsAfterTheElder(KeyManager __instance, ItemDrop.ItemData item, ref bool __result, ref bool __runOriginal)
  {
    if (item?.m_dropPrefab is not { } prefab) return;
    var itemName = Utils.GetPrefabName(prefab);
    if (itemName == "ArrowPoison" && __instance.HasKey(KeyManager.BOSS_KEY_BLACKFOREST))
    {
      __runOriginal = false;
      __result = false;
    }
  }

  private static void AllowOneIngredientRecipes(KeyManager __instance, Recipe recipe, int quality, bool checkBossItems, bool checkMaterials, bool checkFood, ref bool __result, ref bool __runOriginal)
  {
    __runOriginal = false;

    if (recipe is null)
    {
      __result = false;
      return;
    }

    var resources = recipe.m_resources.Where(resource => resource.m_resItem is not null);
    foreach (var resource in resources)
    {
      // Blocked should account for both base requirements and all valid upgrades on an item.
      // Only check a resource if it's actually required at current quality level or any previous quality.
      var shouldCheckResource = Enumerable.Range(1, quality).Any(q => resource.GetAmount(q) > 0);
      if (shouldCheckResource)
      {
        var resourceName = Utils.GetPrefabName(resource.m_resItem.gameObject);
        var isAllowed = __instance.HasItemKey(resourceName, checkBossItems, checkMaterials, checkFood);
        // If recipe only requires one ingredient, allow usage as soon as one ingredient is allowed
        if (recipe.m_requireOnlyOneIngredient && isAllowed)
        {
          __result = false;
          return;
        }
        // Otherwise block usage as soon as one ingredient is not allowed
        else if (!isAllowed)
        {
          __result = true;
          return;
        }
      }
    }

    __result = false;
  }
}
