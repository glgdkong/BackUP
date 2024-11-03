using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private Movement movement;

    // �� ��� Ż�� ���� ��
    [SerializeField] private float offSet = 0.03f;

    public void Setting(Transform[] way)
    {
        movement = GetComponent<Movement>();

        // �� �̵� ���(���� ����Ʈ) ����
        wayPointCount = way.Length;
        // �迭�� �ʱ�ȭ
        wayPoints = new Transform[wayPointCount];
        // �迭 �Ҵ�
        wayPoints = way;

        // ���� ���� ��ġ�� ù ��° ��������Ʈ�� ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(MoveCoroutine());
    }

    // ���� ������ �ڷ�ƾ
    private IEnumerator MoveCoroutine()
    {
        SetDestination();
        // �����̱� ���� ���� ������ �ʿ��ϴ�.
        while (true)
        {
            // ��ǥ ������ �����Ͽ��ٸ�
            // float �� ��Ȯ�� ���� �ƴϰ� �ٻ簪�Դϴ�.
            // �Ÿ� ���� ���ϱ� Vector3.Distance(a,b);
            // ��ǥ ���������� �Ÿ��� ������ ���� ����� ���� �����ߴٶ�� ���ش�.
            if (Vector3.Distance(wayPoints[currentIndex].position, transform.position) <= offSet)
            {
                // ���� ��ġ�� ��ǥ �������� �ʱ�ȭ
                transform.position = wayPoints[currentIndex].position;

                // ���� ������ ����
                SetDestination();
            }
            yield return null;
        }
    }

    private void SetDestination()
    {
        // ���� �̵��� ��������Ʈ�� �����ִٸ�
        if (currentIndex < wayPointCount - 1)
        {
            currentIndex++;

            // ���� ���ϱ� 
            // ��ǥ �������� ���ϴ� ���� ���ϱ� (��ǥ���� - ���� ������ġ).normalized;
            // ���� (����, ũ��, ������� ��ġ, �������κ����� ��ġ)
            // ������ ���� ���� ���Ͱ� ũ�� ���� ������ �����Ƿ� ���⸸�� �������� ũ�⸦ 1�� ����°��� ����ȭ��� �Ѵ�. (.normalized)

            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement.SetDirection(direction);
        }
        // ������ ��������Ʈ��� (Finish Ÿ�Ͽ� ����)
        else
        {
            Destroy(gameObject); 
        }
    }
}
