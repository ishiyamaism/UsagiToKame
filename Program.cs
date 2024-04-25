using UsagiToKame.States;

namespace UsagiToKame;

class Program
{
    static private StateContext _stateContext = new StateContext();

    private static int _kameX = 1;
    private static int _kameCount = 0;
    private static int _usagiX = 1;
    private static int _usagiCount = 0;

    static void Main(string[] args)
    {
        _stateContext.StateChanged += StateContext_StateChanged;
        Console.WriteLine("Press Enter to show their positions, ");
        Console.WriteLine("Tab Key to change player, ");
        Console.WriteLine("RightArrow Key to move right");
        Console.WriteLine("Esc to exit.");

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
                    Move();
                    break;

                case ConsoleKey.A:
                    Console.WriteLine("Press: A");
                    Response();
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

    private static void ShowWhichTurn()
    {
        Console.WriteLine($"{_stateContext.GetStateText()}のターン！");
    }
    // State Observer
    private static void StateContext_StateChanged()
    {
        ShowWhichTurn();
    }

    private static void Move()
    {
        if (_stateContext.GetStateType() == StateType.Kame)
        {
            _kameX += 1;
            Console.WriteLine("かめ moved");
        }
        else if (_stateContext.GetStateType() == StateType.Usagi)
        {
            _usagiX += 3;
            Console.WriteLine("ウサギ moved");
        }
    }

    private static string MakeKamePosition(int x)
    {
        string pos = "";
        for (int i = 0; i <= x; i++)
        {
            pos += "■";
        }
        return pos;
    }
    private static string MakeUsagiPosition(int x)
    {
        string pos = "";
        for (int i = 0; i <= x; i++)
        {
            pos += "▲";
        }
        return pos;
    }
    private static void ShowPositions()
    {
        string kamePosition = MakeKamePosition(_kameX);
        Console.WriteLine(kamePosition);
        string usagiPosition = MakeUsagiPosition(_usagiX);
        Console.WriteLine(usagiPosition);
    }

    private static void Response()
    {
        if (_stateContext.GetStateType() == StateType.Kame)
        {
            _kameCount++;
            if (_kameCount >= 3)
            {
                Console.WriteLine("かめです");
                _kameCount = 0;
            }
        }

        if (_stateContext.GetStateType() == StateType.Usagi)
        {
            _usagiCount++;
            if (_usagiCount >= 5)
            {
                Console.WriteLine("ウサギです");
                _usagiCount = 0;
            }
        }
    }


}
