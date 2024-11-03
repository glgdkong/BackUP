using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ʈ�� Axis �������� �̵� �� ȸ���� �����ϴ� ������Ʈ
public class InputAxisMovement : MonoBehaviour
{
    // �ִϸ����� ������Ʈ
    [SerializeField] private Animator animator;
    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    [SerializeField] private CharacterController cc;
    // �̵� �ӵ�
    [SerializeField] private float moveSpeed;
    // ȸ�� �ӵ�
    [SerializeField] private float rotateSpeed;


    // Update is called once per frame
    void Update()
    {
        // ����Ű �Է°� ����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ���� ���� ����
        Vector3 direcrion = new Vector3(h, 0f, v).normalized;

        // direcrion.magnitude : ������ ���� (���)
        animator.SetFloat("Move", direcrion.magnitude);

        // �̵����� ����
        Vector3 movement = direcrion * moveSpeed;

        // ĳ���� ��Ʈ�ѷ��� �̿��� �̵� ó��
        //CharacterController.SimpleMove(�̵�����) : �̵� ���� ����� ũ��� ĳ���� ��Ʈ�ѷ��� �̿��� �̵� ó��
        cc.SimpleMove(movement);

        // Transform.LookAt(��ġ) : ������ ��ġ�� �ٶ󺸵��� ȸ��ó����
        // ���� ��ġ���� ���⺤�͸� ���� ������ �ٶ󺸵��� ��� ȸ����
        //transform.LookAt(transform.position + direcrion);

        if(direcrion != Vector3.zero)
        {
            // ���⿡ ���� ȸ���� ����
            Quaternion targetRotation = Quaternion.LookRotation(direcrion, Vector3.up);
            // ������ �ӵ��� �ε巴�� ȸ����
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        
    }
}
