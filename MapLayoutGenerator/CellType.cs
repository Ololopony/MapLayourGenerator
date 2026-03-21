namespace MapLayoutGenerator;

public abstract class CellType
{
    private Enum _cellType;
    public Enum EnumCellType {get { return _cellType; } set { _cellType = value; }}
    public abstract bool CellTypeIsCompatable(CellType otherCellType);
}
