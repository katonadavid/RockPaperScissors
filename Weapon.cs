using System;

public enum WeaponType
{
    Rock,
    Paper,
    Scissors
}

public class Weapon
{
	public string Name { get; }
	public WeaponType Type { get; }
    public WeaponType Enemy {  get; }

    public Weapon(string name, WeaponType type, WeaponType enemy)
    {
        Name = name;
        Type = type;
        Enemy = enemy;
    }
}
