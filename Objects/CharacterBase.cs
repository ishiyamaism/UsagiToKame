namespace UsagiToKame.Objects;

public abstract class CharacterBase
{
  public int X { get; set; }
  public int Count { get; set; }

  public string? Position { get; private set; }


  public CharacterBase(int x)
  {
    X = X;
  }

  public abstract CharacterBase Change();

  public abstract void Move();
  public abstract string MakePosition(int x);

  public abstract void Response();

}
