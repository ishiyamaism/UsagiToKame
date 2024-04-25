namespace UsagiToKame.States;

public sealed class UsagiState : IState
{
  private UsagiState() { }
  public static UsagiState Instance { get; } = new UsagiState();


  public void OnChange(StateContext stateContext)
  {
    stateContext.ChangeState(KameState.Instance);
  }

  public string GetStateText()
  {
    return "ウサギ";
  }

  public StateType GetStateType()
  {
    return StateType.Usagi;
  }
}
