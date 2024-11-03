using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ŉ�� ó�� ������Ʈ
public class PickUpSlime : MonoBehaviour
{
    // ���� �Ŵ��� ������Ʈ ���� ����
    [SerializeField] private GameManager gameManager;

    // ������ ŉ�� ����Ʈ ������
    [SerializeField] private GameObject pickUpEffectPrefab;

    // ������ ŉ�� ���� �����(������Ʈ) ����
    [SerializeField] private AudioSource pickUpAudioSource;

    // Trigger�� Ȱ��ȭ�� �ݶ��̴��� �浹 ��(����Ƽ �̺�Ʈ �޼ҵ�)
    private void OnTriggerEnter(Collider collider)
    {
        // ŉ����(�浹��) ���ӿ�����Ʈ�� �±װ� Slime�̸�
        if(collider.tag.Equals("Slime"))
        {
            // ����� ����� ����
            pickUpAudioSource.Play();

            // ������ ŉ�� ����Ʈ ����
            Instantiate(pickUpEffectPrefab, collider.transform.position, Quaternion.identity);
            
            // �浹�� �������� ���� ������Ʈ ����
            SlimeStat slimeStat = collider.GetComponent<SlimeStat>();

            // ŉ���� �������� ����� ������ ������Ʈ ����
            DropItem dropItem = collider.GetComponent<DropItem>();

            // ������ ���� ������Ʈ�� ������ ����
            if (dropItem != null) 
            {
                dropItem.Drop(); // ������ ����ó��
            }

            // ŉ���� �������� ������ ���� ������ �����
            gameManager.ScoreUp(slimeStat.Score);

            // ŉ���� ������ ���� ������Ʈ �ı�
            Destroy(collider.gameObject);
        }
    }
}
