namespace MapLayoutGenerator;

public class LayoutFiller
{
    private Layout _layout;
    private Dictionary<ICellType, int> _cellTypesByAmount = new Dictionary<ICellType, int>();
    private int _layoutCellsAmount;
    private const int CELL_EDGES_FOR_SQUARE = 4;

    public LayoutFiller(int mapHight, int mapWidth, string jsonRules)
    {
        _layout = new Layout(mapHight, mapWidth);
        var deserialiser = new JSONToCellTypeDictionaryDeserialiser();
        _cellTypesByAmount = deserialiser.DeserialiseJSONRulesToCellTypeDictionary(jsonRules);
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
                Cell currentCell = _layout.GetCellByIndex(j + i);
                int downCellIndex = j + _layout.GetMapWidth();
                int upCellIndex = j - _layout.GetMapWidth();
                int rightCellIndex = j + 1;
                int leftCellIndex = j - 1;

                if (downCellIndex < _layoutCellsAmount)
                {
                    currentCell.AssignNewNeighbourCellByDirection(_layout.GetCellByIndex(downCellIndex), RelativeDirection.Down);
                }
                if (upCellIndex > 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(_layout.GetCellByIndex(upCellIndex), RelativeDirection.Up);
                }
                if (rightCellIndex < _layout.GetMapWidth())
                {
                    currentCell.AssignNewNeighbourCellByDirection(_layout.GetCellByIndex(rightCellIndex), RelativeDirection.Right);
                }
                if (leftCellIndex > 0)
                {
                    currentCell.AssignNewNeighbourCellByDirection(_layout.GetCellByIndex(leftCellIndex), RelativeDirection.Left);
                }
            }
        }
    }
    
    public void AssignTypesToCell()
    {
        Random random = new Random();
        bool needChangeCellType = false;

        foreach (var cellType in _cellTypesByAmount)
        {
            int cellTypeAmount = cellType.Value;

            for (int i = 0; i < _layout.GetMapHight(); i++)
            {
                for (int j = 0; j < _layout.GetMapWidth(); j++)
                {
                    if (!_layout.GetCellByIndex(i + j).GetCellType().Equals(CellTypes.UnassinedCellType))
                    {
                        continue;
                    }
                    _layout.GetCellByIndex(i + j).SetCellType(cellType.Key);
                    cellTypeAmount--;
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
            if (needChangeCellType)
            {
                continue;
            }
        }        
    }
}
