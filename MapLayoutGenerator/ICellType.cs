namespace MapLayoutGenerator;

public interface ICellType
{
    public Enum GetCellType();
    public bool CellTypeIsCompatable(ICellType otherCellType);
}
