using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UIManager UIManager;
    public AudioManager AudioManager;
    public CannonController CannonController;

    public InputManager InputManager { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        Instance = this;
        InputManager = new();
        ScoreManager = new();
        StateMachine = new(this);
    }

    private void Start()
    {
        StateMachine.TransitionTo<MenuState>();
    }

    private void Update()
    {
        StateMachine.OnTick();
    }
}
