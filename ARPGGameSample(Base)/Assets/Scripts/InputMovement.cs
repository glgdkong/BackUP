using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private Animator animator; // �ִϸ����� ������Ʈ
    private CharacterController controller; // ĳ���� ��Ʈ�ѷ� ������Ʈ

    [SerializeField] private float speed; // �̵��ӵ�
    [SerializeField] private float rotateSpeed; // ȸ�� �ӵ�

    private Vector3 movement; // �̵� ����

    // �߷� ���� �Ӽ�
    [SerializeField] private float gravity; // �߷� ��ġ
    private float vSpeed = 0.0f;

    private InputMeleeAttack meleeAttack; // ���� �Ϲݰ��� ������Ʈ

    private InputSkillAttack skillAttack; // ��ų ���� ������Ʈ


    private void Awake()
    {
        // ������Ʈ ����
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        meleeAttack = GetComponent<InputMeleeAttack>();
        skillAttack = GetComponent<InputSkillAttack>();
    }

    private void Update()
    {
        // ���� �� ��ų �ִϸ��̼��� ���� ���� ��� �̵��� ���� ����
        if (meleeAttack.IsPlayAttackAnimation() || skillAttack.IsSkillAnimation()) return;
        Move();  // �̵� ó��
        GravityDown(); // �߷� ó��

    }

    // ĳ���� �̵� ó��
    private void Move()
    {
        // �Է� �̵� ����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // isAnimatorTransitioning = animator.IsInTransition(0);

        movement = direction; // �̵� ����

        // �̵� �ִϸ��̼� ���
        animator.SetFloat("Move", movement.magnitude);

        // ĳ���� ȸ�� ó��
        //transform.LookAt(transform.position + movement.normalized);

        Vector3 targetDirection = movement.normalized;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        }
        // �̵� ó��
        controller.Move(movement * (speed *Time.deltaTime));
    }

    private void GravityDown()
    {
        vSpeed = vSpeed - gravity * Time.deltaTime;

        if (vSpeed < -gravity) 
            vSpeed = -gravity;

        var verticalMove = new Vector3(0, vSpeed * Time.deltaTime, 0);

        var flag = controller.Move(verticalMove);
        if((flag & CollisionFlags.Below) != 0)
        {
            vSpeed = 0;
        }
    }

}
