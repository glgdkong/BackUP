using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPause
{
    private bool isRotating = true;
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        if (!isRotating) return;


        // �÷��̾��� ���� �ڵ�
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    public void OnPause()
    {
        Debug.Log("ȸ�� ������ ����");
        isRotating = false;
    }

    public void OnResume()
    {
        Debug.Log("ȸ�� ������ �ٽ� ����");
        isRotating = true;
    }
}
