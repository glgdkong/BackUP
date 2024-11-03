using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDodgeMovement : PlayerController
{
    // 플레이어 행동 컴포넌트
    private InputMovement move;

    // 카메라 위치 참조
    [SerializeField] private Transform cameraTransform;

    // 구르기 지연 코루틴 관련
    private WaitForSeconds dodgeInputWait;
    [SerializeField] private float dodgeDelayTime;

    // 구르기 관련 속성
    private Vector3 movement;
    private bool isDodgeable = true;
    // 회피 상태
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

        // 이동 방향 벡터 
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        // 카메라의 회전을 기준으로 캐릭터의 새로운 방향 벡터를 구함
        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        // 최종 이동벡터를 계산함
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
