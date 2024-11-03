using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHitAble
{
    // 최대 체력
    [SerializeField] protected int maxHp;

    // 현재 체력
    [SerializeField] protected int currentHp;

    // 넉백 시간
    [SerializeField] private float knockbackTime;

    // 캐릭터 컨트롤러 컴포넌트
    private CharacterController cc;

    // 애니메이터 컴포넌트
    private Animator animator;

    // 피격 파티클 컴포넌트
    [SerializeField] protected ParticleSystem hitParticle;

    private InputDodgeMovement dodge;

    private InputGuard guard;

    // 피격 여부
    private bool isHit;
    public bool IsHit { get => isHit; set => isHit = value; }

    private bool isDeath;
    public bool IsDeath { get => isDeath; set => isDeath = value; }

    private void Awake()
    {
        currentHp = maxHp;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();    
        dodge = GetComponent<InputDodgeMovement>();
        guard = GetComponent<InputGuard>();
    }
    private void Start()
    {
        IsHit = false;
        IsDeath = false;
    }
    public void Hit(int damage, float knockbackForce)
    {
        // 회피 상태가 아닐때
        if(!dodge.IsDodgeing)
        {
            if (!guard.IsGuarding)
            {
                // 체력 감소 처리
                currentHp -= damage;
                currentHp = Mathf.Clamp(currentHp, 0, maxHp);

                // 캐릭터의 체력이 0보다 작거나 같으면
                if (currentHp <= 0)
                {
                    // 사망 
                    IsDeath = true;
                    animator.SetBool("Death", IsDeath);

                }
                else
                {
                    // 피격 상태 잠금
                    IsHit = true;
                    // 피격 효과 처리
                    hitParticle?.Play();
                    StartCoroutine(ApplyHitKnockback(-transform.forward, knockbackForce));
                }
            }
            else
            {
                StartCoroutine(GuardHitCoroutine(-transform.forward, knockbackForce));
            }
        }
    }

    private IEnumerator ApplyHitKnockback(Vector3 hitDirection, float force)
    {
        // 피격 상태 잠금
        //IsHit = true;

        // 피격 애니메이션 재생
        animator.SetBool("Hit", IsHit);
        // 넉백 이동 처리 진행
        float timer = 0f;

        while (timer < knockbackTime)
        {
            cc.Move( -transform.forward * (force * Time.deltaTime));
            timer += Time.deltaTime;
            yield return null;
        }

        // 피격 상태 해제
        IsHit = false;
        // 피격 애니메이션 종료
        animator.SetBool("Hit", IsHit);

    }

    private IEnumerator GuardHitCoroutine(Vector3 hitDirection, float force)
    {
        animator.SetBool("Hit", true);
        float timer = 0f;

        while (timer < knockbackTime)
        {
            cc.Move(-transform.forward * ((force / 2) * Time.deltaTime));
            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("Hit", false);

    }
}
