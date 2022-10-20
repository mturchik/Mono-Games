namespace RpgEditor.Helpers;

public class GameDataSet<T> where T : BaseData
{
    private readonly DirectoryInfo _directory;
    private Dictionary<string, T>? _data;
    private Dictionary<string, T> Data
    {
        get
        {
            if (_data == null)
            {
                _data = new();
                foreach (var file in _directory.GetFiles())
                {
                    var data = XnaSerializer.Deserialize<T>(file.FullName);
                    var added = _data.TryAdd(data.Id, data);
                    if (!added) throw new ApplicationException("Failed to add data to dictionary");
                }
            }
            return _data;
        }
    }

    public GameDataSet(DirectoryInfo directory)
    {
        _directory = directory;
    }

    public string DirectoryPath() => _directory.FullName;

    public IQueryable<T> Queryable() => Data.Values.AsQueryable();

    public T? Get(string id) => Data.GetValueOrDefault(id);

    public void Upsert(T data)
    {
        XnaSerializer.Serialize($"{DirectoryPath()}\\{data.FormatFileName()}.xml", data);
        Data[data.Id] = data;
    }

    public void Delete(T data)
    {
        if (File.Exists($"{DirectoryPath()}\\{data.FormatFileName()}.xml"))
            File.Delete($"{DirectoryPath()}\\{data.FormatFileName()}.xml");
        Data.Remove(data.Id);
    }
}