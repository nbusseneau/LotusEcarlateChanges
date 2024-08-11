extern alias RtDBiomes;

using RtDBiomes::RtDBiomes;
using Jotunn.Managers;
using LotusEcarlateChanges.Model.Changes;


namespace LotusEcarlateChanges.Changes.JotunnBased;

public class RtDBiomes() : JotunnBasedChangesBase("Soloredis.RtDBiomes")
{
  protected override void ApplyInternal()
  {
    string[] treesToRemove = [
      "MagicTree6_RtD",
      "MagicTree7_RtD",
      "MagicTree8_RtD",
      "MagicTree9_RtD",
      "MagicTree10_RtD",
    ];
    foreach (var tree in treesToRemove) ZoneManager.Instance.RemoveCustomVegetation(tree);
  }
}
