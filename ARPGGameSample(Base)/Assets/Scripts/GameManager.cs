using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ESC ��� ó�� ���� ����Ʈ ����
    public delegate void OnCanckeDelegate();
    public static OnCanckeDelegate onCancelDelegate;


    // Update is called once per frame
    void Update()
    {
        // ESC�� �������
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // ��������Ʈ �޼ҵ� ȣ��
            onCancelDelegate();
        }
    }
}
