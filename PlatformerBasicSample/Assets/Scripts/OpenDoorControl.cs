using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� ��Ʈ�� �ڽ�
public class OpenDoorControl : ControlBox
{
    // ���� ���ӿ�����Ʈ
    [SerializeField] private GameObject door;

    // ������ ��Ʈ�� �ڽ��� �����
    public override void Use()
    {
        door.SetActive(false);
    }
}
