using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : BaseState
{
    public override void OnStart(GameManager gameManager)
    {
        base.OnStart(gameManager);

        GameManager.AudioManager.PlaySFX(SFX.EndGame);
        GameManager.UIManager.EndGameUI.Enable(GameManager.ScoreManager.Score);
    }

    public override void OnEnd()
    {
        base.OnEnd();

        GameManager.UIManager.EndGameUI.Disable();
    }
}
