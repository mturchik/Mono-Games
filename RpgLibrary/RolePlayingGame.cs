namespace RpgLibrary;
public class RolePlayingGame
{
    #region Fields and Properties

    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    #endregion

    #region Constructor Region

    private RolePlayingGame() { }

    public RolePlayingGame(string name, string description)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
    }

    #endregion
}
