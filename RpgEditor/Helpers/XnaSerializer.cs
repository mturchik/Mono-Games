using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System.Xml;

namespace RpgEditor.Helpers;
public static class XnaSerializer
{
    public static void Serialize<T>(string filename, T data)
    {
        using XmlWriter writer = XmlWriter.Create(filename, new() { Indent = true });
        IntermediateSerializer.Serialize<T>(writer, data, null);
    }

    public static T Deserialize<T>(string filename)
    {
        using FileStream stream = new(filename, FileMode.Open);
        using XmlReader reader = XmlReader.Create(stream);
        return IntermediateSerializer.Deserialize<T>(reader, null);
    }
}
