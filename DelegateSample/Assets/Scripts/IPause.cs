using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �Ͻ����� ��� �������̽�
public interface IPause 
{
    public void OnPause(); // ���� �Ͻ� ���� �˸� �̺�Ʈ
    public void OnResume(); // ���� �Ͻ� ���� ���� �˸� �̺�Ʈ
}
