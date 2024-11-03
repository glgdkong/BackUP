using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCircleCollision : MonoBehaviour
{
    [SerializeField] private ColorType colorType;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color[] circleColors;

    [SerializeField] private VerticalBounceMovement movement;

    [SerializeField] private GameObject[] destoryColorFxPrefabs;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failureSound;

    private GameManager gameManager; // 게임 관리자

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // 바운스 서클 랜덤 색상 변경 메소드
    public void RandomCircleColor()
    {
        // 색상 랜덤 인덱스(0,1)
        int colorIndex = Random.Range(0, circleColors.Length);

        // 바운스 서클의 색상을 변경
        spriteRenderer.color = circleColors[colorIndex];

        // 랜덤 인덱스를 칼라 타입(Enum) 타입으로 캐스팅 해서 현재 색상값을 저장함
        colorType.type = (ColorType.TYPE)colorIndex;
    }
    // 바운스 서클의 충돌 이벤트 메소드
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 바운스 서클이 블로커 서클과 충돌 했다면
        if(collision.gameObject.tag.Equals("Blocker"))
        {
            BlockerCircleCollision blockrCircle = collision.gameObject.GetComponent<BlockerCircleCollision>();
            // 충돌한 블로커 서클의 색상이 현재 바운스 서클 색상과 다르다면
            if (blockrCircle.ColorType.type != colorType.type)
            {
                // 실패 사운드 재생
                AudioSource.PlayClipAtPoint(failureSound, Camera.main.transform.position);

                // 게임 종료 처리
                gameManager.GameOver();

                // 바운스 서클 파괴 이펙트 참조
                GameObject fxPrefab = destoryColorFxPrefabs[(int)colorType.type];
                // 이펙트 생성
                GameObject colorFx =Instantiate(fxPrefab, transform.position, fxPrefab.transform.rotation);
                Destroy(colorFx, 1.5f); // 1.5초뒤에 이펙트 파괴

                // 바운스 서클 파괴
                Destroy(gameObject);
                return;
            }

            // 성공 사운드 재생
            AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position);

            // 게임 점수 부여
            gameManager.ScoreUp();

            // 애니메이터에 'Bouncing' 트리거 파라미터값 설정 -> 바운스 애니메이션 재생
            animator.SetTrigger("Bouncing");

            // 이동 반전
            movement.ReverseDirection();

            // 방향이 반전될 때 바운스 서클의 랜덤 색상 변경
            RandomCircleColor();
        }
    }
}
