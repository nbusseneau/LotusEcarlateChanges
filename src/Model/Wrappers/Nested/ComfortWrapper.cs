namespace LotusEcarlateChanges.Model.Wrappers.Nested;

public class ComfortWrapper(Piece piece)
{
  private readonly Piece _piece = piece;

  public int Value { get => this._piece.m_comfort; set => this._piece.m_comfort = value; }
  public Piece.ComfortGroup Group { get => this._piece.m_comfortGroup; set => this._piece.m_comfortGroup = value; }
}
