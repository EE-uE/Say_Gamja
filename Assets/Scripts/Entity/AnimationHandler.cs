using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMovelf = Animator.StringToHash("IsMovelf");
    private static readonly int IsMoveback = Animator.StringToHash("IsMoveback");

    protected Animator animator;
    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public void Move(Vector2 movementDirection)
    {
        if (movementDirection.magnitude > 0)
        {
            // 좌우 이동 (IsMovelf 활성화)
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                animator.SetBool(IsMovelf, true);
                animator.SetBool(IsMoveback, false);
                spriteRenderer.flipX = movementDirection.x < 0; // 왼쪽이면 flipX 활성화
            }
            // 뒤로 이동 (IsMoveback 활성화)
            else if (movementDirection.y > 0)
            {
                animator.SetBool(IsMoveback, true);
                animator.SetBool(IsMovelf, false);
            }
            // 기본값 (앞으로 이동)
            else
            {
                animator.SetBool(IsMovelf, false);
                animator.SetBool(IsMoveback, false);
            }
        }
        else
        {
            // 모든 애니메이션 멈춤
            animator.SetBool(IsMovelf, false);
            animator.SetBool(IsMoveback, false);
        }
    }

    //public void Move(Vector2 obj)
    //{
    //    animator.SetBool(IsMovelf, obj.magnitude > .5f);
    //}
}
