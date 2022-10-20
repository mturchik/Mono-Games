namespace RpgLibrary.SkillClasses;
public struct Reagents
{
    #region Fields

    public string ReagentName;
    public ushort AmountRequired;

    #endregion

    #region Constructor Region

    public Reagents(string reagent, ushort number)
    {
        ReagentName = reagent;
        AmountRequired = number;
    }

    #endregion

    #region Methods
    #endregion
}
public class Recipe : BaseData
{

    #region Fields and Properties

    public Reagents[] Reagents { get; set; } = Array.Empty<Reagents>();

    #endregion

    #region Constructor

    private Recipe() { }

    public Recipe(string name, params Reagents[] reagents)
    {
        Name = name;
        var list = new List<Reagents>();
        foreach (var reagent in reagents) list.Add(reagent);
        Reagents = list.ToArray();
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override Recipe Clone()
    {
        var reagents = new List<Reagents>();
        foreach (var reagent in Reagents) reagents.Add(reagent);
        return new()
        {
            Id = Id,
            Name = Name,
            Reagents = reagents.ToArray()
        };
    }

    #endregion
}
