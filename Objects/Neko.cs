namespace UsagiToKame.Objects;

public sealed class Neko : CharacterBase
{
  // シングルトン
  private Neko() : base(0) { }
  public static Neko Instance { get; } = new Neko();


  public override CharacterBase Change()
  {
    return Kame.Instance;
  }
  public override void Move()
  {
    // ねこはランダムに動く
    Random r1 = new Random();
    X += r1.Next(0, 7);
    Console.WriteLine("ねこ moved");
  }

  public override string MakePosition(int x)
  {
    string pos = "";
    for (int i = 0; i <= x; i++)
    {
      pos += "🐱";
    }
    return $"{(X + 1).ToString("D3")}:{pos}";
  }

  public override void AskedForResponse()
  {
    Count++;
    if (Count >= 10)
    {
      Console.WriteLine("にゃーん");
      Count = 0;
    }
  }
}
