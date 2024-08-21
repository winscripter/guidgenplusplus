using System.Text;

namespace GuidGenPlusPlus;

internal static class GuidGenerator
{
    public static string Generate(string guidType)
    {
        return guidType switch
        {
            "TextOnly" => TextOnly(),
            "TextOnlyCB" => TextOnlyWithCurlyBraces(),
            "ImplementOleCreate" => ImplementOleCreate(),
            "DefineGuid" => DefineGuid(),
            "StaticConstGuid" => StaticConstGuid(),
            "CppCxUwpGuid" => CPlusPlusCxUwpGuid(),
            "GuidAttributeCSharp" => GuidAttributeCSharp(),
            "GuidAttributeCSharpUpper" => GuidAttributeCSharpCaps(),
            "GuidAttributeVB" => GuidAttributeVisualBasic(),
            "GuidAttributeVBUpper" => GuidAttributeVisualBasicCaps(),
            _ => "GUID type is unrecognized. Sorry!"
        };
    }

    public static string TextOnly()
    {
        return Guid.NewGuid().ToString();
    }

    public static string TextOnlyWithCurlyBraces()
    {
        var builder = new StringBuilder();
        builder.Append('{');
        builder.Append(Guid.NewGuid().ToString());
        builder.Append('}');
        return builder.ToString();
    }

    public static string ImplementOleCreate()
    {
        Guid guid = Guid.NewGuid();
        byte[] byteArray = guid.ToByteArray();

        var builder = new StringBuilder();
        builder.Append("IMPLEMENT_OLECREATE(class name, external name, ");
        
        builder.Append(MakeByteArrayBodyFast(byteArray));

        builder.Append(')');
        return builder.ToString();
    }

    public static string DefineGuid()
    {
        Guid guid = Guid.NewGuid();
        byte[] byteArray = guid.ToByteArray();

        var builder = new StringBuilder();
        builder.Append("DEFINE_GUID(name, ");

        builder.Append(MakeByteArrayBodyFast(byteArray));

        builder.Append(')');
        return builder.ToString();
    }

    public static string StaticConstGuid()
    {
        Guid guid = Guid.NewGuid();
        byte[] byteArray = guid.ToByteArray();

        var builder = new StringBuilder();
        builder.Append("static const struct GUID InsertNameHere = ");
        builder.Append(CPlusPlusGuidBody(byteArray));

        return builder.ToString();
    }

    private static string CPlusPlusGuidBody(byte[] byteArray)
    {
        var builder = new StringBuilder();

        builder.Append("{ ");
        
        builder.Append(ExtractFourBytes(byteArray));
        builder.Append(", ");

        builder.Append(ExtractTwoBytes(byteArray, 4));
        builder.Append(", ");
        builder.Append(ExtractTwoBytes(byteArray, 6));
        builder.Append(", { ");

        builder.Append("0x");
        builder.Append(byteArray[8].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[9].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[10].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[11].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[12].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[13].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[14].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[15].ToString("X"));
        builder.Append(" } };");

        return builder.ToString();
    }

    public static string CPlusPlusCxUwpGuid()
    {
        Guid guid = Guid.NewGuid();
        byte[] byteArray = guid.ToByteArray();

        var builder = new StringBuilder();
        builder.Append("Windows::Foundation::Guid InsertNameHere = ");
        builder.Append(CPlusPlusGuidBody(byteArray));

        return builder.ToString();
    }

    public static string GuidAttributeCSharp()
    {
        return $"[Guid(\"{Guid.NewGuid()}\")]";
    }

    public static string GuidAttributeCSharpCaps()
    {
        return $"[Guid(\"{Guid.NewGuid().ToString().ToUpperInvariant()}\")]";
    }

    public static string GuidAttributeVisualBasic()
    {
        return $"<Guid(\"{Guid.NewGuid()}\")>";
    }

    public static string GuidAttributeVisualBasicCaps()
    {
        return $"<Guid(\"{Guid.NewGuid().ToString().ToUpperInvariant()}\")>";
    }

    private static string ExtractFourBytes(byte[] byteArray, int startingAddress = 0)
    {
        var builder = new StringBuilder();
        builder.Append("0x");
        builder.Append(byteArray[0 + startingAddress].ToString("X"));
        builder.Append(byteArray[1 + startingAddress].ToString("X"));
        builder.Append(byteArray[2 + startingAddress].ToString("X"));
        builder.Append(byteArray[3 + startingAddress].ToString("X"));

        return builder.ToString();
    }

    private static string ExtractTwoBytes(byte[] byteArray, int startingAddress)
    {
        var builder = new StringBuilder();
        builder.Append("0x");
        builder.Append(byteArray[0 + startingAddress].ToString("X"));
        builder.Append(byteArray[1 + startingAddress].ToString("X"));

        return builder.ToString();
    }

    private static string MakeByteArrayBodyFast(byte[] byteArray)
    {
        var builder = new StringBuilder();
        builder.Append(ExtractFourBytes(byteArray));
        builder.Append(", ");
        builder.Append(ExtractTwoBytes(byteArray, 4));
        builder.Append(", ");
        builder.Append(ExtractTwoBytes(byteArray, 6));

        builder.Append(", 0x");
        builder.Append(byteArray[8].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[9].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[10].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[11].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[12].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[13].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[14].ToString("X"));
        builder.Append(", 0x");
        builder.Append(byteArray[15].ToString("X"));

        return builder.ToString();
    }
}
