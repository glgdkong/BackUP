using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemPopup : MonoBehaviour
{
    // Ÿ�� �迭
    [SerializeField] private string[] types = { "A", "B", "C" };
    // ���� Ÿ�� �ε���
    private int typeIndex;

    // ������ �̸� �Է� �ʵ�
    [SerializeField] private InputField inputItemName;
    // ������ ���� �Է� �ʵ�
    [SerializeField] private InputField inputItemPrice;

    // �α� ��� �ؽ�Ʈ
    [SerializeField] private Text logText;

    // �α� ��� �ð�
    [SerializeField] private float logPrintTime;

    // Ÿ�� ���� ��Ӵٿ�
    [SerializeField] private Dropdown typeSelectDropDown;

    private IPopup callback; // �˾� �ݹ� �������̽� ����

    private Coroutine coroutine; // �α���� �ڷ�ƾ ����

    // Ÿ�� ���� ��Ӵٿ� �̺�Ʈ(��Ӵٿ�)
    public void OnTypeCheckDropDown(int selectType)
    {
        typeIndex = selectType;
    }
    // �˾� ����
    public void Open(IPopup callback)
    {
        this.callback = callback;


        gameObject.SetActive(true);
        logText.text = "";

        // �˾� UI �ʱ�ȭ
        typeIndex = 0;
        typeSelectDropDown.value = typeIndex;
        inputItemName.text = "";
        inputItemPrice.text = "";
    }

    // ������ ���� �߰��ϱ� ��ư Ŭ�� (��ư)
    public void OnAddButtonClick()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine); // �ڷ�ƾ ������ ���� �ڷ�ƾ ����
            coroutine = null;
        }
        //StopCoroutine("LogPrintingCoroutine");

        // ���Ἲ üũ
        if (inputItemName.text.Trim().Length <= 0)
        {
            //coroutine = StartCoroutine(LogPrintingCoroutine("������ �̸��� �Է��ϼ���."));
            coroutine = StartCoroutine("LogPrintingCoroutine", "������ �̸��� �Է��ϼ���.");
            return;
        }
        if (inputItemPrice.text.Trim().Length <= 0)
        {
            coroutine = StartCoroutine("LogPrintingCoroutine", "������ ������ �Է��ϼ���");
            return;
        }

        string strPrice = inputItemPrice.text.Trim();
        if (!int.TryParse(strPrice, out int result))
        {
            coroutine = StartCoroutine("LogPrintingCoroutine", "������ ������ ���ڸ� �����մϴ�.");
            return;
        }

        // ������ ���� ��ü ����
        ItemData itemData = new ItemData(types[typeIndex], inputItemName.text, inputItemPrice.text);

        // ������ ���� �߰� �Ϸ� �ݹ� �޼ҵ� ȣ��
        callback.OnDataConfirm(itemData);

        // �˾� ��Ȱ��ȭ
        gameObject.SetActive(false);

    }

    // �α� �޽��� ���� �ð� ���
    IEnumerator LogPrintingCoroutine(string logMessage)
    {
        logText.text = logMessage;
        yield return new WaitForSeconds(logPrintTime);

        logText.text = "";
    }

    // �˾� �ݱ� ��ư Ŭ��
    public void OnCloseButtonClick()
    {
        callback.OnDataConfirm(null);
        gameObject.SetActive(false);
    }
}
