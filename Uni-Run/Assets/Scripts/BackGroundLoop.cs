using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    private Vector3 offset;

    void Start()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        // �ݶ��̴��� ������ x�� ���� �ǹ��Ѵ�.
        width = box.size.x;

        // ��ŸƮ �Լ����� �� ���� �޸� �Ҹ�
        offset = new Vector3(width * 2f, 0, 0);
    }

    void Update()
    {
        // ����� ��ġ�� x���� ����ŭ �������� �̵����� ��
        if(transform.position.x <= -width)
        {
            // -20 + 40 = 20
            // new �����ڸ� ����ϸ� �޸𸮰� �Ҹ�ȴ�.
            // ��ŸƮ���� �Ҵ��� ���� ������ ������ ����Ѵ�. (�޸� ����ȭ ����)
            transform.position += offset;
        }
    }
}
