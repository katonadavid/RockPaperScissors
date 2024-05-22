namespace RockPaperScissors;

class Program
{
    static void Main(string[] args)
    {
        TerminalSelect<Weapon> terminalSelect = new(BattleHelper.weapons.Select(w => new Option<Weapon>(w.Name, w)).ToArray());
        var weaponChosen = false;

        while (!weaponChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose your weapon! \n");
            terminalSelect.ListOptions();
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    terminalSelect.SelectNext();
                    break;
                case ConsoleKey.UpArrow:
                    terminalSelect.SelectPrevious();
                    break;
                case ConsoleKey.Enter:
                    weaponChosen = true;

                    var userWeapon = terminalSelect.GetSelectedOption().Value;
                    var computerWeapon = BattleHelper.GetComputerWeapon();
                    Console.WriteLine($"\nYou've chosen {userWeapon.Name}");
                    Console.WriteLine($"The computer has chosen {computerWeapon.Name}\n");

                    PrintResult(BattleHelper.Fight(userWeapon, computerWeapon));
                    break;
            }
        }
    }

    static void PrintResult(BattleResult battleResult)
    {
        switch (battleResult)
        {
            case BattleResult.Win:
                Console.WriteLine("You WON! :D");
                break;
            case BattleResult.Lose:
                Console.WriteLine("You LOST! :(");
                break;
            case BattleResult.Draw:
                Console.WriteLine("It's a DRAW :|");
                break;
        }

    }
}
