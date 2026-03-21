using System;
using MapLayoutGenerator;

namespace TestIntegrationConsoleApp;

public class MountainType : CellType
{
    public MountainType()
    {
        EnumCellType = CellTypes.Mountain;
    }

    public override bool CellTypeIsCompatable(CellType otherCellType)
    {
        return true;
    }
}
