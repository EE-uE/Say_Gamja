using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 가져올 도구 및 컴포넌트
    Animator animator;
    Rigidbody2D _rigidbody; // 상위에 클래스 이름이 있으니 언더바 붙여줌

    public float flapForce = 6f; // 점프하는힘
    public float forwardSpeed = 3f; // 정면으로 이동하는힘
    public bool isDead = false; // 죽었는지 살았는지 구분
    float deathCooldown = 0f; // 바로 충돌하자마자 죽게 말고 딜레이 시간 있게

    bool isFlap = false; // 점프를 뛰었는지 안뛰었는지 구분

    public bool godMode = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        // GetComponentInChildren = 자식 컴포넌트까지 확인함
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        // 예외처리, 애니메이터, 리기드바디가 널인경우
        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // 죽었을때와 죽지 않았을때, isDead를 기준으로
    //    if (isDead)
    //    {
    //        // 게임 재시작, 클릭을하면 게임재시작 할수있게
    //        if (deathCooldown <= 0)
    //        {
    //            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    //            {
    //                gameManager.RestartGame();
    //            }
    //        }
    //        else
    //        {
    //            // deltaTime; : 이전프레임과 현재프레임의 사이
    //            deathCooldown -= Time.deltaTime;
    //        }
    //    }
    //    else
    //    {
    //        // if(Input.GetKeyDown(KeyCode.사용할 키)
    //        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    //        {
    //            isFlap = true;
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (isDead)
    //        return;

    //    Vector3 velocity = _rigidbody.velocity;
    //    velocity.x = forwardSpeed;

    //    if (isFlap)
    //    {
    //        velocity.y += flapForce;
    //        isFlap = false;
    //    }

    //    _rigidbody.velocity = velocity;

    //    float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
    //    float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
    //    transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    //}

    //// 바닥이나 천장과 닿았을 때 죽게하기 위한것
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (godMode) return;

    //    if (isDead) return;

    //    isDead = true;
    //    deathCooldown = 1f;

    //    // 애니메이터에 만들어놨던 파라미터 값을 1로 만들어줌
    //    animator.SetInteger("isdie", 1);
    //    //gameManager.GameOver();
    //}
}
