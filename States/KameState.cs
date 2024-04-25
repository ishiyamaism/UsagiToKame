namespace UsagiToKame.States;

public sealed class KameState : IState
{
  private KameState() { }
  public static KameState Instance { get; } = new KameState();


  public void OnChange(StateContext stateContext)
  {
    stateContext.ChangeState(UsagiState.Instance);
  }

  public string GetStateText()
  {
    return "かめ";
  }

  public StateType GetStateType()
  {
    return StateType.Kame;
  }


}
