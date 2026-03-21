namespace MapLayoutGenerator;

public class UnassinedCellType : CellType
{
    public UnassinedCellType()
    {
        EnumCellType = CellTypes.UnassinedCellType;
    }

    public override bool CellTypeIsCompatable(CellType otherCellType)
    {
        return false;
    }
}
