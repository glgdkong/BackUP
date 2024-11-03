using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Transform towerGroup;
    Tile tile;

    public void BuildTower(Transform ground)
    {
        if(tile == null) tile = ground.GetComponent<Tile>();

        if (tile.IsBuilted) return; // �̹� Ÿ���� �Ǽ� �ƴٸ� ����

        // ������ ���ӿ�����Ʈ, ��ġ, ȸ�� Quaternion.identity(�⺻ ȸ���� : ������ ȸ�� �� ���� ���� ��)
        Instantiate(towerPrefab, ground.position, Quaternion.identity, towerGroup);

        tile.IsBuilted = true; // �Ǽ� �� �Ǽ��� ó��
    }
}
