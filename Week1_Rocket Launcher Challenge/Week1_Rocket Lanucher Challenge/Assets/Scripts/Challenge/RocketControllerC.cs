using UnityEngine;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 0.5f;
    private readonly float ENERGY_BURST = 2f;

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();
    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;
        
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        _rocketMovement.ApplyMovement(_movementDirection); // 방향을 정해준다.
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            OnMove();
        }
    }

    private void OnMove()
    {
        // _rocketMovement를 가지고 움직인다 

        /* 이걸 활용해보자
         * public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if( newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

        private void RotateArm(Vector2 direction)
    {
        // Atan2는 직각삼각형이 있다고 할 때 세로가 y, 가로가 x일 때 그 각도를 라디안 [-Pi,Pi]로 나타내는 함수임
        // 라디안의 -Pi는 -180도, Pi는 180도 이므로 Mathf.Rad2Deg는 약 57.29임 (180 / 3.14)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // [1. 캐릭터 뒤집기]
        // 이때 각도는 오른쪽(1,0 방향)이 0도이므로,
        // -90~90도에서는 오른쪽을 바라보는 게 맞지만, -90도 미만 90도 초과라면 왼쪽을 바라보는 것임.
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
         */
    }


    private void OnBoost()
    {

    }
}