namespace RpgEditor.Helpers;
public static class Extensions
{
    public static string FormatFileName<T>(this T data) where T : BaseData
        => data.Name.Trim().Replace(' ', '_');
}
