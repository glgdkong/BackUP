using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ŉ�� ó�� ������Ʈ
public class PickUpItem : MonoBehaviour
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
        if(collider.tag.Equals("Item"))
        {
            gameManager.TimeUp(10); // 10�� ����

            // ����� ����� ����
            pickUpAudioSource.Play();

            // ŉ���� ������ ���� ������Ʈ �ֻ��� ���ӿ�����Ʈ�� �ı�
            //Destroy(collider.transform.parent.gameObject);
            Destroy(collider.transform.root.gameObject);
        }
    }
}
