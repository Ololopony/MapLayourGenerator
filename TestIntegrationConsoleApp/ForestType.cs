using System;
using MapLayoutGenerator;

namespace TestIntegrationConsoleApp;

public class ForestType : CellType
{
    public ForestType()
    {
        EnumCellType = CellTypes.Forest;
    }

    public override bool CellTypeIsCompatable(CellType otherCellType)
    {
        return true;
    }
}