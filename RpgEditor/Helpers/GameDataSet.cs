namespace RpgEditor.Helpers;

public class GameDataSet<T> where T : BaseData
{
    private readonly DirectoryInfo _directory;
    private readonly Dictionary<string, T> _data = new();

    public GameDataSet(DirectoryInfo directory)
    {
        _directory = directory;
        foreach (var file in _directory.GetFiles())
        {
            var data = XnaSerializer.Deserialize<T>(file.FullName);
            _data.Add(data.Id, data);
        }
    }

    public string DirectoryPath() => _directory.FullName;

    public IQueryable<T> Queryable() => _data.Values.AsQueryable();

    public T? Get(string id) => _data.GetValueOrDefault(id);

    public void Upsert(T data)
    {
        XnaSerializer.Serialize($"{DirectoryPath()}\\{data.Id}.xml", data);
        _data[data.Id] = data;
    }

    public void Delete(T data)
    {
        if (File.Exists($"{DirectoryPath()}\\{data.Id}.xml"))
            File.Delete($"{DirectoryPath()}\\{data.Id}.xml");
        _data.Remove(data.Id);
    }
}