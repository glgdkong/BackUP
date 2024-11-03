using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // 장애물을 활성화, 비활성화 시킨다.
    [SerializeField] private GameObject[] obstacles; // 장애물 관리, 장애물 3개 만들었어요.
    private bool isStepped = false; // 발판을 플레이어가 밟았는지 여부
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // 게임 오브젝트가 활성화 될 때마다 호출되는 유니티 이벤트 함수
    // 발판 오브젝트가 활성화 되었다는 것이 어떤 의미? => 발판이 새로 생성되었음
    private void OnEnable() // Instantiate으로 생성되는 경우에도 호출이 된다
    {
        
        isStepped = false;

        // 1/3 확률로 하나의 장애물 활성화, 1/9 확률로 두개의 장애물 활성화, 1/27 확률로 세개의 장애물 활성화 

        // 배열의 길이만큼 반복문 실행
        for (int i = 0; i < obstacles.Length; i++)
        {
            // 배열의 길이의 값 사이 번호에서 랜덤으로 뽑은 값이 0 이면 (1/3 확률을 구현한것)
            if(Random.Range(0, obstacles.Length) == 0)
            {
                // i번째 장애물 게임오브젝트 활성화
                obstacles[i].SetActive(true);
            }
            else // 아니라면
            {
                // i번째 장애물 오브젝트 비활성화
                obstacles[i].SetActive(false);
            }
        }
    }

    // 플레이어가 발판에 착지했을 때 점수를 추가
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Player") && !isStepped)
        {
            // Find류 함수는 하이어라키에 있는 모든 오브젝트를 검사한다.
            // 효율이 매우 좋지 않다.
            // 꼭 필요한 경우에만 사용해야한다
            //GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(2);
            // 발판 하나 당 1회만 점수 추가 하도록 수정
            isStepped = true;
        }
    }
}
