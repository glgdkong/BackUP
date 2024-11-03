using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] protected float startSpawnTime; // 최초 생성 지연시간
    [SerializeField] protected float repeatSpawnTime; // 반복 생성 지연시간
    [SerializeField] protected GameObject[] slimePrefab; // 슬라임 프리펩들 참조
    [SerializeField] protected float randomRange;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating(메소드 이름, 시작시간, 반복시간);
        // 지정된 시간마다 메소드를 반복 실행 시켜주는 API
        InvokeRepeating("Spawn", startSpawnTime, repeatSpawnTime);
    }

    public void Spawn()
    {
        // 랜덤 생성 위치
        Vector3 spawnPosition = new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
        Instantiate(slimePrefab[Random.Range(0, slimePrefab.Length)], spawnPosition, Quaternion.identity);
    }
}
