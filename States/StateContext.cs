namespace UsagiToKame.States;
public sealed class StateContext
{
  private IState _state = KameState.Instance;
  public void Change()
  {

    // 状態を変える
    _state.OnChange(this);

  }

  public string GetStateText()
  {
    return _state.GetStateText();
  }

  public StateType GetStateType()
  {
    return _state.GetStateType();
  }

  public event Action? StateChanged;
  internal void ChangeState(IState state)
  {
    _state = state;
    // State変更時にクライアントに通知
    StateChanged?.Invoke();
  }
}

public enum StateType
{
  Kame,
  Usagi,
}
