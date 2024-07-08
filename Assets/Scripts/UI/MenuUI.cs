using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : BaseUI
{
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button ButtonQuit;
    [SerializeField] private TextMeshProUGUI Scoreboard;

    protected override void Awake()
    {
        base.Awake();

        ButtonPlay.onClick.AddListener(OnButtonPlayClicked);
        ButtonQuit.onClick.AddListener(OnButtonQuitClicked);
    }

    public override void Enable()
    {
        Scoreboard.text = string.Empty;
        List<int> scoreboard = GameManager.Instance.ScoreManager.Scoreboard;

        for (int i = 0; i < scoreboard.Count; i++)
        {
            Scoreboard.text += $"{i + 1}. {scoreboard[i]}\n";
        }

        base.Enable();
    }

    private void OnButtonPlayClicked()
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
