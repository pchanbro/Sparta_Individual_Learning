using System;
using UnityEngine;

public class RocketMovementC : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 10f;
    private readonly float ROTATIONSPEED = 0.02f;
    private Vector2 direction;

    private float highScore = -1;

    public static Action<float> OnHighScoreChanged;
    
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // [선택사항, 추후 구현]매 최고 높이 갱신마다 업적을 체크하는 로직은 과부하를 발생시킬 우려가 있습니다. 이를 개선할 방법을 제안하여 적용하세요.
        if (!(highScore < transform.position.y)) return;
        highScore = transform.position.y;
        OnHighScoreChanged?.Invoke(highScore);
    }

    public void ApplyMovement(float inputX)
    {
        Rotate(inputX);
        _rb2d.velocity = new Vector2(0, 2.5f * inputX);
    }

    public void ApplyBoost()
    {
        _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
    }

    private void Rotate(float inputX)
    {
        // 오브젝트가 회전하도록 한다.
    }
}