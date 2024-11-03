using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int platformCount = 3;

    // 발판 생성 간격 => 생성 간격을 랜덤으로 하겠다는 의미
    private float spawnTimeMin = 1.25f;
    private float spawnTimeMax = 2.25f;
    private float spawnTime;
    private float lastSpawnTime;

    private float yPosMin = -3.5f;
    private float yPosMax = 1.5f;
    private float posX = 20f;

    // 생성 된 플랫폼 관리
    private GameObject[] platforms;
    // 현재 플랫폼의 인덱스
    private int currentIndex = 0;

    // 오브젝트 풀링 : 재사용 가능한 오브젝트를 재활용하는 기법
    // pool : 모임, 집단

    // 생성과 파괴는 메모리를 많이 소모함.
    // 오브젝트 생성 : instantiate
    // 오브젝트 파괴 : destroy

    // 임시로 발판을 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0f, -25f);

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // platforms 배열 초기화 크기는 platformCount;
        // 배열의 공간을 만들어준 상태
        platforms = new GameObject[platformCount];

        // 배열에 플랫폼 프리펩을 생성하여 할당해보세요
        for (int i = 0; i < platforms.Length; i++)
        {
            // Instantiate(생성할 오브젝트, 생성 위치, 생성 회전값)
            // Quaternion.identity(별도의 회전값이 필요하지 않을 때 넣어주는 값 = 기본값)
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        spawnTime = 0f;
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오버상태일 때 더이상 발판 생성하지 않도록
        if (gameManager.isGameover) return;
        // 발판 생성 로직 아래에 작성할 예정
        // Time.time : 현재 시간 (시작후 현재 프레임까지의 시간 누적)
        // 0 >= 0 + 0
        if(Time.time >= lastSpawnTime + spawnTime)
        {
            // lastSpawnTime에 현재 시간 초기화
            lastSpawnTime = Time.time;

            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

            //발판의 높이
            float posY = Random.Range(yPosMin, yPosMax);
            
            // 장애물 랜덤 생성을 하기 위해 한번 껏다가 켜준다
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            
            platforms[currentIndex].transform.position = new Vector2(posX, posY);

            // 인덱스가 최대 크기를 넘어가지 않고, 순회해야 한다. (0,1,2)
            /*currentIndex++;
            if (currentIndex >= platforms.Length) currentIndex = 0;*/

            // 나머지 연산자 활용한 인덱스 순회 (우리 코드에서는 전위식 사용해야 한다.)
            currentIndex = ++currentIndex % platformCount;
        }
    }
}
