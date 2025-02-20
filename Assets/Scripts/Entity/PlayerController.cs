using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : BaseController
{
    [SerializeField] private float moveSpeed = 5f;

    private GameManager gameManager;
    private Camera camera;
    protected Animator animator;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }

    protected override void Start()
    {
        base.Start();
        if (camera == null) camera = Camera.main; // 기본적으로 카메라 설정
    }

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 movement = movementDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        if (horizontal != 0) 
        {
            Vector3 scale = transform.localScale;

            scale.x = Mathf.Sign(horizontal);
            transform.localScale = scale;
        }
    }
}
