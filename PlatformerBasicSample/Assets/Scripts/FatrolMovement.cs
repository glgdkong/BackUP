using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��ȯ �̵� ó�� ������Ʈ
public class FatrolMovement : DirectionHorizontalMovement
{
    // ��ȯ ��ġ ����Ʈ��
    [SerializeField] private Transform[] wayPoints;

    // ���� �̵��ϴ� ��ȯ��ġ �ε���
    private int currentWatPointIndex = 0;

    // �̵� ó��
    protected override void Move()
    {
        // �̵� ����Ʈ ���̰� 0�̸� ó�� �Ұ�
        if(wayPoints.Length == 0) return;

        // ���� �̵� ��ġ�� ������
        Transform targetWaypoint = wayPoints[currentWatPointIndex];

        // �ε巴�� ���� �̵� ó���� ������ 
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, MoveSpeed * Time.deltaTime);

        // ĳ������ �̵� ���⿡ �°� ��������Ʈ ���� ��ȯ�� ������
        if(transform.position.x < targetWaypoint.position.x) spriteRenderer.flipX = false;
        if (transform.position.x > targetWaypoint.position.x) spriteRenderer.flipX = true;

        // ��ǥ ��ġ�� �����ߴٸ� 
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // ���� ��ġ �ε��� ������Ʈ
            if(IsRight) // ������ �̵� ���̸�
            {
                // ������ �̵� ��ġ�� �������� �ʾҴٸ�
                if (currentWatPointIndex < wayPoints.Length - 1)
                    currentWatPointIndex++; // ���� �̵� ��ġ �ε��� ���
                else // ������ �̵� ��ġ���� �����ߴٸ�
                {
                    currentWatPointIndex--; // ���� �̵� ��ġ �ε��� ���
                    IsRight = false; // ���������� �̵� ���� ��ȯ
                }
            }
            else // ������ �̵� ���̸�
            {
                // ù��° �̵� ��ġ�� �������� �ʾҴٸ�
                if (currentWatPointIndex > 0) currentWatPointIndex--;
                else // ù��° �̵� ��ġ�� �����ߴٸ�
                {
                    currentWatPointIndex++; // ���� �̵� ��ġ �ε��� ���
                    IsRight = true; // ���������� �̵� ���� ��ȯ
                }
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
