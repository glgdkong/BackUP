using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 8���� ĳ���� Ű���� �̵�

public class InputMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // ���� ����Ű��
        float h = Input.GetAxis("Horizontal");
        // ���� ����Ű��
        float v = Input.GetAxis("Vertical");

        // ���⺤�͸� ���ϰ� ����ȭ(ũ�Ⱑ 1¥�� ���ͷ� ����)�� ������
        // Vector3 direction = new Vector3(h, 0f, v);
        // Vector3 normalDirection = direction.normalized;
        Vector3 normalDirection = new Vector3(h, 0f , v).normalized;

        // ������ ���ϱ� ������ ������ �̵� ũ��� ������ �ݿ��� �̵� ��ġ�� ������
        // �̵� ��ġ = �����̵���ġ + (���� * �̵�ũ�� * Time.deltaTime);
        transform.position += normalDirection * moveSpeed * Time.deltaTime;

        // �ִϸ��̼� �Ķ���� ����
        animator.SetFloat("Speed", normalDirection.magnitude);

        // ĳ���� ����ȸ�� 
        // * transform.LookAt(ȸ���ؼ� �ٶ���ġ(Vector3))
        transform.LookAt(transform.position + normalDirection);

        
    }
}
