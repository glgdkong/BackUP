using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDodgeMovement : PlayerController
{
    // �÷��̾� �ൿ ������Ʈ
    private InputMovement move;

    // ī�޶� ��ġ ����
    [SerializeField] private Transform cameraTransform;

    // ������ ���� �ڷ�ƾ ����
    private WaitForSeconds dodgeInputWait;
    [SerializeField] private float dodgeDelayTime;

    // ������ ���� �Ӽ�
    private Vector3 movement;
    private bool isDodgeable = true;
    // ȸ�� ����
    protected bool isDodgeing;
    public bool IsDodgeing { get => isDodgeing; set => isDodgeing = value; }

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<InputMovement>();
        dodgeInputWait = new WaitForSeconds(dodgeDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHp.IsHit || playerHp.IsDeath) return;
        Dodge();
    }

    private void Dodge()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ���� 
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // ī�޶��� ȸ���� �������� ĳ������ ���ο� ���� ���͸� ����
        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        // ���� �̵����͸� �����
        movement = direction;


        bool d = Input.GetButtonDown("Dodge");
        if (d && isDodgeable)
        {
            isDodgeable = false;
            animator.SetTrigger("Dodge");

            transform.LookAt(transform.position + movement.normalized);
        }
    }

    public IEnumerator DodgeAnimatorEvent()
    {
        yield return dodgeInputWait;
        isDodgeable = true;
    }

    public void IsDodgeOn()
    {
        isDodgeing = true;
    }
    public void IsDodgeOff()
    {
        isDodgeing = false;
    }
}
