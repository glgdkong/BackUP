using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : DirectionHorizontalMovement
{
    [SerializeField] private bool isGrounded; // �ٴ� ���� ����
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    [SerializeField] private Transform groundCheck; // �ٴ� ���� ��ġ
    [SerializeField] private float groundCheckRadius;   // �ٴ� üũ ����
    [SerializeField] private LayerMask groundLayer; // �ٴ� ���̾�

    [SerializeField] private int jumpsRemaining;    // ���� ���� Ƚ��
    private bool jumpRequested; // ���� ��û�� ������ �÷���
    [SerializeField] private int maxJumps; // �ִ� ���� Ƚ��

    [SerializeField] private float jumpForce;   // ���� ��


    // Start is called before the first frame update
    void Start()
    {
        // ������ �� �ִ� ���� Ƚ�� ����
        jumpsRemaining = maxJumps;
    }

    protected override void Move()
    {
        // * Collider �浹�ݶ��̴����� = Physics2D.OverlapCircle(�浹üũ��ġ, �浹üũũ��, �浹���̾�);
        // ĳ���� �ٴ� ���� ���θ� üũ��
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // ���� Ű�Է°� ����
        float moveInput = Input.GetAxisRaw("Horizontal");

        // * float ���밪 = Mathf.Abs(����/���);
        // * AnimatorSetFloat("�ִϸ������Ķ���͸�", ������);
        animator.SetFloat("Move", Mathf.Abs(moveInput));

        // ĳ���� ���� ��ȯ
        // - ĳ���Ͱ� �������� ���� �ִµ� Ű�� ������ �����ٸ� -> ����
        if((IsRight && moveInput < 0f) || (!IsRight && moveInput > 0f))
        {
            Flip();
        }

        // �÷��̾� �̵� ó��
        rigidbody2D.velocity = new Vector2(moveInput * MoveSpeed, rigidbody2D.velocity.y);


        // �ٴ� ���� �� ���� Ƚ�� �ʱ�ȭ
        if(IsGrounded)
        {
            jumpsRemaining = maxJumps;
        }


        // �ٴ� ���� ���� �ִϸ��̼� �Ķ���� ����
        animator.SetBool("IsGround", IsGrounded);
        // ���� ���/�ϰ� ���� �ִϸ��̼� �Ķ���� ����
        animator.SetFloat("Vertical", rigidbody2D.velocity.y);

        // ���� Ű �Է� ó��
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            // ���� ���� ��û �÷��� ���� ����
            jumpRequested = true;   
        }
        
    }

    private void FixedUpdate()
    {
       // ���� ��û ���¸�
       if(jumpRequested)
        {
            // ���� ��� ó����
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            // ���� ���� Ƚ�� ����
            jumpsRemaining--;
            // ���� �ִϸ��̼� ���
            animator.SetTrigger("Jump");
            // ���� ��û ����
            jumpRequested = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { transform.parent = null; }
    }
}
