using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 딕셔너리(해시테이블) 자료구조
// - 키-값 쌍으로 데이터를 저장하는 자료구조로 키값을 통한 빠른 검색 및 추가 삭제 등에 용이하다.
// - 같은 키값으로는 복수개를 저장할 수 없다.
// - 키값을 이용한 탐색의 시간복잡도는 O(1)로 매우 빠른 검색과 탐색 기능을 제공한다.

// 딕셔너리의 종류
// - Dictionary<T> : 일반적인 딕셔너리 전체적인 삽입, 삭제, 조회에 사용되는 딕셔너리
//   -> 검색 : 평균 시간복잡도 O(1)
//   -> 삽입 : 평균 시간복잡도 O(1)
//   -> 삭제 : 평균 시간복잡도 O(1)

// - SortedDictionary<T> : 이진탐색트리 기반의 키정렬이 수행된 딕셔너리
//   -> 검색 : 평균 시간복잡도 O(log n)
//   -> 삽입 : 평균 시간복잡도 O(log n)
//   -> 삭제 : 평균 시간복잡도 O(log n)
// * 장점 : 정렬된 키 기준으로 목록을 관리하고 싶을 때

// 시간 복잡도 선을 순서 : O(1) > O(log n) > O(n)

// * 이진트리 : 각 노드가 최대 두개의 자식 노들르 가지는 자료 구조로 각 노드는 왼쪽 자식과 오른쪽 자식으로 분기된다.
// - 이진 트리 규칙
//      -> 왼쪽 자식 노드에는 부모노드 보다 작은 값이 있음
//      -> 오른쪽 자식 노드에는 부모노드 보다 큰 값이 있음
// - 이진 탐색 트리 : BST(Binary Serach Tree)
// * 현재 SortedDictionary의 탐색 알고리즘은 이진탐색트리의 알고리즘을 보완한 레드-블랙 트리 알고리즘을 사용함


public class DictionaryAPITest : MonoBehaviour
{
    //Dictionary<string, int> strItemMap = new Dictionary<string, int>();
    SortedDictionary<string, int> strItemMap = new SortedDictionary<string, int>();


    void Start()
    {
        // 아이템 정보를 딕셔너리에 추가함("아이템 이름", 보유갯수)
        strItemMap.Add("바나나", 10);
        strItemMap.Add("물풍선", 5);
        strItemMap.Add("미사일", 3);
        strItemMap.Add("얼음벽", 30);
        strItemMap.Add("우주선", 3);

        // 아이템의 갯수 출력
        Debug.Log($"딕셔너리 아이템 갯수 : {strItemMap.Count}");

        // 아이템 정보를 순차적으로 출력함 (인덱싱 순서 아님 - 비순차)
        foreach (KeyValuePair<string, int> item in strItemMap)
        {
            //Debug.Log($"strItemMap[\"{item.Key}\"] = {item.Value}");
            Debug.Log($"strItemMap[\"{item.Key}\"] = {strItemMap[item.Key]}");
        }
        
        int itemCount;
        // 현재 딕셔너리에 미사일키를 가진 요소가 있다면 해당 요소값을 itemCount 변수에 저장해서 받아옴(out)
        if (strItemMap.TryGetValue("미사일", out itemCount))
        {
            Debug.Log($"미사일 아이템 갯수 : {itemCount}");
        }

        // try {... 예외구문 ...} catch (예외변수) {... 예외처리 ...}
        try
        {
            Debug.Log(strItemMap["아무키"]); //키가 없는 요소를 접근하면 예외 발생
        }
        catch (KeyNotFoundException ex)
        {
            Debug.Log($"아이템 접근 예외 발생 : {ex.Message}");
        }

        // 현재 딕셔너리에 얼음벽키를 가진 요소가 있다면 
        if (strItemMap.ContainsKey("얼음벽"))
        {
            Debug.Log($"얼음벽 아이템 갯수 : {strItemMap["얼음벽"]}");
        }

        // 바나나 키를 가진 아이템을 제거함
        if (strItemMap.Remove("바나나"))
        {
            Debug.Log("바나나 아이템을 제거함");
        }

        Debug.Log($"딕셔너리 아이템 갯수 : {strItemMap.Count}");

        foreach (KeyValuePair<string, int> item in strItemMap)
        {
            //Debug.Log($"strItemMap[\"{item.Key}\"] = {item.Value}");
            Debug.Log($"strItemMap[\"{item.Key}\"] = {strItemMap[item.Key]}");
        }

        Debug.Log("딕셔너리의 모든 아이템 제거===============");
        // 딕셔너리의 모든 아이템 제거
        strItemMap.Clear();

        Debug.Log($"딕셔너리 아이템 갯수 : {strItemMap.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
