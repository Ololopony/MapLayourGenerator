using System.Text.Json;

namespace MapLayoutGenerator;

public class JSONToCellTypeDictionaryDeserialiser
{
    public Dictionary<ICellType, int> DeserialiseJSONRulesToCellTypeDictionary(string jsonRules)
    {
        if (jsonRules is not null)
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<ICellType, int>>(jsonRules);
            Dictionary<ICellType, int> cellTypesByAmount = new Dictionary<ICellType, int>();
            if (deserialized is not null)
            {
                cellTypesByAmount = deserialized;
            }
            return cellTypesByAmount;
        }
        else
        {
            throw new ArgumentNullException(nameof(jsonRules), "The provided JSON string is null.");
        }
    }
}
