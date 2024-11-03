using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 무얼 작성할지 모를때?
    // 어떤 기능을 만들 건지를 생각해보자.

    // 물리
    private Rigidbody2D playerRigidbody;
    // 사운드
    private AudioSource audioSource;
    // 애니메이션
    private Animator animator;

    // 점프 관련
    public float jumpForce = 700f;
    private int jumpCount = 2;
    private bool isGround = false;
    private int maxJumpCount;

    // 죽음 관련
    public AudioClip dieClip; // 죽음 사운드 클립
    private bool isDie = false;
    // 이동 속도
    public float movementSpeed;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        animator = GetComponent<Animator>();
        maxJumpCount = jumpCount;

    }

    // 모든 함수는 반환(리턴)이 되어야 끝난다.
    void Update()
    {
        // 리턴을 해주면 해당 함수가 종료되므로 더이상 아래 작성한 코드가 실행되지 않는다.
        if (isDie) return; // 리턴 타입이 없는 void 함수 또한 사실 이return 생략되어 있는 것이다.
        Jump();
    }
    private void Jump()
    {
        // SetBool ("파라미터", bool값)
        animator.SetBool("IsGround", isGround);
        // 점프 가능
        // 0~ 1 두 번 점프 가능
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            // 점프키 누를 때마다 1 씩 증가
            jumpCount--;
            // 리지드바디에 힘을 더함 (Y축으로 접프포스만큼)
            //playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x ,0); // 힘을 가하기 전에 속력을 0으로 초기화 한다.
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 점프 사운드 재생
            // Play() 현재 할당된 클립을 재생
            audioSource.Play();
        }
        // 키 입력의 상태는 크게 3가지로 구분
        // 눌렀을 때, 누르는 중, 뗄 때
        // 키를 뗄 때,  플레이어의 속력의 y값이 0보다 크다면
        // 플레이어가 상승 중일 때
        else if(Input.GetKeyUp(KeyCode.Space) && playerRigidbody.velocity.y > 0)
        {
            // playerRigidbody.velocity += playerRigidbody.velocity * 0.5f
            // 상승하려는 속력이 절반이 되기 때문에 더 낮은 지점에서 낙하하게 된다.
            playerRigidbody.velocity *= 0.5f;
        }

    }

    // 유니티가 제공하는 충돌 함수는 매개변수에 충돌 정보를 담아준다.

    // 물리충돌이 시작되었을 때 호출되는 유니티 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플랫폼의 상단에 충돌 했을 때만 동작하도록 수정해야 한다.
        // contacts 충돌 지점의 갯수, [0]번째 이기 때문에 가장 첫 지점 => 충돌 하자마자의 노말을 검사
        if (collision.contacts[0].normal.y > 0.7)
        {
            jumpCount = maxJumpCount;
            isGround = true;
        }
    }
    // 물리 충돌이 끝났을 떄
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
    // 논리 충돌이 시작 되었을 때 호출 되는 유니티 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 만약 충돌된 곳의 태그가 Dead라면
        if (collision.CompareTag("Dead"))
        {
            Die();
        }
    }
    private void Die()
    {
        // 죽음 애니메이션 재생
        animator.SetTrigger("ToDie");

        // 죽음 클립으로 교체
        audioSource.clip = dieClip;
        // 죽음 사운드 재생
        audioSource.Play();

        // 죽음 처리
        isDie = true;

        // FindObjectOfType<데이터타입>(); 데이터타입(컴포넌트)을 가지고 있는 게임오브젝트를 찾아준다.
        GameManager gameManeger = FindObjectOfType<GameManager>();
        gameManeger.Gameover();
    }
}
