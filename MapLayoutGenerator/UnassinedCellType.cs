namespace MapLayoutGenerator;

public class UnassinedCellType : ICellType
{
    public Enum GetCellType()
    {
        return CellTypes.UnassinedCellType;
    }

    public bool CellTypeIsCompatable(ICellType otherCellType)
    {
        return false;
    }
}
