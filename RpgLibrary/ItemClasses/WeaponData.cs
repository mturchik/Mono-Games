﻿namespace RpgLibrary.ItemClasses;

public class WeaponData
{
    public string Name = "";
    public string Type = "";
    public int Price;
    public float Weight;
    public bool Equipped;
    public Hands NumberHands;
    public int AttackValue;
    public int AttackModifier;
    public int DamageValue;
    public int DamageModifier;
    public string[] AllowableClasses = Array.Empty<string>();
}
