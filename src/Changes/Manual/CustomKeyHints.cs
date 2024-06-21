extern alias MaxAxe;

using System.Collections.Generic;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Extensions;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class CustomKeyHints : ManualChangesBase
{
  private readonly Dictionary<string, HashSet<ConfigDefinition>> _configDefinitions = new()
  {
    // Combat
    ["Azumatt.BowsBeforeHoes"] = [
      new("3 - Keyboard Shortcuts", "Bow Zoom Hotkey"),
      new("3 - Keyboard Shortcuts", "Bow Draw Cancel Hotkey"),
    ],
    ["blacks7ar.WeaponHolsterOverhaul"] = [
      new("General", "Unequipped Key"),
    ],
    ["neobotics.valheim_mod.maxaxe"] = [
      new("General", "ThrowOne"),
      new("General", "ThrowShield"),
    ],
    ["Searica.Valheim.DodgeShortcut"] = [
      new("Mechanics", "DodgeShortcut"),
    ],

    // Build
    ["advize.PlantEasily"] = [
      new("Controls", "KeyboardModifierKey"),
      new("Controls", "KeyboardHarvestModifierKey"),
    ],
    ["Searica.Valheim.TerrainTools"] = [
      // TerrainTools uses zero-width spaces repeated X times as section prefixes to sort them in a specific order,
      // so we must have them as well to match the config entries
      new("​​​​​​​​Radius", "RadiusModKey"),
      new("​​​​​​Hardness", "HardnessModKey"),
    ],

    // Inventory
    ["Azumatt.ItemCompare"] = [
      new("1 - General", "Hover Keybind"),
    ],
    ["goldenrevolver.quick_stack_store"] = [
      new("1 - Favoriting", "FavoritingModifierKeybind1"),
      new("2.1 - Quick Stacking", "QuickStackKeybind"),
      new("2.2 - Quick Restocking", "RestockKeybind"),
      new("4 - Sorting", "SortKeybind"),
    ],

    // Swim
    ["blacks7ar.VikingsDoSwim"] = [
      new("2- General", "Dive Hotkey"),
      new("2- General", "Ascend Hotkey"),
    ],

    // Map
    ["org.bepinex.plugins.targetportal"] = [
      new("1 - General", "Hotkey map icons"),
    ],
  };

  private readonly Dictionary<string, string> _keyHintStrings = [];

  protected override void ApplyInternal()
  {
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(KeyHints), nameof(KeyHints.UpdateHints)),
      postfix: new HarmonyMethod(this.GetType(), nameof(UpdateHints))
    );

    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Beehive), nameof(Beehive.GetHoverText)),
      postfix: new HarmonyMethod(this.GetType(), nameof(BeehiveGetHoverText))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Pickable), nameof(Pickable.GetHoverText)),
      postfix: new HarmonyMethod(this.GetType(), nameof(PickableGetHoverText))
    );
  }

  private static void UpdateHints(KeyHints __instance)
  {
    if (Player.m_localPlayer is not { } player) return;
    // default safeguard copied from KeyHints.UpdateHints
    if (!__instance.m_keyHintsEnabled || player.IsDead() || Chat.instance.IsChatDialogWindowVisible() || Game.IsPaused() || (InventoryGui.instance != null && (InventoryGui.instance.IsSkillsPanelOpen || InventoryGui.instance.IsTrophisPanelOpen || InventoryGui.instance.IsTextPanelOpen))) return;

    var isCombat = KeyHints.instance.m_combatHints.activeInHierarchy;
    var isBuild = KeyHints.instance.m_buildHints.activeInHierarchy;
    var isInventory = KeyHints.instance.m_inventoryHints.activeInHierarchy || KeyHints.instance.m_inventoryWithContainerHints.activeInHierarchy;
    var isSwimming = player.IsSwimming();

    s_swimHints.SetActive(!isCombat && !isBuild && !isInventory && isSwimming);

    if (isCombat)
    {
      s_bowDrawZoomHint.SetActive(KeyHints.instance.m_bowDrawKB.activeInHierarchy);
      s_bowDrawCancelHint.SetActive(KeyHints.instance.m_bowDrawKB.activeInHierarchy);

      var hasSomethingInHand = player.m_leftItem is not null || player.m_rightItem is not null;
      s_holsterSwap.SetActive(hasSomethingInHand);
      s_unequip.SetActive(hasSomethingInHand);

      var isThrowableRight = MaxAxe::neobotics.ValheimMods.MaxAxe.IsThrowable(player.m_rightItem);
      var isThrowableLeft = MaxAxe::neobotics.ValheimMods.MaxAxe.IsThrowable(player.m_leftItem);
      var isThrowableShield = isThrowableLeft && player.m_leftItem?.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Shield;
      s_throwWeaponHint.SetActive(isThrowableRight || isThrowableLeft && !isThrowableShield);
      s_throwShieldHint.SetActive(isThrowableShield);

      s_combatSwimDive.SetActive(isSwimming);
      s_combatSwimAscend.SetActive(isSwimming);
    }

    else if (isBuild)
    {
      var currentTool = player.m_rightItem;
      var isCultivator = currentTool?.m_dropPrefab?.name.Contains("Cultivator") ?? false;
      var isHoe = currentTool?.m_dropPrefab?.name.Contains("Hoe") ?? false;
      s_cultivatorModifierHint.SetActive(isCultivator);
      s_hoeRadiusModifierHint.SetActive(isHoe);
      s_hoeHardnessModifierHint.SetActive(isHoe);

      s_buildSwimDive.SetActive(isSwimming);
      s_buildSwimAscend.SetActive(isSwimming);
    }

    else if (isInventory)
    {
      var hasWeapon = player.m_rightItem is { } right && right.IsWeapon() || player.m_leftItem is { } left && left.IsWeapon();
      var hasShield = player.m_leftItem?.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Shield;
      s_compare.SetActive(hasWeapon || hasShield);
      s_compareWithContainer.SetActive(hasWeapon || hasShield);
    }
  }

  private static string bulkHarvestModifierHoverKey;
  private static void BeehiveGetHoverText(Beehive __instance, ref string __result)
  {
    // only add our hover text if honey can actually be extracted
    var isPrivate = !PrivateArea.CheckAccess(__instance.transform.position, flash: false);
    var hasHoney = __instance.GetHoneyLevel() > 0;
    if (isPrivate || !hasHoney) return;

    var hoverTextSuffix = $"\n[<b><color=yellow>{bulkHarvestModifierHoverKey}</color> + <color=yellow>$KEY_Use</color></b>] $piece_beehive_extract $KeyHint_Pickable_Bulk";
    __result += Localization.instance.Localize(hoverTextSuffix);
  }
  private static void PickableGetHoverText(Pickable __instance, ref string __result)
  {
    // only add our hover text if the pickable can actually be picked
    if (__instance.GetPicked() || __instance.GetEnabled == 0) return;

    var hoverTextSuffix = $"\n[<b><color=yellow>{bulkHarvestModifierHoverKey}</color> + <color=yellow>$KEY_Use</color></b>] $inventory_pickup $KeyHint_Pickable_Bulk";
    __result += Localization.instance.Localize(hoverTextSuffix);
  }

  protected override void ApplyApplyOnObjectDBAwakeInternal()
  {
    this.FetchPluginConfigEntries();
    this.SetUpCombatHints();
    this.SetUpBuildHints();
    this.SetUpInventoryHints();
    this.SetUpSwimHints();
    this.SetUpMapHints();
    bulkHarvestModifierHoverKey = this._keyHintStrings["advize.PlantEasily.Controls.KeyboardHarvestModifierKey"];
  }

  private void FetchPluginConfigEntries()
  {
    foreach (var (guid, configDefinitions) in this._configDefinitions)
    {
      var foundPlugin = Chainloader.PluginInfos.TryGetValue(guid, out var pluginInfo);
      foreach (var configDefinition in configDefinitions)
      {
        var section = configDefinition.Section.Replace("\u200B", string.Empty); // this is just for sanitizing TerrainTools sections lol
        var configKey = $"{guid}.{section}.{configDefinition.Key}";
        var configValue = foundPlugin ? this.SanitizeConfigValues(pluginInfo.Instance.Config[configDefinition].BoxedValue) : "MissingPlugin";
        this._keyHintStrings[configKey] = configValue;
      }
    }
  }

  private string SanitizeConfigValues(object obj)
  {
    if (obj is KeyCode keyCode) return keyCode.ToLocalizableString();
    else if (obj is KeyboardShortcut keyboardShortcut) return this.SanitizeConfigValues(keyboardShortcut.MainKey); // assume single key shortcuts
    else return obj.ToString(); // fallback
  }

  private static CustomKeyHint s_bowDrawZoomHint;
  private static CustomKeyHint s_bowDrawCancelHint;
  private static CustomKeyHint s_throwWeaponHint;
  private static CustomKeyHint s_throwShieldHint;
  private static CustomKeyHint s_holsterSwap;
  private static CustomKeyHint s_unequip;
  private void SetUpCombatHints()
  {
    CustomKeyHint templateHint = new(KeyHints.instance.m_combatHints.Find("Keyboard/Block"));
    s_bowDrawZoomHint = CustomKeyHint.Clone(templateHint, "BowDrawZoom", "$KeyHint_Combat_BowDrawZoom", this._keyHintStrings["Azumatt.BowsBeforeHoes.3 - Keyboard Shortcuts.Bow Zoom Hotkey"], siblingIndex: 3, hide: true);
    s_bowDrawCancelHint = CustomKeyHint.Clone(templateHint, "BowDrawCancel", "$KeyHint_Combat_BowDrawCancel", this._keyHintStrings["Azumatt.BowsBeforeHoes.3 - Keyboard Shortcuts.Bow Draw Cancel Hotkey"], siblingIndex: 4, hide: true);
    s_throwWeaponHint = CustomKeyHint.Clone(templateHint, "Throw", "$KeyHint_Combat_Throw", this._keyHintStrings["neobotics.valheim_mod.maxaxe.General.ThrowOne"], siblingIndex: 5, hide: true);
    s_throwShieldHint = CustomKeyHint.Clone(templateHint, "ThrowShield", "$KeyHint_Combat_ThrowShield", this._keyHintStrings["neobotics.valheim_mod.maxaxe.General.ThrowShield"], siblingIndex: 6, hide: true);
    s_holsterSwap = CustomKeyHint.Clone(templateHint, "HolsterSwap", "$KeyHint_Combat_HolsterSwap", ZInput.instance.m_buttons["Hide"].m_key.ToString());
    s_unequip = CustomKeyHint.Clone(templateHint, "Unequip", "$KeyHint_Combat_Unequip", this._keyHintStrings["blacks7ar.WeaponHolsterOverhaul.General.Unequipped Key"]);

    CustomKeyHint dodgeHint = new(KeyHints.instance.m_combatHints.Find("Keyboard/Dodge"), key: this._keyHintStrings["Searica.Valheim.DodgeShortcut.Mechanics.DodgeShortcut"]);
    dodgeHint.HideChildren("plus", "key_bkg (2)");
  }

  private static CustomKeyHint s_cultivatorModifierHint;
  private static CustomKeyHint s_hoeRadiusModifierHint;
  private static CustomKeyHint s_hoeHardnessModifierHint;
  private void SetUpBuildHints()
  {
    CustomKeyHint menuHint = new(KeyHints.instance.m_buildHints.Find("Keyboard/BuildMenu"));
    menuHint.Find("Text").SetText("$KeyHint_Build_Menu");

    CustomKeyHint snapHint = new(KeyHints.instance.m_buildHints.Find("Keyboard/AltPlace"));
    snapHint.Find("Text").SetText("$KeyHint_Build_NoSnap");

    CustomKeyHint templateHint = new(KeyHints.instance.m_buildHints.Find("Keyboard/Place"));
    s_cultivatorModifierHint = CustomKeyHint.Clone(templateHint, "CultivatorModifierKey", "$KeyHint_Cultivator_ModifierKey", this._keyHintStrings["advize.PlantEasily.Controls.KeyboardModifierKey"], siblingIndex: 2, hide: true);
    this.AddPlusToKeyHint(s_cultivatorModifierHint);
    this.AddKeyBkgToKeyHint(s_cultivatorModifierHint, "←");
    this.AddKeyBkgToKeyHint(s_cultivatorModifierHint, "↑");
    this.AddKeyBkgToKeyHint(s_cultivatorModifierHint, "→");
    this.AddKeyBkgToKeyHint(s_cultivatorModifierHint, "↓");

    s_hoeRadiusModifierHint = CustomKeyHint.Clone(templateHint, "HoeRadiusModifierKey", "$KeyHint_Hoe_RadiusModifierKey", this._keyHintStrings["Searica.Valheim.TerrainTools.Radius.RadiusModKey"], siblingIndex: 2, hide: true);
    this.AddPlusToKeyHint(s_hoeRadiusModifierHint);
    this.AddMouseWheelIconToKeyHint(s_hoeRadiusModifierHint);
    s_hoeHardnessModifierHint = CustomKeyHint.Clone(templateHint, "HoeHardnessModifierKey", "$KeyHint_Hoe_HardnessModifierKey", this._keyHintStrings["Searica.Valheim.TerrainTools.Hardness.HardnessModKey"], siblingIndex: 3, hide: true);
    this.AddPlusToKeyHint(s_hoeHardnessModifierHint);
    this.AddMouseWheelIconToKeyHint(s_hoeHardnessModifierHint);

    // hide default rotate mouse wheel icon, replace with map ping one which is smaller, for some extra space
    var rotateHint = KeyHints.instance.m_buildHints.Find("Keyboard/rotate");
    rotateHint.Find("mousew_icon").SetActive(false);
    Object.Instantiate(Minimap.instance.m_hints[0].transform.Find("keyboard_hints/PingPanel/keyboard_hint"), rotateHint.transform);
  }

  private void AddPlusToKeyHint(CustomKeyHint keyHint) => Object.Instantiate(KeyHints.instance.m_buildHints.Find("Keyboard/Copy/Text (1)"), keyHint.Transform);
  private void AddKeyBkgToKeyHint(CustomKeyHint keyHint, string arrow)
  {
    var keyBkgClone = Object.Instantiate(KeyHints.instance.m_buildHints.Find("Keyboard/Place/key_bkg"), keyHint.Transform);
    keyBkgClone.name = "key_bkg";
    keyBkgClone.SetText(arrow);
  }
  private void AddMouseWheelIconToKeyHint(CustomKeyHint keyHint) => Object.Instantiate(Minimap.instance.m_hints[0].transform.Find("keyboard_hints/PingPanel/keyboard_hint"), keyHint.Transform);

  private static CustomKeyHint s_compare;
  private static CustomKeyHint s_compareWithContainer;
  private void SetUpInventoryHints()
  {
    var inventoryTemplateHint = SetUpCommonInventoryHints(KeyHints.instance.m_inventoryHints);
    var inventoryWithContainerTemplateHint = SetUpCommonInventoryHints(KeyHints.instance.m_inventoryWithContainerHints);

    s_compare = CustomKeyHint.Clone(inventoryTemplateHint, "Compare", "$KeyHint_Inventory_Compare", this._keyHintStrings["Azumatt.ItemCompare.1 - General.Hover Keybind"], siblingIndex: 0);
    s_compareWithContainer = CustomKeyHint.Clone(inventoryWithContainerTemplateHint, "Compare", "$KeyHint_Inventory_Compare", this._keyHintStrings["Azumatt.ItemCompare.1 - General.Hover Keybind"], siblingIndex: 0);
  }

  private CustomKeyHint SetUpCommonInventoryHints(GameObject inventoryHints)
  {
    CustomKeyHint inventoryTemplateHint = new(inventoryHints.Find("Keyboard/Move"));
    CustomKeyHint.Clone(inventoryTemplateHint, "Sort", "$KeyHint_Inventory_Sort", this._keyHintStrings["goldenrevolver.quick_stack_store.4 - Sorting.SortKeybind"], siblingIndex: 0);
    CustomKeyHint.Clone(inventoryTemplateHint, "Restock", "$KeyHint_Inventory_Restock", this._keyHintStrings["goldenrevolver.quick_stack_store.2.2 - Quick Restocking.RestockKeybind"], siblingIndex: 1);
    CustomKeyHint.Clone(inventoryTemplateHint, "QuickStack", "$KeyHint_Inventory_QuickStack", this._keyHintStrings["goldenrevolver.quick_stack_store.2.1 - Quick Stacking.QuickStackKeybind"], siblingIndex: 2);

    CustomKeyHint splitHint = new(inventoryHints.Find("Keyboard/Split"));
    splitHint.Label = "$KeyHint_Inventory_SplitStack";
    // add Mouse 2 for half stack split coming from Azumatt-MouseTweaks and position it after Mouse 1
    var key_bkg2 = Object.Instantiate(inventoryHints.Find("Keyboard/Use/key_bkg"), splitHint.Transform);
    key_bkg2.transform.SetSiblingIndex(splitHint.Find("key_bkg (2)").transform.GetSiblingIndex() + 1);

    // favorite keyhint fortunately needs the exact same Mouse 1 / Mouse 2 thing as the split keyhint
    CustomKeyHint.Clone(splitHint, "Favorite", "$KeyHint_Inventory_Favorite", this._keyHintStrings["goldenrevolver.quick_stack_store.1 - Favoriting.FavoritingModifierKeybind1"]);

    // hide default Move/LeftClick keyhint to gain some extra space -- everybody intuitively knows this anyway
    inventoryTemplateHint.SetActive(false);
    return inventoryTemplateHint;
  }

  private static CustomKeyHint s_combatSwimDive;
  private static CustomKeyHint s_combatSwimAscend;
  private static CustomKeyHint s_buildSwimAscend;
  private static CustomKeyHint s_buildSwimDive;
  private static GameObject s_swimHints;
  private void SetUpSwimHints()
  {
    CustomKeyHint combatTemplateHint = new(KeyHints.instance.m_combatHints.Find("Keyboard/Block"));
    s_combatSwimDive = CustomKeyHint.Clone(combatTemplateHint, "Dive", "$KeyHint_Swim_Dive", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Dive Hotkey"]);
    s_combatSwimAscend = CustomKeyHint.Clone(combatTemplateHint, "Ascend", "$KeyHint_Swim_Ascend", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Ascend Hotkey"]);

    CustomKeyHint buildTemplateHint = new(KeyHints.instance.m_buildHints.Find("Keyboard/Place"));
    s_buildSwimDive = CustomKeyHint.Clone(buildTemplateHint, "Dive", "$KeyHint_Swim_Dive", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Dive Hotkey"]);
    s_buildSwimAscend = CustomKeyHint.Clone(buildTemplateHint, "Ascend", "$KeyHint_Swim_Ascend", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Ascend Hotkey"]);

    s_swimHints = Object.Instantiate(KeyHints.instance.m_barberHints, KeyHints.instance.m_barberHints.transform.parent);
    s_swimHints.name = "SwimHints";
    GameObject.Destroy(s_swimHints.Find("Gamepad"));
    GameObject.Destroy(s_swimHints.Find("Keyboard/Look"));
    CustomKeyHint.Clone(combatTemplateHint, "Dive", "$KeyHint_Swim_Dive", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Dive Hotkey"], parent: s_swimHints.transform.Find("Keyboard"));
    CustomKeyHint.Clone(combatTemplateHint, "Ascend", "$KeyHint_Swim_Ascend", this._keyHintStrings["blacks7ar.VikingsDoSwim.2- General.Ascend Hotkey"], parent: s_swimHints.transform.Find("Keyboard"));
  }

  private void SetUpMapHints()
  {
    var templateHint = Minimap.instance.m_hints[0].transform.Find("keyboard_hints/AddPin").gameObject;
    var clone = Object.Instantiate(templateHint, templateHint.transform.parent);
    clone.name = "PortalsKeyHint";
    clone.SetText("$KeyHint_Map_TogglePortals");

    Object.Destroy(clone.transform.Find("keyboard_hint").gameObject);
    var keyBkgClone = Object.Instantiate(KeyHints.m_instance.m_buildHints.Find("Keyboard/AltPlace/key_bkg"), clone.transform);
    keyBkgClone.name = "key_bkg";
    keyBkgClone.SetText(this._keyHintStrings["org.bepinex.plugins.targetportal.1 - General.Hotkey map icons"]);
  }

  private class CustomKeyHint
  {
    public GameObject GameObject { get; }
    public Transform Transform => this.GameObject.transform;
    private readonly GameObject _text;
    public string Label { set => this._text.SetText(value); }
    private readonly GameObject _keyBkg;
    public string Key { set => this._keyBkg.SetText(value); }

    public CustomKeyHint(GameObject keyHint, string label = null, string key = null)
    {
      this.GameObject = keyHint;
      this._text = keyHint.Find("Text");
      this._keyBkg = keyHint.Find("key_bkg");
      if (!string.IsNullOrEmpty(label)) this.Label = label;
      if (!string.IsNullOrEmpty(key)) this.Key = key;
    }

    public static CustomKeyHint Clone(CustomKeyHint original, string name, string label = null, string key = null, int siblingIndex = -1, bool hide = false, Transform parent = null)
    {
      parent ??= original.GameObject.transform.parent;
      var clone = Object.Instantiate(original.GameObject, parent);
      clone.name = name;
      if (siblingIndex >= 0) clone.transform.SetSiblingIndex(siblingIndex);

      CustomKeyHint keyHint = new(clone, label, key);
      if (hide) keyHint.SetActive(false);
      return keyHint;
    }

    public GameObject Find(string name) => this.GameObject.Find(name);
    public void SetActive(bool value) => this.GameObject.SetActive(value);

    public void HideChildren(params string[] names)
    {
      foreach (var name in names) this.GameObject.Find(name).SetActive(false);
    }
  }
}
