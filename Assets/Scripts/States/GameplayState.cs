using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : BaseState
{
    private float TimeRemaining;

    private const float TIME_DURATION = 40;

    public override void OnStart(GameManager gameManager)
    {
        base.OnStart(gameManager);

        TimeRemaining = TIME_DURATION;

        GameManager.ScoreManager.ResetScore();
        GameManager.CannonController.ResetRotation();

        GameManager.UIManager.GameplayUI.Enable();
        GameManager.UIManager.GameplayUI.SetTimer(TimeRemaining);
        GameManager.UIManager.GameplayUI.SetScore(0);

        GameManager.InputManager.EnableGameplay();
    }

    public override void OnTick()
    {
        base.OnTick();

        TimeRemaining -= Time.deltaTime;
        GameManager.UIManager.GameplayUI.SetTimer(TimeRemaining);
        GameManager.UIManager.GameplayUI.SetScore(GameManager.ScoreManager.Score);

        if (TimeRemaining <= 0)
        {
            GameManager.StateMachine.TransitionTo<EndGameState>();
        }
    }

    public override void OnEnd()
    {
        base.OnEnd();

        GameManager.ScoreManager.UpdateScoreboard();
        GameManager.UIManager.GameplayUI.Disable();
        GameManager.InputManager.DisableGameplay();
    }
}
