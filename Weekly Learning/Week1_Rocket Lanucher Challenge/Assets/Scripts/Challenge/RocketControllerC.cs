using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 0.5f;
    private readonly float ENERGY_BURST = 2f;

    private float doubleTapTime;
    private float lastTapTime;


    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();

        _movementDirection = 0f;

        doubleTapTime = 0.2f;
        lastTapTime = 0f;
    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;
        
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        _rocketMovement.ApplyMovement(_movementDirection); // 방향을 정해준다.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Input Action을 활용해봐라
        {
            if (_energySystem.UseEnergy(ENERGY_TURN))
            {
                Move();
            }

            if(Time.time- lastTapTime < doubleTapTime)
            {
                if (_energySystem.UseEnergy(ENERGY_BURST))
                {
                    Boost();
                }
            }

            lastTapTime = Time.time;
            Debug.Log(lastTapTime);
        }
        else
        {
            _movementDirection = -0.5f;
        }
    }

    private void Move()
    {
        _movementDirection = 2.0f;
    }

    private void Boost()
    {
        _rocketMovement.ApplyBoost();
    }

    private void OnMove(InputValue value)
    {
        float dir = value.Get<float>();
        _isMoving = Mathf.Abs(dir) >= 0.1f;
        _movementDirection = dir;
    }

    private void OnBoost(InputValue value)
    {
        if (!_energySystem.UseEnergy(ENERGY_BURST)) return;
        _rocketMovement.ApplyBoost();
    }
}