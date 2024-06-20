using HarmonyLib;
using UnityEngine.UI;
using UnityEngine;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class ColorFoodSlots : ManualChangesBase
{
  private const float Alpha = 0.503f; // vanilla food slot alpha value
  private static Color s_healthColor;
  private static Color s_staminaColor;
  private static Color s_eitrColor;
  private static Color s_defaultColor;

  protected override void ApplyInternal()
  {
    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(InventoryGui), nameof(InventoryGui.Awake)),
      postfix: new HarmonyMethod(this.GetType(), nameof(InitializeColors))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Hud), nameof(Hud.UpdateFood)),
      postfix: new HarmonyMethod(this.GetType(), nameof(UpdateFood))
    );
  }

  private static Color InitializeColor(Color color, float alpha = Alpha) => new(color.r, color.g, color.b, alpha);
  private static void InitializeColors(InventoryGui __instance)
  {
    // set our colors combining vanilla food icon colors with vanilla food slot alpha value
    s_healthColor = InitializeColor(__instance.m_playerGrid.m_foodHealthColor);
    s_staminaColor = InitializeColor(__instance.m_playerGrid.m_foodStaminaColor);
    s_eitrColor = InitializeColor(__instance.m_playerGrid.m_foodEitrColor);
    s_defaultColor = InitializeColor(Color.black);
  }

  private static void UpdateFood(Hud __instance, Player player)
  {
    var foods = player.GetFoods();
    var foodIcons = __instance.m_foodIcons;

    // color non-empty slots
    for (int i = 0; i < foods.Count; i++)
    {
      var food = foods[i];
      var foodImage = foodIcons[i].transform.parent.gameObject.GetComponent<Image>();
      // use the exact same logic as for vanilla food icon colors from InventoryGrid.UpdateGui(...)
      if (food.m_eitr / 2f > food.m_health && food.m_eitr / 2f > food.m_stamina) foodImage.color = s_eitrColor;
      else if (food.m_health / 2f > food.m_stamina) foodImage.color = s_healthColor;
      else if (food.m_stamina / 2f > food.m_health) foodImage.color = s_staminaColor;
    }

    // decolor empty slots
    for (int i = foods.Count; i < foodIcons.Length; i++)
    {
      var foodImage = foodIcons[i].transform.parent.gameObject.GetComponent<Image>();
      foodImage.color = s_defaultColor;
    }
  }
}
