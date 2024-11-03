using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] protected float startSpawnTime; // ���� ���� �����ð�
    [SerializeField] protected float repeatSpawnTime; // �ݺ� ���� �����ð�
    [SerializeField] protected GameObject[] slimePrefab; // ������ ������� ����
    [SerializeField] protected float randomRange;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating(�޼ҵ� �̸�, ���۽ð�, �ݺ��ð�);
        // ������ �ð����� �޼ҵ带 �ݺ� ���� �����ִ� API
        InvokeRepeating("Spawn", startSpawnTime, repeatSpawnTime);
    }

    public void Spawn()
    {
        // ���� ���� ��ġ
        Vector3 spawnPosition = new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
        Instantiate(slimePrefab[Random.Range(0, slimePrefab.Length)], spawnPosition, Quaternion.identity);
    }
}
