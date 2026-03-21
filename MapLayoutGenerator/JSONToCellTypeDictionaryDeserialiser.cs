using System.Text.Json;

namespace MapLayoutGenerator;

public class JSONToCellTypeDictionaryDeserialiser
{
    public Dictionary<string, int> DeserialiseJSONRulesToCellTypeDictionary(string jsonRules)
    {
        if (jsonRules is not null)
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonRules);
            Dictionary<string, int> cellTypesByAmount = new Dictionary<string, int>();
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
