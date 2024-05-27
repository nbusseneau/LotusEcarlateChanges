using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.StandaloneManagerInterceptors;

public class CreatureManagerInterceptor<T>(List<T> registeredCreatures, List<GameObject> prefabs) : StandaloneManagerInterceptorBase<T>(registeredCreatures, prefabs) { }
