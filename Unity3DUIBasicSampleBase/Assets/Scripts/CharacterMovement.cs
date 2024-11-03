using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // ĳ���� �ִϸ����� ������Ʈ
    [SerializeField] private Animator animator;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    [SerializeField] private CharacterController cc;
    // �̼�
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        // Ű �Է� ó��
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ���� ����
        Vector3 movement = new Vector3(h,0f ,v).normalized;

        // �̵� �ִϸ��̼� ���
        animator.SetFloat("Move", movement.magnitude);

        // ĳ���� ȸ�� ó��
        transform.LookAt(transform.position + movement.normalized);

        // ĳ���� �̵� ó��
        cc.Move(movement* (moveSpeed *Time.deltaTime));
    }


}
