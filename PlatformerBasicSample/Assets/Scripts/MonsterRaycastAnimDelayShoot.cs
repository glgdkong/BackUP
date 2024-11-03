using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRaycastAnimDelayShoot : MonsterDelayShoot
{
    [SerializeField] protected Animator animator;

    // ��� ���� ���� �޼ҵ� ������
    protected override void DetectAndShoot()
    {
        // ���� ��ȯ�� ���� �ü� �������� ����ĳ��Ʈ üũ�� ������
        RaycastHit2D hit = Physics2D.Raycast(shootTransform.position, ShootDirection, detectionRange, detectLayer);
        
        // �浹 ������Ʈ�� ���� �Ǿ��ٸ�
        if (hit.collider != null)
        {
            // ���� �ִϸ��̼� ���
            animator.SetBool("IsShoot", true);
        }
        else
        {
            // ���� �ִϸ��̼� ����
            animator.SetBool("IsShoot", false);
        }
    }
    // ��� ���� ����ĳ��Ʈ ����� ǥ�� �̺�Ʈ �޼ҵ�
    protected void OnDrawGizmosSelected()
    {
        // ���� ǥ���� ����� ������  ������
        Gizmos.color = Color.red; // ����� ���� ����
        // ����ĳ��Ʈ�� ���� ���������� ������ ����� ���� �׷��� 
        Gizmos.DrawLine(shootTransform.position, shootTransform.position + (Vector3)ShootDirection * detectionRange);
        
    }
    // ���� �ִϸ��̼� Ÿ�Ӷ��� �̺�Ʈ �޼ҵ�
    public void ShootBulletAnimationEvent()
    {
        //Debug.Log($"{name}���� �Ѿ� ����");
        Fire();
    }
}
