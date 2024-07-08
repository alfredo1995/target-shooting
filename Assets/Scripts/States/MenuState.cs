using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    public override void OnStart(GameManager gameManager)
    {
        base.OnStart(gameManager);

        GameManager.UIManager.MenuUI.Enable();
    }

    public override void OnEnd()
    {
        base.OnEnd();

        GameManager.UIManager.MenuUI.Disable();
    }
}
