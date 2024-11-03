using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxisJumpMovement : MonoBehaviour
{
    // ĳ���� ��Ʈ�ѷ�
    [SerializeField] private CharacterController controller;
    
    // �ִϸ�����
    [SerializeField] private Animator animator;
    
    // �̵� �ӵ�
    [SerializeField] private float moveSpeed;
    
    // �̵� ����
    [SerializeField] private Vector3 moveDirection;
    
    // �����ӵ�
    [SerializeField] private float jumpSpeed;
    
    // �ٴ� ���� ����
    [SerializeField] private bool isGrounded;
    
    // ���� ��ȿ Ÿ�̸�
    private float groundTimer;
    
    // ���� �ϰ��ӵ�
    [SerializeField] private float verticalSpeed;
    
    // �߷�
    [SerializeField] private float gravity;

    private void Update()
    {
        // CharacterController ���� �� �̵� ���� �޼ҵ� ȣ�� ����
        Jump(); // 1

        Move(); // 2

        GravityDown(); // 3
    }

    public void Move()
    {
        // ���� ����ƮŰ�� ������ �ִٸ�
        bool isHooray = Input.GetKey(KeyCode.LeftShift);
        // ���� �ִϸ��̼��� �����
        animator.SetBool("Hooray", isHooray);

        // �ִϸ��̼ǿ� ���� ���°� ����
        animator.SetBool("IsGround", isGrounded);
        // ����Ű �Է� ó��
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ���� ����
        moveDirection = new Vector3 (h, 0f, v).normalized;

        // �̵� �ִϸ��̼� ���
        animator.SetFloat("Move", moveDirection.magnitude);

        // ���� �ٴ� ���� ���¸�
        //if(isGrounded)
            transform.LookAt(transform.position + moveDirection); // �ü� ����

        // ĳ���� ��Ʈ�ѷ��� �̵� ó��
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // �߷�ó��
    public void GravityDown()
    {
        // ���� �ϰ� �ӵ� ���� (������)
        verticalSpeed = verticalSpeed - gravity * Time.deltaTime;   

        // ���� �ϰ� �ӵ��� �߷� ũ�⺸�� �۾�����
        if(verticalSpeed < -gravity)
            verticalSpeed = -gravity; // �߷� ũ�� �ִ� ���� �ϰ� �ӵ��� ����
        // ���� �ϰ� �̵� ���� ����
        Vector3 verticalMove = new Vector3(0f, verticalSpeed * Time.deltaTime, 0f);

        // ĳ���� ��Ʈ�ѷ��� ���� �ݸ��� ������ �÷��� ���� ��ȯ && ���� �ϰ� �̵� ó�� (�߷�ó��)
        CollisionFlags flag = controller.Move(verticalMove);

        // �̵��� �浹�� �ٴ� ���� �ִٸ�
        if ((flag & CollisionFlags.Below) != 0)
        {
            verticalSpeed = 0; // ���� �ϰ��ӵ��� 0���� �ʱ�ȭ
        }
        // ���� ���� �ӵ��� �ִϸ��̼ǿ� ������
        animator.SetFloat("Vertical", verticalSpeed);
    }

    public void Jump()
    {
        // ĳ���� ��Ʈ�ѷ��� �ٴ��� �ν����� ���� ���¿���
        if (!controller.isGrounded)
        {
            // ���� ���°� ������ ���
            if (isGrounded)
            {
                // ���� ��ȿ���� �ð����
                groundTimer += Time.deltaTime;

                // 0.5�� �Ŀ� ���� ���� ����
                if (groundTimer >= 0.5f)
                { 
                    isGrounded = false;
                }

            }
        }
        else // ���� ���� ��� ���°� ���� ���¶��
        {
            groundTimer = 0.0f; // ���� ��ȿ üũ Ÿ�̸� �ʱ�ȭ
            isGrounded =true; // �������� ����
        }

        // ���� ���¿��� ����Ű�� �����ٸ�
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            // ���� �ִϸ��̼� ���
            animator.SetTrigger("Jump");
            verticalSpeed = jumpSpeed; // ���� �ϰ� �ӵ��� ���� �ӵ��� ����
            isGrounded = false; // �������� ����
        }
    }

    // �ִϸ��̼� �̺�Ʈ ���� ��� (���� Ŭ�� ����)
    public void AnimationSoundPlay(Object audioClip)
    { 
        // Object(�θ�Ÿ��) -> AudioClip(�ڽ�Ÿ��) : �ٿ�ĳ����
        // * �θ�Ÿ���� ��ü�� ������ �ڽ� Ÿ���� ���������� �����Ϸ��� �ݵ�� �ٿ� ĳ������ �ؾ���
         AudioSource.PlayClipAtPoint((AudioClip)audioClip, Camera.main.transform.position);
        // == AudioSource.PlayClipAtPoint(audioClip as AudioClip, Camera.main.transform.position);
    }

}
