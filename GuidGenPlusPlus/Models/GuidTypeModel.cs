namespace GuidGenPlusPlus.Models;

public class GuidTypeModel
{
    public string DisplayType { get; init; }
    public string Type { get; init; }
    public string Example { get; init; }

    public GuidTypeModel(string displayType, string type, string example)
    {
        DisplayType = displayType;
        Type = type;
        Example = example;
    }
}
