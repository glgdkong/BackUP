using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �պ� �̵� ó�� ������Ʈ
public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed; // �̵� �ӵ�
    [SerializeField] private float distance; // �̵� �Ÿ�(�պ� � �Ÿ�)
    private Vector3 startPosition; // �̵� ���� ��ġ

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // �պ� � ũ��
        float moveAmount = Mathf.Cos(Time.time * speed) *distance;

        // Vector3.forward : ������Ʈ �̵� ����
        Vector3 newPosition = startPosition + Vector3.forward * moveAmount;

        // ��ֹ� ��ġ ����
        transform.position = newPosition;
    }

}
