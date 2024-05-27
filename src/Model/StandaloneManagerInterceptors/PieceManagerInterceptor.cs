using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.StandaloneManagerInterceptors;

public class PieceManagerInterceptor<T>(List<T> registeredPieces, List<GameObject> piecePrefabs) : StandaloneManagerInterceptorBase<T>(registeredPieces, piecePrefabs) { }
