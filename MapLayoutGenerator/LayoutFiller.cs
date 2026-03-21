namespace MapLayoutGenerator;

public class LayoutFiller
{
    private Layout _layout;
    private Dictionary<CellType, int> _cellTypesByAmount = new Dictionary<CellType, int>();
    private int _layoutCellsAmount;
    private const int CELL_EDGES_FOR_SQUARE = 4;

    public LayoutFiller(Layout layout, Dictionary<CellType, int> cellTypesByAmount)
    {
        _layout = layout;
        _cellTypesByAmount = cellTypesByAmount;
        _layoutCellsAmount = _layout.GetMapHight() * _layout.GetMapWidth();
    }

    public void FillLayoutWithEmptyCells()
    {
        for (int i = 0; i < _layout.GetMapHight(); i++)
        {
            for (int j = 0; j < _layout.GetMapWidth(); j++)
            {
                Cell cell = new Cell(new UnassinedCellType(), CELL_EDGES_FOR_SQUARE);
                _layout.AddCellToLayout(cell);
            }
        }
    }

    public void AssignNewNeighbourCells()
    {
        for (int i = 0; i < _layout.GetMapHight(); i++)
        {
            for (int j = 0; j < _layout.GetMapWidth(); j++)
            {
                Cell currentCell = _layout.GetCellByIndex(j + i * _layout.GetMapHight());
                int downCellIndex = j + _layout.GetMapWidth() + i * _layout.GetMapHight();
                int upCellIndex = j - _layout.GetMapWidth() + i * _layout.GetMapHight();
                int rightCellIndex = j + 1 + i * _layout.GetMapHight();
                int leftCellIndex = j - 1 + i * _layout.GetMapHight();

                if (downCellIndex < _layoutCellsAmount)
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Down, _layout.GetCellByIndex(downCellIndex));
                }
                if (upCellIndex > 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Up, _layout.GetCellByIndex(upCellIndex));
                }
                if (rightCellIndex < _layout.GetMapWidth())
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Right, _layout.GetCellByIndex(rightCellIndex));
                }
                if (leftCellIndex > 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Left, _layout.GetCellByIndex(leftCellIndex));
                }
            }
        }
    }
    
    public void AssignTypesToCell()
    {
        Random random = new Random();
        int cellTypeLeft = _layout.GetMapHight() * _layout.GetMapWidth();

        while (cellTypeLeft > 0)
        {
            foreach (var cellType in _cellTypesByAmount)
            {
                bool needChangeCellType = false;
                int cellTypeAmount = cellType.Value;
                if (cellType.Value > 0)
                {
                    for (int i = 0; i < _layout.GetMapHight(); i++)
                    {
                        for (int j = 0; j < _layout.GetMapWidth(); j++)
                        {
                            if (!_layout.GetCellByIndex(i + j * _layout.GetMapHight()).GetCellType().Equals(CellTypes.UnassinedCellType))
                            {
                                continue;
                            }
                            _layout.GetCellByIndex(i + j * _layout.GetMapHight()).SetCellType(cellType.Key);
                            cellTypeAmount--;
                            cellTypeLeft--;
                            if (random.Next(0, 2) == 1 || cellTypeAmount == 0)
                            // if (cellTypeAmount == 0)
                            {
                                needChangeCellType = true;
                                _cellTypesByAmount[cellType.Key] = cellTypeAmount;
                                break;
                            }
                        }
                        if (needChangeCellType)
                        {
                            break;
                        }
                    }
                }
            } 
        }
    }
}
