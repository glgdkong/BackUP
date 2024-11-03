using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ÿ�� ��ġ ��ġ �̵� ������Ʈ
public class InputTargetTouchMovement : MonoBehaviour
{
    // ���콺 ��ġ ����Ʈ ��ġ
    [SerializeField] private Vector3 movePosition;

    // �̵��ӵ�
    [SerializeField] private float moveSpeed;

    // ȸ���ӵ�
    [SerializeField] private float rotateSpeed;

    // �ִϸ����� 
    [SerializeField] private Animator animator;

    // Ŭ��/��ġ �νĿ� �浹 ���̾� ����ũ
    [SerializeField] private LayerMask touchMoveLayerMask;

    // �̵� ��ġ ǥ�ÿ� Ÿ�� ��Ŀ
    [SerializeField] private TargetPicker targetPicker;

    void Update()
    {
        // ���� ���콺 Ŭ������ �ߴٸ� (0 : ���� ���콺 ��ư, ��ġ����)
        if (Input.GetMouseButtonUp(0))
        {
            // Camera.main.ScreenPointToRay(���콺 Ŭ��/ ��ġ����Ʈȭ����ġ-> ��ũ����ġ��ġ);
            // - ȭ�� ��ġ ��ġ���� ī�޶� �������� �߻��ϴ� ���̸� ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Physics.Raycast(�浹üũ����, out �浹����, ����)
            // - �浹üũ���̸� ���� �浹�� üũ��
            // - hit : �浹 ����
            RaycastHit hit;

            // ȭ�� Ŭ��/��ġ ���̿� �浹�� ������ �ִٸ�
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchMoveLayerMask))
            {
                //Debug.Log($"��ġ ��ġ {hit.point}");

                // �̵��� ��ġ���� ������
                movePosition = hit.point;

                // Ÿ����Ŀ�� ǥ���� ��ġ�� �븻(����) ���� ������ �Ѱ���
                targetPicker.Show(movePosition, hit.normal);


            }
        }

        // float �Ÿ� = Vector3.Distance(��ġ����1, ��ġ����2) : ��ġ 1�� ��ġ 2���� �Ÿ��� ����
        float distance = Vector3.Distance(transform.position, movePosition);

        // ĳ���Ͱ� ��ã�� ��ġ���� �Ÿ��� 0.01���� ũ�ٸ� (���� ��ġ�� �����ϱ� ���̶��)
        if (distance >= 0.01f)
        {
            // �÷��̾ �̵� ��Ŵ 

            // Vector ���ο� �̵���ġ = Vector.MoveTowards(������ġ, �����̵���ġ, �̵��ӵ� * Time.deltaTime);
            // - �ε巯�� �̵� ������ �ʿ��� �� ���
            transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);

            // �̵� ���� ���� ���ϱ�
            Vector3 direction = (movePosition - transform.position).normalized;

            // �̵� �ִϸ��̼� ���
            animator.SetFloat("Move", 1f);

            if (direction != Vector3.zero)
            {
                // Quaternion ȸ�� = Quaternion.LookRotation(ȸ���ϰ���� ����);
                // - ������ ���������� ���ʹϾ� ȸ������ ����
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Quaternion ���ο� ȸ���� = Quaternion.RotateTowards(����ȸ����, ����ȸ��, ȸ���ӵ� * Time.deltaTime);
                // -  �ε巯�� �̵� ������ �ʿ��� �� ���
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            }
        }
        else // ��ǥ��ġ�� �����ߴٸ�
        {
            // ���� ������ġ�� ĳ������ ��ġ�� ����
            transform.position = movePosition;

            // ��� �ִϸ��̼� ���
            animator.SetFloat("Move", 0f);

            // Ÿ����Ŀ ����
            targetPicker.Hide();
        }

    }
}