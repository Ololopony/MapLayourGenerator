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

    public bool TypeCompatableWithNeighbour(CellType cellType)
    {
        foreach (var neighbouringCell in _neighbouringCells)
        {
            if (!neighbouringCell.Value.GetCellType().CellTypeIsCompatable(cellType))
            {
                return false;
            }
        }
        return true;
    }

    public CellType GetCellType()
    {
        return _cellType;
    }

    public void SetCellType(CellType cellType)
    {
        _cellType = cellType;
    }

    public void AssignNewNeighbourCellByDirection(RelativeDirection relativeDirection, Cell newCell)
    {
        if (_neighbouringCells.Count < _maxNeighbouringCells)
        {
            _neighbouringCells.Add(relativeDirection, newCell);
        }
    }
}
