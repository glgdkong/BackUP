using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUse : MonoBehaviour
{
    private ControlBox controlBox; // ��Ʈ�� �ڽ�

    // ��Ʈ�� �ڽ� ���� ���� ������ ��
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ControlBox"))
        {
            controlBox = collision.GetComponent<ControlBox>();
        }
    }

    // ��Ʈ�� �ڿ� ����� �������� ����
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("ControlBox"))
        {
            controlBox = null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if(controlBox != null)
            {
                controlBox.Use();
            }
        }
    }
}

