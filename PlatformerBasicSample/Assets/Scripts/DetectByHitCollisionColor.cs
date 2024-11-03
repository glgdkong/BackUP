using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectByHitCollisionColor : DetectByHitCollision
{
    // �浹 ��� ��������Ʈ������ ������Ʈ
    [SerializeField]protected SpriteRenderer spriteRenderer;

    // �浹 ����ȿ�� ��� ����
    [SerializeField]protected bool showHitColor;

    // �浹 ����ȿ�� ǥ�� ī��Ʈ
    [SerializeField]protected int showHitColorCount;

    // �浹 ����ȿ�� ���� �ð�
    [SerializeField]protected float showHitColorTime;

    // �浹 ����ȿ�� ��� �� ����
    private bool showing = false;

    protected override void HitProcess(Collider2D collider)
    {
        ShowHitColor();

        HitDamage(collider);
    }
    protected void ShowHitColor()
    {
        if (!showing)
        {
            StartCoroutine("HitShowColorCoroutine");
        }
    }

    // �ǰ� ���� ���� �ڷ�ƾ
    IEnumerator HitShowColorCoroutine()
    {
        showing = true;
        // �浹 ���� ȿ�� ǥ�� ī��Ʈ ��ŭ ���� ȿ���� ǥ��
        for (int i = 0; i < showHitColorCount; i++)
        {
            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(showHitColorTime);

            spriteRenderer.color = new Color(1f, 0f, 0f, 0.5f);

            yield return new WaitForSeconds(showHitColorTime);

            spriteRenderer.color = Color.white;
        }
        showing = false;
    }
}
