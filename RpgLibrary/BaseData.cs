namespace RpgLibrary;
public abstract class BaseData
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BaseData() { }
    public override string ToString() => string.Join(", ", GetType().GetProperties().Select(p => $"{p.Name} = {p.GetValue(this)}"));
    public abstract object Clone();
}