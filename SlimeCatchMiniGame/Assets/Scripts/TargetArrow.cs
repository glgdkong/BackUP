
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 가장 가까운 슬라임을 가리키는 컴포넌트
public class TargetArrow : MonoBehaviour
{
    [SerializeField] private GameObject target = null; // 추적 대상 참조

    [SerializeField] private float findDelayTime; // 찾는 주기(시간)

    [SerializeField] private Renderer arrowRenderer; // 화살표 렌더러 참조

    [SerializeField] private float rotateSpeed; // 회전속도

    // 가장 가까운 슬라임을 찾는 메소드
    public GameObject FindTargetSlime()
    {
        GameObject targetSlime = null;

        // GameObject[] 게임오브젝트들 = GameObject.FindGameObjectWithTag("태그");
        // -> 지정한 태그가 설정된 게임오브젝트 목록을 찾음 (배열)

        GameObject[] slimes = GameObject.FindGameObjectsWithTag("Slime");

        float shortesDistance = Mathf.Infinity;

        for (int i = 0; i < slimes.Length; i++)
        {
            // float 거리 = Vector3.Distance(오브젝트1위치, 오브젝트2위치);
            // -> 두개의 게임오브젝트 사이의 거리

            // 플레이어와 순번의 슬라임간의 거리를 측정함
            float distance = Vector3.Distance(transform.position, slimes[i].transform.position);
            
            // 현재 측정한 거리가 이전 최소 거리보다 작다면
            if(distance < shortesDistance)
            {
                // 현재 거리를 최소 거리로 설정
                shortesDistance = distance;
                targetSlime = slimes[i]; // 추적 대상 슬라임을 설정
            }
        }
        return targetSlime;
    }

    // 타겟 찾기 코루틴 : 일정한 시간 주기로 슬라임 타겟을 찾기 위해(지연 체크 필요)
    IEnumerator TargetArrowCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(findDelayTime); // 시간 지연

            // 가장 가까운 슬라임을 찾음
            target = FindTargetSlime();
            if (target != null)
            {
                //Debug.Log($"가장 가까운 슬라임 : {target.name}({target.transform.position})");
            }
        }
    }
    private void Start()
    {
        // 시간지연을 가지면서 타겟을 반복적으로 찾느 코루틴을 생성함
        StartCoroutine(TargetArrowCoroutine());
    }
    private void Update()
    {
        if (target == null)
        {
            arrowRenderer.enabled = false;
        }
        else
        {
            arrowRenderer.enabled = true;

            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            //Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            transform.rotation = newRotation;
        }
    }
}
