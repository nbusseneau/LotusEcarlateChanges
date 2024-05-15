using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers;

public class PieceManager<T>(List<T> registeredPieces, List<GameObject> piecePrefabs) : ManagerBase<T>(registeredPieces, piecePrefabs) { }
