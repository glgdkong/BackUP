using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ȸ�� ���� ī�޶� �⸸ �̵� ������Ʈ
public class InputFreeLookMovement : MonoBehaviour
{
    // �̵��ӵ�
    [SerializeField] private float moveSpeed;
    // ȸ�� �ӵ�
    [SerializeField] private float rotateSpeed;
    // ī�޶� Ʈ������ ������Ʈ
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController cc;

    // Update is called once per frame
    void Update()
    {
        // �̵� ����Ű��
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵� ���� ����
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // �̵� �ִϸ��̼� ����
        animator.SetFloat("Move", direction.magnitude);

        // * ī�޶��� ȸ�� �������� ĳ������ ���ο� ���� ���͸� ����
        direction = Quaternion.AngleAxis(camTransform.rotation.eulerAngles.y, Vector3.up) * direction;

        direction.Normalize();

        // ���� �̵����͸� �����
        Vector3 move = direction * moveSpeed;

        // ĳ���Ͱ� �̵��� ������
        cc.SimpleMove(move);

        // ĳ���Ͱ� �̵��� �����Ѵٸ�
        if(direction != Vector3.zero)
        {
            // ĳ���� ���⿡ ���� ���͸��� ȸ������ ����
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // �ε巯�� ĳ������ ȸ�� ó���� ������
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
