using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI TimerText;

    public void SetScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void SetTimer(float time)
    {
        int timeMs = Mathf.CeilToInt(time) * 1000;
        TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, timeMs);
        TimerText.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }
}
