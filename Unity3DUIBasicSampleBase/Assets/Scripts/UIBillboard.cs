using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    // LateUpdate : Update �̺�Ʈ ������ �ѹ��� ������ �Ǳ� ���� ȣ��Ǵ� ������ �ֱ� ���� �̺�Ʈ �޼ҵ�
    private void LateUpdate()
    {
        // UI ĵ������ �ٶ󺸴� ������ ī�޶� �ü� ���Ϳ� ���� => ������
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
