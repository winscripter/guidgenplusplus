using GuidGenPlusPlus.Models;
using System.Collections.ObjectModel;

namespace GuidGenPlusPlus;

internal static class GuidTypes
{
    public static readonly GuidTypeModel TextOnly = new("Text Only", "TextOnly", Guid.NewGuid().ToString());
    public static readonly GuidTypeModel TextOnlyWithCurlyBrackets = new("Text Only (With Curly Brackets)", "TextOnlyCB", $"{{{Guid.NewGuid()}}}");
    public static readonly GuidTypeModel ImplementOleCreate = new("IMPLEMENT_OLECREATE Function", "ImplementOleCreate", GuidGenerator.ImplementOleCreate());
    public static readonly GuidTypeModel DefineGuid = new("DEFINE_GUID Function", "DefineGuid", GuidGenerator.DefineGuid());
    public static readonly GuidTypeModel StaticConstGuid = new("GUID Struct Declaration", "StaticConstGuid", GuidGenerator.StaticConstGuid());
    public static readonly GuidTypeModel CppCxUwpGuid = new("C++/CX UWP GUID Declaration", "CppCxUwpGuid", GuidGenerator.CPlusPlusCxUwpGuid());
    public static readonly GuidTypeModel CSharpGuidAttribute = new("GuidAttribute (C#, Lowercase)", "GuidAttributeCSharp", GuidGenerator.GuidAttributeCSharp());
    public static readonly GuidTypeModel CSharpGuidAttributeUppercase = new("GuidAttribute (C#, Uppercase)", "GuidAttributeCSharpUpper", GuidGenerator.GuidAttributeCSharpCaps());
    public static readonly GuidTypeModel VisualBasicGuidAttribute = new("GuidAttribute (Visual Basic, Lowercase)", "GuidAttributeVB", GuidGenerator.GuidAttributeVisualBasic());
    public static readonly GuidTypeModel VisualBasicGuidAttributeUppercase = new("GuidAttribute (Visual Basic, Uppercase)", "GuidAttributeVBUpper", GuidGenerator.GuidAttributeVisualBasicCaps());

    public static ObservableCollection<GuidTypeModel> Shared { get; set; } = [];

    public static void PrepareShared()
    {
        Shared.Add(TextOnly);
        Shared.Add(TextOnlyWithCurlyBrackets);
        Shared.Add(ImplementOleCreate);
        Shared.Add(DefineGuid);
        Shared.Add(StaticConstGuid);
        Shared.Add(CppCxUwpGuid);
        Shared.Add(CSharpGuidAttribute);
        Shared.Add(CSharpGuidAttributeUppercase);
        Shared.Add(VisualBasicGuidAttribute);
        Shared.Add(VisualBasicGuidAttributeUppercase);
    }
}
