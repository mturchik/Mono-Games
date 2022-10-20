namespace RpgLibrary;
public class RolePlayingGame : BaseData
{
    [Required, StringLength(500, MinimumLength = 3)]
    public string Description { get; set; } = "";
    public override RolePlayingGame Clone()
    {
        return new()
        {
            Id = Id,
            Name = Name,
            Description = Description,
        };
    }
}
