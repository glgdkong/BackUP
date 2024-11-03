using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �ٿ �̵�
public class VerticalBounceMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // �̵� �ӵ�
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    private Rigidbody2D rigidbody2d; // �������� ������Ʈ

    [SerializeField]
    private float incMoveSpeed; // �̵� ���� �ӵ�

    [SerializeField]
    private float maxMoveSpeed; // �ִ� �̵��ӵ�

    [SerializeField]
    private float startDelayTime; // ���� �� �̵� �����ð�


    // Start �ڷ�ƾ �̺�Ʈ �޼ҵ�
    IEnumerator Start()
    {
        float oriSpeed = MoveSpeed;
        MoveSpeed = 0;
        yield return new WaitForSeconds(startDelayTime);

        MoveSpeed = oriSpeed;
    }

    
    void Update()
    {
        // �̵� �ӵ� ����
        rigidbody2d.velocity = Vector2.up * MoveSpeed;
    }

    public void ReverseDirection()
    {
        // �̵� �ӵ� ����
        MoveSpeed = -MoveSpeed;

        // ���� �̵��ӵ��� ������ ��ġ���� �ִ�ӵ����� �۴ٸ�
        if(Mathf.Abs(MoveSpeed) < maxMoveSpeed)
        {
            // �ӵ� ���� ����
            float speed = (MoveSpeed > 0) ? incMoveSpeed : -incMoveSpeed;
            MoveSpeed += speed; // �̵� �ӵ� ����
        }
    }
}
