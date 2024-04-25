using UsagiToKame.Objects;
using UsagiToKame.States;

namespace UsagiToKame;

class Program
{
    static private StateContext _stateContext = new StateContext();
    private static List<CharacterBase> _characters = new List<CharacterBase>();
    private static CharacterBase _selectedCharacter = Kame.Instance;

    static void Main(string[] args)
    {
        _stateContext.StateChanged += StateContext_StateChanged;

        Console.WriteLine("Press Enter to show their positions, ");
        Console.WriteLine("Tab Key to change the player, ");
        Console.WriteLine("RightArrow Key to move the player right");
        Console.WriteLine("Esc to exit.");

        _characters.Add(Kame.Instance);
        _characters.Add(Usagi.Instance);
        _characters.Add(Neko.Instance);
        _selectedCharacter = _characters[0];

        ShowWhichTurn();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);  // trueでキーのエコーをオフにする
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("bye.");
                break;
            }
            // Escキーでループを抜けてプログラムを終了

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    ShowPositions();
                    break;

                case ConsoleKey.Tab:
                    Console.WriteLine("Press: Tab");
                    _stateContext.Change();
                    break;

                case ConsoleKey.RightArrow:
                    Console.WriteLine("Press: →");
                    _selectedCharacter.Move();
                    break;

                case ConsoleKey.A:
                    Console.WriteLine("Press: A");
                    _selectedCharacter.AskedForResponse();
                    break;

                case ConsoleKey.D0:
                    Console.WriteLine("Press: 0");
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine("Press: 1");
                    break;

                default:
                    break;
            }


        }
    }

    // State Observer
    private static void StateContext_StateChanged()
    {
        _selectedCharacter = _selectedCharacter.Change();

        ShowWhichTurn();
    }

    private static void ShowWhichTurn()
    {
        Console.WriteLine($"{_stateContext.GetStateText()}のターン！");
    }

    private static void ShowPositions()
    {
        foreach (var charas in _characters)
        {
            string position = charas.MakePosition(charas.X);
            Console.WriteLine(position);
        }
    }
}
