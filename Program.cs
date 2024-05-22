namespace RockPaperScissors;

class Program
{
    static TerminalSelect<Weapon> terminalSelect =
            new(BattleHelper.weapons.Select(w => new Option<Weapon>(w.Name, w)).ToList(), "Choose your weapon!");

    static void Main(string[] args)
    {
        terminalSelect.OnOptionSelected += (Weapon selectedWeapon) =>
        {
            var computerWeapon = BattleHelper.GetComputerWeapon();
            Console.WriteLine($"\nYou've chosen {selectedWeapon.Name}");
            Console.WriteLine($"The computer has chosen {computerWeapon.Name}\n");

            PrintResult(BattleHelper.Fight(selectedWeapon, computerWeapon));
            AskForReplay();
        };
        terminalSelect.PromptSelection();
    }

    static void AskForReplay()
    {
        Console.WriteLine("Play again? [Enter = Yes, Esc = No]");

        ConsoleKeyInfo answer;

        do
        {
            answer = Console.ReadKey(true);
            if (answer.Key == ConsoleKey.Enter)
            {
                terminalSelect.PromptSelection();
            }
            if (answer.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Goodbye! :)");
            }
        }
        while (answer.Key != ConsoleKey.Enter && answer.Key != ConsoleKey.Escape);

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
