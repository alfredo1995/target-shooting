using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Transform Pivot;
    [SerializeField] private Transform ShotOrigin;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float ShootForce;
    [SerializeField] private float CooldownDuration;

    private Pool<CannonBall> Pool;
    private bool IsCoolingDown;
    private float Cooldown;

    private const int POOL_INITIAL_SIZE = 10;

    private void Start()
    {
        GameManager.Instance.InputManager.OnShoot += OnShoot;
        Pool = new Pool<CannonBall>(Paths.CannonBallPrefab, POOL_INITIAL_SIZE);
    }

    private void Update()
    {
        Rotate();

        if (IsCoolingDown)
        {
            Cooldown -= Time.deltaTime;

            if (Cooldown <= 0)
            {
                IsCoolingDown = false;
            }
        }
    }

    public void ResetRotation()
    {
        Pivot.localRotation = Quaternion.identity;
    }

    private void Rotate()
    {
        Vector2 movement = GameManager.Instance.InputManager.Movement;
        float speed = RotationSpeed * Time.deltaTime;
        Pivot.Rotate(movement.y * speed, 0, 0, Space.Self);
        Pivot.Rotate(0, movement.x * speed, 0, Space.World);
    }

    private void OnShoot()
    {
        if (IsCoolingDown) return;

        CannonBall cannonBall = Pool.Rent();
        cannonBall.transform.SetPositionAndRotation(ShotOrigin.position, Quaternion.identity);
        cannonBall.Shoot(ShootForce * ShotOrigin.forward, CannonBallCallback);
        GameManager.Instance.AudioManager.PlaySFX(SFX.Shot);

        IsCoolingDown = true;
        Cooldown = CooldownDuration;
    }

    private void CannonBallCallback(CannonBall cannonBall)
    {
        Pool.Return(cannonBall);
    }

    private void OnDestroy()
    {
        GameManager.Instance.InputManager.OnShoot -= OnShoot;
    }
}
