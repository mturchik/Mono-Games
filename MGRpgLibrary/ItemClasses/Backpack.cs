namespace MGRpgLibrary.ItemClasses;
public class Backpack
{
    #region Fields and Properties

    public List<GameItem> Items { get; } = new();
    public int Capacity => Items.Count;

    #endregion

    #region Constructor Region

    public Backpack() { }

    #endregion

    #region Method Region

    public void AddItem(GameItem gameItem) => Items.Add(gameItem);

    public void RemoveItem(GameItem gameItem) => Items.Remove(gameItem);

    #endregion

    #region Virtual Method region
    #endregion
}
