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

    public string Name { get; set; } = "";
    public Reagents[] Reagents { get; set; } = Array.Empty<Reagents>();

    #endregion

    #region Constructor

    private Recipe() { }

    public Recipe(string name, params Reagents[] reagents)
    {
        Name = name;
        Reagents = (Reagents[])reagents.Clone();
    }

    #endregion

    #region Methods
    #endregion

    #region Virtual Methods

    public override SkillData Clone() => (SkillData)MemberwiseClone();

    #endregion
}
