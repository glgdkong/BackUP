using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IHitable
{
    // ü��
    [SerializeField] protected int hp;

    // ��� ����Ʈ ������
    [SerializeField] protected GameObject destroyEffectPrefab;

    // ��� ����Ʈ Y ǥ�� ��ġ
    [SerializeField] protected float destroyEffectYPos;

    // �ǰ� �޼ҵ�
    public void Hit(int damage)
    {
        // ü�� ����
        hp -= damage;
        // ü���� 0���ϸ�
        if(hp <=0)
        { 
            Die(); 
        }
    }

    // ��� ó��
    private void Die()
    {
        // ĳ���� �ı� ó��
        Vector3 effectPosition = new Vector3(transform.position.x, transform.position.y + destroyEffectYPos, transform.position.z);

        // ����Ʈ ����
        GameObject effcet = Instantiate(destroyEffectPrefab, effectPosition, Quaternion.identity);
        Destroy(effcet, 2f);

        // ĳ���� �ı�
        Destroy(gameObject);
    }
}
