namespace UsagiToKame.Objects;

public sealed class Kame : CharacterBase
{
  private Kame() : base(0) { }
  public static Kame Instance { get; } = new Kame();

  public override CharacterBase Change()
  {
    return Usagi.Instance;
  }
  public override void Move()
  {
    int shift = 1;
    X += shift;
    Console.WriteLine($"かめ moved {shift}");
  }
  public override string MakePosition(int x)
  {
    string pos = "";
    for (int i = 0; i <= x; i++)
    {
      pos += "🐢";
    }
    return $"{(X + 1).ToString("D3")}:{pos}";
  }

  public override void AskedForResponse()
  {
    Count++;
    if (Count >= 2)
    {
      Console.WriteLine("かめです");
      Count = 0;
    }
  }
}
