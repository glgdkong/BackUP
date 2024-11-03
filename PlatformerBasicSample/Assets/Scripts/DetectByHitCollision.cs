using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ǰ� �� �浹 ó�� ������Ʈ
public abstract class DetectByHitCollision : MonoBehaviour
{
    // �ǰ� ��� �ν� �±׸�
    [SerializeField] protected string collisionTag;

    // �ǰ� ��󿡰� �ο��� ������
    [SerializeField] protected int damage;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        // �ǰ� ����� ������
        if (collider.tag.Equals(collisionTag))
        {
            // �ǰ� ó���� ������
            HitProcess(collider);
        }
    }

    // �ǰ� ó�� �߻� �޼ҵ�
    protected abstract void HitProcess(Collider2D collider);

    // �ǰ� ��󿡰� �������� �ο���
    protected virtual void HitDamage(Collider2D collider)
    {
        // ? ������ : ? �����ڰ� ������ ���������� �������� null�� �ƴҶ��� �޼ҵ� ȣ���ϴ� ������
        
        // �浹�� ������Ʈ�� �浹�� ���� �������� �ο��� ����̸�
        Attacker attacker = collider.GetComponent<Attacker>();
        if (attacker == null) return;

        // ���� ĳ���Ͱ� �ǰ��� ���� �� �ִ� ����̸�
        IHitable hitable = GetComponent<IHitable>();
        // ���� ĳ������ �ǰ� ó��
        hitable?.Hit(attacker.Damage);
        // �浹 ���� ��� �ڵ� �ı� ó��
        attacker.Disappear();

    }
}
