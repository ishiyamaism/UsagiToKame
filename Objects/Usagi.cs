namespace UsagiToKame.Objects;

public sealed class Usagi : CharacterBase
{
  // シングルトン
  private Usagi() : base(0) { }
  public static Usagi Instance { get; } = new Usagi();


  public override CharacterBase Change()
  {
    return Kame.Instance;
  }
  public override void Move()
  {
    X += 3;
    Console.WriteLine("ウサギ moved");
  }

  public override string MakePosition(int x)
  {
    string pos = "";
    for (int i = 0; i <= x; i++)
    {
      pos += "▲";
    }
    return $"{(X + 1).ToString("D3")}:{pos}";
  }

  public override void AskedForResponse()
  {
    Count++;
    if (Count >= 5)
    {
      Console.WriteLine("ウサギです");
      Count = 0;
    }
  }
}
