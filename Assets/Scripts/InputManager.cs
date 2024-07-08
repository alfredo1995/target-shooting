using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    public event Action OnShoot;

    public Vector2 Movement => Controls.Gameplay.Movement.ReadValue<Vector2>();

    private Controls Controls;

    public InputManager()
    {
        Controls = new Controls();
        Controls.Gameplay.Shoot.performed += ShootPerformed;
    }

    public void EnableGameplay()
    {
        Controls.Gameplay.Enable();
    }

    public void DisableGameplay()
    {
        Controls.Gameplay.Disable();
    }

    private void ShootPerformed(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }
}
