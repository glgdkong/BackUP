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

        if (tile.IsBuilted) return; // 이미 타워가 건설 됐다면 리턴

        // 생성할 게임오브젝트, 위치, 회전 Quaternion.identity(기본 회전값 : 별도의 회전 값 주지 않을 때)
        Instantiate(towerPrefab, ground.position, Quaternion.identity, towerGroup);

        tile.IsBuilted = true; // 건설 후 건설됨 처리
    }
}
