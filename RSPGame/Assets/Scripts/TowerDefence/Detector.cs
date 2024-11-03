using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private TowerBuilder towerBuilder;

    // ĳ��
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;


    void Start()
    {
        // Detector�� TowerBuilder ������Ʈ�� ������ ���ӿ�����Ʈ�� �ִ�.
        towerBuilder = GetComponent<TowerBuilder>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ��Ŭ�� ��ư�� ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ����
            // ���콺 ��ġ�� ���� �߻�Ǵ� ����
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // ���� �浹 ������ ����
            //RaycastHit hit;

            // Raycast(����, ��� ������ ������ ��������?, �Ÿ�)
            // �浹ü�� �浹�Ѵٸ� true, �ƴ϶�� false�� ��ȯ
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
