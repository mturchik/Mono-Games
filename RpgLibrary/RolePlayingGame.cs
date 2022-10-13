namespace RpgLibrary;
public class RolePlayingGame
{
    #region Fields and Properties

    public string Name { get; set; }
    public string Description { get; set; }

    #endregion

    #region Constructor Region

    private RolePlayingGame() { }

    public RolePlayingGame(string name, string description)
    {
        Name = name;
        Description = description;
    }

    #endregion
}
