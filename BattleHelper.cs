
public enum BattleResult
{
    Win,
    Lose,
    Draw
}

public static class BattleHelper
{
    public static List<Weapon> weapons = new List<Weapon>
    {
        new Weapon("Rock", WeaponType.Rock, WeaponType.Paper),
        new Weapon("Paper", WeaponType.Paper, WeaponType.Scissors),
        new Weapon("Scissors", WeaponType.Scissors, WeaponType.Rock),
    };

    public static Weapon GetComputerWeapon()
    {
        return weapons[new Random().Next(0, 2)];
    }

    public static BattleResult Fight(Weapon userWeapon, Weapon computerWeapon)
    {        
        if (userWeapon.Type == computerWeapon.Type)
        {
            return BattleResult.Draw;
        }

        return userWeapon.Enemy == computerWeapon.Type ? BattleResult.Lose : BattleResult.Win;
    }


}
