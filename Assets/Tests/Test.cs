using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    private InputManager InputManager;

    void Start()
    {
        InputManager = new InputManager();
        InputManager.OnShoot += Shoot;
    }

    private void Shoot()
    {
        Debug.Log("SHOOT");
    }

    void Update()
    {
        Debug.Log(InputManager.Movement);
    }
}
