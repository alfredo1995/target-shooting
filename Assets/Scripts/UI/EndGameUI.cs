using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Button ButtonMenu;
    [SerializeField] private Button ButtonRestart;
    [SerializeField] private Button ButtonQuit;

    protected override void Awake()
    {
        base.Awake();

        ButtonMenu.onClick.AddListener(OnButtonMenuClicked);
        ButtonRestart.onClick.AddListener(OnButtonRestartClicked);
        ButtonQuit.onClick.AddListener(OnButtonQuitClicked);
    }

    public void Enable(int score)
    {
        base.Enable();

        ScoreText.text = $"Score: {score}";
    }

    private void OnButtonMenuClicked()
    {
        PlayButtonClickSFX();
        GameManager.Instance.StateMachine.TransitionTo<MenuState>();
    }

    private void OnButtonRestartClicked()
    {
        PlayButtonClickSFX();
        GameManager.Instance.StateMachine.TransitionTo<GameplayState>();
    }

    private void OnButtonQuitClicked()
    {
        PlayButtonClickSFX();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
