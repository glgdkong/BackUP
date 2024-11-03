using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    // Ÿ�� ��Ŀ ǥ����ġ ������ Y
    [SerializeField] private float surfaceOffset;
    // Ÿ�� ��ġ ǥ�ÿ� ���ӿ�����Ʈ(�Ǹ���)
    [SerializeField] private GameObject targetPoint;

    // Ÿ�� ��ġ ǥ��(ǥ�� ��ġ, ǥ�� ���� ����)
    public void Show(Vector3 position, Vector3 normal)
    {
        //Debug.Log($"�̵���ġ ǥ�� : {position}");

        // Ÿ�� ��ġ�� ����
        transform.position = position + normal * surfaceOffset;

        // Ÿ�� ǥ�� ���� ����
        transform.up = normal;
        // Ÿ������Ʈ ���ӿ�����Ʈ Ȱ��ȭ
        targetPoint.SetActive( true );
    }

    // Ÿ�� ��ġ ǥ�� ����
    public void Hide()
    {
        // Ÿ������Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        targetPoint.SetActive( false );
        transform.position = Vector3.zero;
    }

}
