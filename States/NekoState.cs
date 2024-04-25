namespace UsagiToKame.States;

public sealed class NekoState : IState
{
  private NekoState() { }
  public static NekoState Instance { get; } = new NekoState();


  public void OnChange(StateContext stateContext)
  {
    stateContext.ChangeState(KameState.Instance);
  }

  public string GetStateText()
  {
    return "ねこ";
  }

  public StateType GetStateType()
  {
    return StateType.Neko;
  }


}
