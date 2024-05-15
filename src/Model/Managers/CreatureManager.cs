using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers;
public class CreatureManager<T>(List<T> registeredCreatures, List<GameObject> prefabs) : ManagerBase<T>(registeredCreatures, prefabs) { }
