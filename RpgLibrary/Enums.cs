namespace RpgLibrary;
#region CharacterClasses
public enum EntityType { Character, NPC, Monster, Creature }
public enum EntityGender { Unknown, Male, Female, NonBinary }
#endregion
#region ItemClasses
public enum WeaponHands { Main, Off, Both }
public enum ArmorLocation { Body, Head, Hands, Feet }
#endregion
#region SkillClasses
public enum DifficultyLevel
{
    Master = -50,
    Expert = -25,
    Improved = -10,
    Normal = 0,
    Easy = 25,
}
#endregion
public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100 }