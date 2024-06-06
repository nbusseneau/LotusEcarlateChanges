extern alias BalrondHumanoidRandomizer;

using System.Collections.Generic;
using System.Linq;
using BalrondHumanoidRandomizer::BalrondHumanoidRandomizer;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class BalrondHumanoidRandomizer : ManualChangesBase
{
  private static bool s_hasRunSpawnerSetup = false;

  protected override void ApplyInternal()
  {
    // Rebalance spawner changes
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(MonsterManager), nameof(MonsterManager.setupSpawners)),
      prefix: new HarmonyMethod(this.GetType(), nameof(SetupSpawners))
    );
  }

  private static void SetupSpawners(MonsterManager __instance, List<GameObject> list, ref bool __runOriginal)
  {
    __runOriginal = false;

    // guard against multiple runs
    if (s_hasRunSpawnerSetup) return;
    s_hasRunSpawnerSetup = true;

    var greydwarfNest = GetPrefab(list, "Spawner_GreydwarfNest");
    var greydwarfSpawner = greydwarfNest.GetComponent<SpawnArea>();
    greydwarfSpawner.m_maxNear = 6;
    __instance.CreateSpanwerDropList(greydwarfNest);
    AddSpawn(greydwarfSpawner, GetPrefab(list, "Greyling"), 5f);

    var evilBonePile = GetPrefab(list, "BonePileSpawner");
    var skeletonSpawner = evilBonePile.GetComponent<SpawnArea>();
    skeletonSpawner.m_maxNear = 3;
    skeletonSpawner.m_triggerDistance = 30f;
    skeletonSpawner.m_nearRadius = 30f;
    __instance.CreateSpanwerDropList(evilBonePile);
    AddSpawn(skeletonSpawner, GetPrefab(list, "Skeleton_Poison"), 0.25f);
    AddSpawn(skeletonSpawner, GetPrefab(list, "Ghost"), 0.05f);

    var bodyPile = GetPrefab(list, "Spawner_DraugrPile");
    var draugrSpawner = bodyPile.GetComponent<SpawnArea>();
    draugrSpawner.m_maxNear = 3;
    draugrSpawner.m_triggerDistance = 30f;
    draugrSpawner.m_nearRadius = 30f;
    __instance.CreateSpanwerDropList(bodyPile);
    AddSpawn(draugrSpawner, GetPrefab(list, "Wraith"), 0.10f);
  }

  private static GameObject GetPrefab(List<GameObject> prefabs, string prefabName) => prefabs.Single(prefab => prefab.name == prefabName);

  private static void AddSpawn(SpawnArea spawner, GameObject prefab, float weight)
  {
    spawner.m_prefabs.Add(new()
    {
      m_prefab = prefab,
      m_weight = weight,
      m_minLevel = 1,
      m_maxLevel = 3,
    });
  }
}
