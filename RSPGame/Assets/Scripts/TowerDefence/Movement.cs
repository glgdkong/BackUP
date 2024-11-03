using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // �ܺο� ������ �����ϱ� ���ؼ� public ������ �߾��µ�
    // ��� �̹���� ��ȣ���� �ʴ� ����̴�.
    // ���α׷����� ���м��� ���� ������ ö���� ����� �Ѵ�.

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 moveDirection;

    // ������Ƽ : �ܺο� �����ϰ� ���� ������ �����ϴ� ���
    // �ܺ꿡�� ���� �Ҵ��ϴ� ����� setter��
    // �ܺο��� ���� �������� ����� getter�� �������� �ִ�.

    // ���Ϳ� ���� ��� ������ ������Ƽ�� ����
    // public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    // ���͸� ������ ������Ƽ ����
    public float MoveSpeed => moveSpeed;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

}
