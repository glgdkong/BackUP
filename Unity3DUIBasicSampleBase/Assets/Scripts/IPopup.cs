using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �˾� �������̽�
public interface IPopup 
{
    // �˾� ���� ��� Ȯ�� �̺�Ʈ
    public void OnConfirm(bool isSuccess);
    // �˾� ���� ��� Ȯ�� �� ������ ���� �̺�Ʈ
    public void OnDataConfirm(object data);
}
