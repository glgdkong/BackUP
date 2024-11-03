using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : PlayerController
{
    // �̵� �ӵ�
    [SerializeField] private float moveSpeed;
    // ȸ�� �ӵ�
    [SerializeField] private float rotateSpeed;
    public float RotateSpeed { get => rotateSpeed;}
    [SerializeField] private Transform cameraTransform;

    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private CharacterController cc;

    // �̵� ����
    private Vector3 movement;

    // �߷� ���� �Ӽ�
    [SerializeField] private float gravity; // �߷¼�ġ
    private float vSpeed = 0.0f;

    // ���� ���� ������Ʈ
    private InputMeleeAttack meleeAttack;

    // �÷��̾� ������ ������Ʈ
    private InputDodgeMovement dodge;

    // �÷��̾� ���� ������Ʈ
    private InputGuard guard;

    protected override void Awake()
    {
        base.Awake();
        cc = GetComponent<CharacterController>();
        meleeAttack = GetComponent<InputMeleeAttack>();
        dodge = GetComponent<InputDodgeMovement>();
        guard = GetComponent<InputGuard>();
    }

    void Update()
    {
        if (meleeAttack.IsPlayAttackAniamtion() || playerHp.IsDeath || playerHp.IsHit || dodge.IsDodgeing || guard.IsGuarding) 
        {
            return; 
        }

        Move();

        Gravity();
    }

    private void Move()
    {
        // Ű�Է°�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ���� 
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // �̵� �ִϸ��̼� ���
        animator.SetFloat("Move", direction.magnitude);

        // ī�޶��� ȸ���� �������� ĳ������ ���ο� ���� ���͸� ����
        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        // ���� �̵����͸� �����
        movement = direction;

        // ĳ���Ͱ� �̵��� ������
        cc.Move(movement * (moveSpeed * Time.deltaTime));

        // ĳ���Ͱ� �̵��� �����Ѵٸ�
        if (movement != Vector3.zero)
        {
            // ĳ���� ���⿡ ���� ���͸��� ȸ������ ����
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // �ε巯�� ĳ������ ȸ�� ó���� ������
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void Gravity()
    {
        vSpeed = vSpeed - gravity * Time.deltaTime;
        if (vSpeed < -gravity) vSpeed = -gravity;

        var verticalMove = new Vector3(0, vSpeed * Time.deltaTime, 0f);

        var flag = cc.Move(verticalMove);
        if ((flag & CollisionFlags.Below) != 0)
        {
            vSpeed = 0f;
        }
    }
}
