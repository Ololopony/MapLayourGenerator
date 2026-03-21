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
                Cell currentCell = _layout.GetCellByIndex(i, j);
                int downCellIndex = i + 1;
                int upCellIndex = i - 1;
                int rightCellIndex = j + 1;
                int leftCellIndex = j - 1;

                if (downCellIndex < _layout.GetMapHight())
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Down, _layout.GetCellByIndex(i + 1, j));
                }
                if (upCellIndex >= 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Up, _layout.GetCellByIndex(i - 1, j));
                }
                if (rightCellIndex < _layout.GetMapWidth())
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Right, _layout.GetCellByIndex(i, j + 1));
                }
                if (leftCellIndex >= 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(RelativeDirection.Left, _layout.GetCellByIndex(i, j - 1));
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
                            Cell currentCell = _layout.GetCellByIndex(i, j);
                            if (!currentCell.GetCellType().EnumCellType.Equals(CellTypes.UnassinedCellType))
                            {
                                continue;
                            }
                            if (currentCell.TypeCompatableWithNeighbour(cellType.Key))
                            {
                                currentCell.SetCellType(cellType.Key);
                                cellTypeAmount--;
                                cellTypeLeft--;
                            }
                            else
                            {
                                needChangeCellType = true;
                                _cellTypesByAmount[cellType.Key] = cellTypeAmount;
                                break;
                            }
                            if (random.Next(0, 2) == 1 || cellTypeAmount == 0)
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
