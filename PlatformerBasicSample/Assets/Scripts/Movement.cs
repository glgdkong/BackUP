using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ���� �̵� Ŭ����
public abstract class Movement : MonoBehaviour
{
    // ��������Ʈ ������ ������Ʈ
    protected SpriteRenderer spriteRenderer;

    // ������ �ٵ� ������Ʈ
    protected new Rigidbody2D rigidbody2D;

    // �ִϸ����� ������Ʈ
    protected Animator animator;

   
    // �̵� ����
    [SerializeField] private Vector2 moveDirection;
    public Vector2 MoveDirection { get => moveDirection; set => moveDirection = value; }
    
    // �̵� �ӵ�
    [SerializeField] protected float moveSpeed;

    // Read / Write
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Read
    // public float MoveSpeed => moveSpeed;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // �̵� ó�� �߻� �޼ҵ�
    protected abstract void Move();


}
