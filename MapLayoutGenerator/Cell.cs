namespace MapLayoutGenerator;

public class Cell
{
    private int _maxNeighbouringCells;
    private Dictionary<RelativeDirection, Cell> _neighbouringCells = new Dictionary<RelativeDirection, Cell>();
    private CellType _cellType = new UnassinedCellType();

    public Cell(CellType cellType, int cellEdgesNumber = 4)
    {
        _cellType = cellType;
        _maxNeighbouringCells = cellEdgesNumber;
    }

    public Enum GetCellType()
    {
        return _cellType.EnumCellType;
    }

    public void SetCellType(CellType cellType)
    {
        _cellType = cellType;
    }

    public void AssignNewNeighbourCellByDirection(Cell newCell, RelativeDirection relativeDirection)
    {
        if (_neighbouringCells.Count < _maxNeighbouringCells)
        {
            _neighbouringCells.Add(relativeDirection, newCell);
        }
    }
}
