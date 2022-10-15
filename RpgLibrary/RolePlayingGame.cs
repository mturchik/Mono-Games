namespace RpgLibrary;
public class RolePlayingGame : BaseData
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Name = "";
    [Required, StringLength(500, MinimumLength = 3)]
    public string Description = "";
    public override RolePlayingGame Clone() => (RolePlayingGame)MemberwiseClone();
}
