using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȸ���ϴ� ���� ��ֹ� ȸ�� ó��
public class RotateObstacle : MonoBehaviour
{
    // ȸ�� �ӵ�
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        // ��ֹ� ȸ�� ó��
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }


}
