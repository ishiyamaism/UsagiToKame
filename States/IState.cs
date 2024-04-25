namespace UsagiToKame.States;

// 状態を同一視するためのインターフェース
public interface IState
{
  void OnChange(StateContext talkStateMachine);

  string GetStateText();
  StateType GetStateType();
}
