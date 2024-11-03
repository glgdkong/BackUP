
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����� �������� ����Ű�� ������Ʈ
public class TargetArrow : MonoBehaviour
{
    [SerializeField] private GameObject target = null; // ���� ��� ����

    [SerializeField] private float findDelayTime; // ã�� �ֱ�(�ð�)

    [SerializeField] private Renderer arrowRenderer; // ȭ��ǥ ������ ����

    [SerializeField] private float rotateSpeed; // ȸ���ӵ�

    // ���� ����� �������� ã�� �޼ҵ�
    public GameObject FindTargetSlime()
    {
        GameObject targetSlime = null;

        // GameObject[] ���ӿ�����Ʈ�� = GameObject.FindGameObjectWithTag("�±�");
        // -> ������ �±װ� ������ ���ӿ�����Ʈ ����� ã�� (�迭)

        GameObject[] slimes = GameObject.FindGameObjectsWithTag("Slime");

        float shortesDistance = Mathf.Infinity;

        for (int i = 0; i < slimes.Length; i++)
        {
            // float �Ÿ� = Vector3.Distance(������Ʈ1��ġ, ������Ʈ2��ġ);
            // -> �ΰ��� ���ӿ�����Ʈ ������ �Ÿ�

            // �÷��̾�� ������ �����Ӱ��� �Ÿ��� ������
            float distance = Vector3.Distance(transform.position, slimes[i].transform.position);
            
            // ���� ������ �Ÿ��� ���� �ּ� �Ÿ����� �۴ٸ�
            if(distance < shortesDistance)
            {
                // ���� �Ÿ��� �ּ� �Ÿ��� ����
                shortesDistance = distance;
                targetSlime = slimes[i]; // ���� ��� �������� ����
            }
        }
        return targetSlime;
    }

    // Ÿ�� ã�� �ڷ�ƾ : ������ �ð� �ֱ�� ������ Ÿ���� ã�� ����(���� üũ �ʿ�)
    IEnumerator TargetArrowCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(findDelayTime); // �ð� ����

            // ���� ����� �������� ã��
            target = FindTargetSlime();
            if (target != null)
            {
                //Debug.Log($"���� ����� ������ : {target.name}({target.transform.position})");
            }
        }
    }
    private void Start()
    {
        // �ð������� �����鼭 Ÿ���� �ݺ������� ã�� �ڷ�ƾ�� ������
        StartCoroutine(TargetArrowCoroutine());
    }
    private void Update()
    {
        if (target == null)
        {
            arrowRenderer.enabled = false;
        }
        else
        {
            arrowRenderer.enabled = true;

            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            //Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            transform.rotation = newRotation;
        }
    }
}
