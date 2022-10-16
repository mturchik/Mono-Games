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
            var value = "";
            if (typeof(IEnumerable).IsAssignableFrom(p.PropertyType))
                value = string.Join("|", p.GetValue(this)?.ToString());
            else if (typeof(IDictionary).IsAssignableFrom(p.PropertyType))
            {
                var dictionary = (IDictionary?)p.GetValue(this);
                var values = new List<string>();
                if (dictionary != null)
                    foreach (var keyObj in dictionary.Keys)
                        if (keyObj != null) value += $"{keyObj}\\{dictionary[keyObj]?.ToString()}";
                value = string.Join("|", values);
            }
            else
                value = p.GetValue(this)?.ToString();
            return $"{p.Name}: {value}";
        });
        return string.Join(", ", values);
    }

}