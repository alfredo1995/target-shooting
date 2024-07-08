public class StateMachine
{
    private GameManager GameManager;

    public IState CurrentState { get; private set; }

    public StateMachine(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    public void TransitionTo<T>() where T: IState, new()
    {
        CurrentState?.OnEnd();
        CurrentState = new T();
        CurrentState.OnStart(GameManager);
    }

    public void OnTick()
    {
        CurrentState?.OnTick();
    }
}
