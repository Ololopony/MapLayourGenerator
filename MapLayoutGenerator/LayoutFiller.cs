namespace MapLayoutGenerator;

public class LayoutFiller
{
    private Layout _layout;
    private Dictionary<ICellType, int> _cellTypesByAmount = new Dictionary<ICellType, int>();
    private int _layoutCellsAmount;
    private const int CELL_EDGES_FOR_SQUARE = 4;
    private const int CELL_EDGES_FOR_OCTAGONE = 8;

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
}
