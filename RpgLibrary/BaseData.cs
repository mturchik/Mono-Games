
namespace RpgLibrary;
public abstract class BaseData
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BaseData() { }
    public abstract object Clone();

    public override string ToString()
    {
        var properties = GetType().GetProperties();
        var values = properties.Select(p =>
        {
            var value = typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                ? string.Join("|", p.GetValue(this)?.ToString())
                : p.GetValue(this)?.ToString();
            return $"{p.Name}: {value}";
        });
        return string.Join(", ", values);
    }

}