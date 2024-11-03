using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInvterval = 1f; // 생성 주기
    [SerializeField] private Transform[] wayPoinys; // 이동 경로
    [SerializeField] private Transform EnemyGroup;

    private WaitForSeconds spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = new WaitForSeconds(spawnInvterval); // 10 소모 (캐싱 : 반복해서 사용하는 데이터를 미리 저장)

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 지연시킬 수 있다.
    // 무언가 지연이 필요할 때 사용
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject temp = Instantiate(enemyPrefab, EnemyGroup); // 생성 시 에너미 그룹의 자식으로 생성하여 아이어라키 정리
            Enemy enemy = temp.GetComponent<Enemy>();
            enemy.Setting(wayPoinys);

            // new 연산자 : 참조형 데이터 타입을 인스턴싱할 때 사용.
            // 인스턴싱 -> 메모리에 올라간다 -> 사용 된다.
            yield return spawnTime; // 1초를 쉰다. 현재는 1초마다 메모리 소모 중.
        }
    }
}
