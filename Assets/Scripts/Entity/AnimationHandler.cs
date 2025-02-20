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
            // �¿� �̵� (IsMovelf Ȱ��ȭ)
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                animator.SetBool(IsMovelf, true);
                animator.SetBool(IsMoveback, false);
                spriteRenderer.flipX = movementDirection.x < 0; // �����̸� flipX Ȱ��ȭ
            }
            // �ڷ� �̵� (IsMoveback Ȱ��ȭ)
            else if (movementDirection.y > 0)
            {
                animator.SetBool(IsMoveback, true);
                animator.SetBool(IsMovelf, false);
            }
            // �⺻�� (������ �̵�)
            else
            {
                animator.SetBool(IsMovelf, false);
                animator.SetBool(IsMoveback, false);
            }
        }
        else
        {
            // ��� �ִϸ��̼� ����
            animator.SetBool(IsMovelf, false);
            animator.SetBool(IsMoveback, false);
        }
    }

    //public void Move(Vector2 obj)
    //{
    //    animator.SetBool(IsMovelf, obj.magnitude > .5f);
    //}
}
