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
        
        _rocketMovement.ApplyMovement(_movementDirection); // ������ �����ش�.
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
        // _rocketMovement�� ������ �����δ� 

        /* �̰� Ȱ���غ���
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
        // Atan2�� �����ﰢ���� �ִٰ� �� �� ���ΰ� y, ���ΰ� x�� �� �� ������ ���� [-Pi,Pi]�� ��Ÿ���� �Լ���
        // ������ -Pi�� -180��, Pi�� 180�� �̹Ƿ� Mathf.Rad2Deg�� �� 57.29�� (180 / 3.14)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // [1. ĳ���� ������]
        // �̶� ������ ������(1,0 ����)�� 0���̹Ƿ�,
        // -90~90�������� �������� �ٶ󺸴� �� ������, -90�� �̸� 90�� �ʰ���� ������ �ٶ󺸴� ����.
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
         */
    }


    private void OnBoost()
    {

    }
}