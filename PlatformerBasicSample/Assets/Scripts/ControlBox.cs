using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ControlBox : MonoBehaviour
{
    // ��Ʈ�� �ڽ� ���� �޽���
    [SerializeField] protected string massage;
    // �޽��� 
    [SerializeField] protected Text infoText;

    //
    protected void Start()
    {
        infoText.gameObject.SetActive(false);
        infoText.text = massage;
    }

    // ��Ʈ�� �ڽ� ���
    public abstract void Use();

    // �÷��̾ ��Ʈ�� �ڽ� ���� �����ȿ� ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // ���� �޽��� ���
            infoText.gameObject.SetActive(true);
        }
    }

    // �÷��̾ ��Ʈ�� ���� ���� ���� �ȿ��� ������
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // ���� �޽��� ��� ����
            infoText.gameObject.SetActive(false);
        }
    }
}
