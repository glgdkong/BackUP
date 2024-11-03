using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class PlatformDirectMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed; // �÷��� �̵� �ӵ�
    [SerializeField] protected float moveDistance; // �¿�� �̵��� �ִ� �Ÿ�

    protected Vector3 startPosition; // �÷��� �ʱ� ��ġ

    [SerializeField] protected bool isVertical; // ���� �̵� ����

    protected void Start()
    {
        startPosition = transform.position;
    }
    // �����̵� ó��
    protected virtual void Move()
    {
        // ���� �̵� ó��
        // Mathf.Sin �Լ��� ����Ͽ� �ð��� ���� -1�� 1������ ���� �����ϰ�, �̸� �̵��Ÿ��� ����
        float move = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        if (isVertical)
        {
            // ������Ʈ�� y ��ġ�� ���� ��ġ�� move���� ���� ����
            transform.position = startPosition + new Vector3(0f, move, 0f);
        }
        else
        {
            // ������Ʈ�� x ��ġ�� ���� ��ġ�� move���� ���� ����
            transform.position = startPosition + new Vector3(move, 0f, 0f);
        }
    }
    protected virtual void Update()
    {
        Move();
    }
}
