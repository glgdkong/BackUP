using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUse : MonoBehaviour
{
    private ControlBox controlBox; // 컨트롤 박스

    // 컨트롤 박스 제어 가능 영역에 들어감
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ControlBox"))
        {
            controlBox = collision.GetComponent<ControlBox>();
        }
    }

    // 컨트롤 박에 제어가능 영역에서 나감
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

