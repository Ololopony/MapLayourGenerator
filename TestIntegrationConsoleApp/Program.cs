using MapLayoutGenerator;

namespace TestIntegrationConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Layout layout = new Layout(3, 3);
        string json = 
        """
            {
                "mountains":1,
                "lakes":1,
                "forests":7
            }
        """;
        JSONToCellTypeDictionaryDeserialiser des = new JSONToCellTypeDictionaryDeserialiser();
        Dictionary<string, int> typesStringDictionary = des.DeserialiseJSONRulesToCellTypeDictionary(json);
        Dictionary<CellType, int> typesDictionary = new Dictionary<CellType, int>();
        foreach (var type in typesStringDictionary)
        {
            switch (type.Key)
            {
                case "mountains":
                    typesDictionary.Add(new MountainType(), type.Value);
                    continue;
                case "forests":
                    typesDictionary.Add(new ForestType(), type.Value);
                    continue;
                case "lakes":
                    typesDictionary.Add(new LakeType(), type.Value);
                    continue;
            }
        }
        LayoutFiller layoutFiller = new LayoutFiller(layout, typesDictionary);
        layoutFiller.FillLayoutWithEmptyCells();
        layoutFiller.AssignNewNeighbourCells();
        layoutFiller.AssignTypesToCell();

        for (int i = 0; i < layout.GetMapHight(); i++)
        {
            for (int j = 0; j < layout.GetMapWidth(); j++)
            {
                switch (layout.GetCellByIndex(i, j).GetCellType().EnumCellType)
                {
                    case CellTypes.Forest:
                        Console.Write("F");
                        continue;
                    case CellTypes.Lake:
                        Console.Write("L");
                        continue;
                    case CellTypes.Mountain:
                        Console.Write("M");
                        continue;
                    default:
                        Console.Write("D");
                        continue;
                }
            }
            Console.WriteLine("");
        }
    }
}