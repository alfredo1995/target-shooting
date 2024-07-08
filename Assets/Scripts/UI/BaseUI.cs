using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    protected Canvas Canvas;

    protected virtual void Awake()
    {
        Canvas = GetComponent<Canvas>();
        Canvas.enabled = false;
    }

    public virtual void Enable()
    {
        Canvas.enabled = true;
    }

    public virtual void Disable()
    {
        Canvas.enabled = false;
    }

    protected void PlayButtonClickSFX()
    {
        GameManager.Instance.AudioManager.PlaySFX(SFX.ButtonClick);
    }
}
