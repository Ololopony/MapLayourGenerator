using MapLayoutGenerator;

namespace TestIntegrationConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Layout layout = new Layout(10, 10);
        string json = 
        """
            {
                "mountains":20,
                "forests":50,
                "lakes":30
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
        foreach (var type in typesDictionary)
        {
            Console.WriteLine(type.Key);
            Console.WriteLine(type.Key.CellTypeIsCompatable(new MountainType()));
            Console.WriteLine(type.Value);
        }
    }
}