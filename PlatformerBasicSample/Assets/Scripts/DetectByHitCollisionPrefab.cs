using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ǰ��� ���� �� ����Ʈ �������� ����
public class DetectByHitCollisionPrefab : DetectByHitCollisionColor
{
    // �浹 ����Ʈ 
    [SerializeField] protected GameObject collisionEffectPrefab;

    // ����Ʈ �ı� �ð�
    [SerializeField] private float effectDestoryTime;


    protected override void HitProcess(Collider2D collider)
    {
        // �ǰ� ���� ǥ�Ⱑ ���̸� �ǰ� ���� ǥ�ø� ������
        if(showHitColor) ShowHitColor();

        // �浹 ��ġ ����
        Vector2 hitPosition = collider.transform.position;  
        Quaternion rot = Quaternion.identity;

        // �ǰݵ� ����� ���� ȸ�� �̵� ó�� ������Ʈ�� ������ �ִٸ�
        DirectionMovement directionAngleMovement = collider.GetComponent<DirectionMovement>();
        if(directionAngleMovement != null)
        {
            // �̵� ���⿡ ���� ȸ�� ���� ������ ȸ�� ���ʹϾ��� ������
            rot = Quaternion.Euler(0f, 0f, directionAngleMovement.Angle + 90f);
        }


        // �浹 ����Ʈ ����
        GameObject explosion = Instantiate(collisionEffectPrefab, hitPosition, rot);
        Destroy(explosion, effectDestoryTime);

        HitDamage(collider);
    }
}
