using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHitAble
{
    // �ִ� ü��
    [SerializeField] protected int maxHp;

    // ���� ü��
    [SerializeField] protected int currentHp;

    // �˹� �ð�
    [SerializeField] private float knockbackTime;

    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private CharacterController cc;

    // �ִϸ����� ������Ʈ
    private Animator animator;

    // �ǰ� ��ƼŬ ������Ʈ
    [SerializeField] protected ParticleSystem hitParticle;

    private InputDodgeMovement dodge;

    private InputGuard guard;

    // �ǰ� ����
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
        // ȸ�� ���°� �ƴҶ�
        if(!dodge.IsDodgeing)
        {
            if (!guard.IsGuarding)
            {
                // ü�� ���� ó��
                currentHp -= damage;
                currentHp = Mathf.Clamp(currentHp, 0, maxHp);

                // ĳ������ ü���� 0���� �۰ų� ������
                if (currentHp <= 0)
                {
                    // ��� 
                    IsDeath = true;
                    animator.SetBool("Death", IsDeath);

                }
                else
                {
                    // �ǰ� ���� ���
                    IsHit = true;
                    // �ǰ� ȿ�� ó��
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
        // �ǰ� ���� ���
        //IsHit = true;

        // �ǰ� �ִϸ��̼� ���
        animator.SetBool("Hit", IsHit);
        // �˹� �̵� ó�� ����
        float timer = 0f;

        while (timer < knockbackTime)
        {
            cc.Move( -transform.forward * (force * Time.deltaTime));
            timer += Time.deltaTime;
            yield return null;
        }

        // �ǰ� ���� ����
        IsHit = false;
        // �ǰ� �ִϸ��̼� ����
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
