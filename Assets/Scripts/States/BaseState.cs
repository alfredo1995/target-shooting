public interface IState
{
    void OnStart(GameManager gameManager);
    void OnTick();
    void OnEnd();
}

public abstract class BaseState : IState
{
    protected GameManager GameManager;

    public virtual void OnStart(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    public virtual void OnTick()
    {
    }

    public virtual void OnEnd()
    {
    }
}
