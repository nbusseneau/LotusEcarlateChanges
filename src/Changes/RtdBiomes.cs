using System.Collections.Generic;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Changes;

public class RtDBiomes : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var hammer = ItemManager["Hammer"];

    // Skull traps
    HashSet<string> piecesToRemove = [
      "SkullTrapMeadows_RtD",
      "SkullTrapBlackForest_RtD",
      "SkullTrapSwamp_RtD",
      "SkullTrapMountain_RtD",
      "SkullTrapPlains_RtD",
      "SkullTrapMistlands_RtD",
      "SkullTrapAshLands_RtD",
      "SkullTrapDeepNorth_RtD",
      "RuneStonePiece_RtD",
    ];
    hammer.Pieces.RemoveAll(p => piecesToRemove.Contains(p.name));
    ObjectDB.instance.m_items.RemoveAll(p => piecesToRemove.Contains(p.name));
  }
}
