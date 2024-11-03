using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private TowerBuilder towerBuilder;

    // 캐싱
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;


    void Start()
    {
        // Detector와 TowerBuilder 컴포넌트는 동일한 게임오브젝트에 있다.
        towerBuilder = GetComponent<TowerBuilder>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭 버튼을 눌렀을때
        if (Input.GetMouseButtonDown(0))
        {
            // 광선 정의
            // 마우스 위치로 부터 발사되는 광선
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 광선 충돌 지점의 정보
            //RaycastHit hit;

            // Raycast(광선, 어느 변수에 정보를 전달할지?, 거리)
            // 충돌체에 충돌한다면 true, 아니라면 false를 반환
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag("Ground"))
                {
                    towerBuilder.BuildTower(hit.transform);
                }
            }
        }
    }
}
