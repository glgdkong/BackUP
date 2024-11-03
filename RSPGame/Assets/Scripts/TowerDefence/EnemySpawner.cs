using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInvterval = 1f; // ���� �ֱ�
    [SerializeField] private Transform[] wayPoinys; // �̵� ���
    [SerializeField] private Transform EnemyGroup;

    private WaitForSeconds spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = new WaitForSeconds(spawnInvterval); // 10 �Ҹ� (ĳ�� : �ݺ��ؼ� ����ϴ� �����͸� �̸� ����)

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ������ų �� �ִ�.
    // ���� ������ �ʿ��� �� ���
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject temp = Instantiate(enemyPrefab, EnemyGroup); // ���� �� ���ʹ� �׷��� �ڽ����� �����Ͽ� ���̾��Ű ����
            Enemy enemy = temp.GetComponent<Enemy>();
            enemy.Setting(wayPoinys);

            // new ������ : ������ ������ Ÿ���� �ν��Ͻ��� �� ���.
            // �ν��Ͻ� -> �޸𸮿� �ö󰣴� -> ��� �ȴ�.
            yield return spawnTime; // 1�ʸ� ����. ����� 1�ʸ��� �޸� �Ҹ� ��.
        }
    }
}
