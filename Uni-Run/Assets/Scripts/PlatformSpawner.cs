using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int platformCount = 3;

    // ���� ���� ���� => ���� ������ �������� �ϰڴٴ� �ǹ�
    private float spawnTimeMin = 1.25f;
    private float spawnTimeMax = 2.25f;
    private float spawnTime;
    private float lastSpawnTime;

    private float yPosMin = -3.5f;
    private float yPosMax = 1.5f;
    private float posX = 20f;

    // ���� �� �÷��� ����
    private GameObject[] platforms;
    // ���� �÷����� �ε���
    private int currentIndex = 0;

    // ������Ʈ Ǯ�� : ���� ������ ������Ʈ�� ��Ȱ���ϴ� ���
    // pool : ����, ����

    // ������ �ı��� �޸𸮸� ���� �Ҹ���.
    // ������Ʈ ���� : instantiate
    // ������Ʈ �ı� : destroy

    // �ӽ÷� ������ ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0f, -25f);

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // platforms �迭 �ʱ�ȭ ũ��� platformCount;
        // �迭�� ������ ������� ����
        platforms = new GameObject[platformCount];

        // �迭�� �÷��� �������� �����Ͽ� �Ҵ��غ�����
        for (int i = 0; i < platforms.Length; i++)
        {
            // Instantiate(������ ������Ʈ, ���� ��ġ, ���� ȸ����)
            // Quaternion.identity(������ ȸ������ �ʿ����� ���� �� �־��ִ� �� = �⺻��)
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        spawnTime = 0f;
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���������� �� ���̻� ���� �������� �ʵ���
        if (gameManager.isGameover) return;
        // ���� ���� ���� �Ʒ��� �ۼ��� ����
        // Time.time : ���� �ð� (������ ���� �����ӱ����� �ð� ����)
        // 0 >= 0 + 0
        if(Time.time >= lastSpawnTime + spawnTime)
        {
            // lastSpawnTime�� ���� �ð� �ʱ�ȭ
            lastSpawnTime = Time.time;

            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

            //������ ����
            float posY = Random.Range(yPosMin, yPosMax);
            
            // ��ֹ� ���� ������ �ϱ� ���� �ѹ� ���ٰ� ���ش�
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            
            platforms[currentIndex].transform.position = new Vector2(posX, posY);

            // �ε����� �ִ� ũ�⸦ �Ѿ�� �ʰ�, ��ȸ�ؾ� �Ѵ�. (0,1,2)
            /*currentIndex++;
            if (currentIndex >= platforms.Length) currentIndex = 0;*/

            // ������ ������ Ȱ���� �ε��� ��ȸ (�츮 �ڵ忡���� ������ ����ؾ� �Ѵ�.)
            currentIndex = ++currentIndex % platformCount;
        }
    }
}
