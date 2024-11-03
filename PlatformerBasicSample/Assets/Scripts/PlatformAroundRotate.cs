using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAroundRotate : MonoBehaviour
{
    [SerializeField] private float speed; // �÷��� �̵� �ӵ�
    [SerializeField] private float radius; // ���� ������

    private Vector3 startPosition; // �ʱ� ��ġ
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        MoveAroundRotate();
    }
    void MoveAroundRotate()
    {
        float x = Mathf.Cos(Time.time * speed) * radius;
        float y = Mathf.Sin(Time.time * speed) *radius;
        transform.position = new Vector3(x, y, 0) + startPosition;
    }
}
