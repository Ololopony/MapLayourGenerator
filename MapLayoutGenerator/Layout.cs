namespace MapLayoutGenerator;

public class Layout
{
    private int _mapHight;
    private int _mapWidth;
    private List<Cell> _cells = new List<Cell>();

    public Layout(int hight, int width)
    {
        _mapHight = hight;
        _mapWidth = width;
    }

    public int GetMapHight()
    {
        return _mapHight;
    }

    public int GetMapWidth()
    {
        return _mapWidth;
    }

    public void AddCellToLayout(Cell cell)
    {
        if (_cells.Count < _mapHight * _mapWidth)
        {
            _cells.Add(cell);
        }
    }

    public Cell GetCellByIndex(int i, int j)
    {
        int realIndex = i * _mapHight + j;
        return _cells[realIndex];
    }
}
