using System;
using MapLayoutGenerator;

namespace TestIntegrationConsoleApp;

public class LakeType : CellType
{
    public LakeType()
    {
        EnumCellType = CellTypes.Lake;
    }

    public override bool CellTypeIsCompatable(CellType otherCellType)
    {
        if (otherCellType.EnumCellType.Equals(CellTypes.Mountain))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
