using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 리스트(자료구조)
// - 동적 배열 형태로 중간 데이터의 삽입 삭제가 필요할 때 사용할 수 있는 자료구조

// * 리스트 종류
// - List<T> : 일반적인 리스트로 적당한(?) 삽입 삭제가 있을때 배열처럼 사용하는 리스트 (LinkedList보다 삽입삭제시 성능이 떨어짐)
//   -> 삽입/삭제 속도 : 시간복잡도 (O(n)) 
//   -> 접근속도 : O(1) <= 매우 빠름

// - LinkedList<T> : 많은 양의 삽입 삭제가 필요할 때 양방향 연결리스트로 오리지널 리스트의 개념으로 사용하는 리스트
//   (List보다 인덱스 접근시 성능이 떨어짐)
//   -> 삽입/삭제 속도 : 시간복잡도 (O(1)) <= 매우 빠름 <= 전제 : 삽입삭제의 대상이 되는 요소의 참조를 알고 있을때
//   -> 접근속도 : O(n)

public class ListAPITest : MonoBehaviour
{
    List<string> strList = new List<string>();
    private int a;

    void Start()
    {
        // 리스트에 문자열 요소 추가
        strList.Add("물풍선");
        strList.Add("바나나");
        strList.Add("미사일");
        strList.Add("얼음벽");
        strList.Add("우주선");

        // 리스트에 저장된 모든 요소를 출력함
        // 리스트.Count : 리스트의 요소의 갯수
        for (int i = 0; i < strList.Count; i++)
        {
            // 리스트[번째] 형식으로 배열처럼 요소 접근이 가능함
            Debug.Log($"리스트(동적배열)에 저장된 아이템 요소 이름 : {strList[i]}");
        }

        Debug.Log("리스트 중간에 데이터를 삽입함 (3번째에 하트생명 아이템 추가)===============");

        // 미사일과 얼음벽 사이에 하트생명 아이템 문자열을 추가 (동적 데이터 추가)
        strList.Insert(3, "하트생명");

        for (int i = 0; i < strList.Count; i++)
        {
            // 리스트[번째] 형식으로 배열처럼 요소 접근이 가능함
            Debug.Log($"리스트(동적배열)에 저장된 아이템 요소 이름 : {strList[i]}");
        }

        Debug.Log("리스트 중간에 데이터를 삭제함 (바나나, 물풍선(0번째) 아이템 삭제)===============");

        strList.Remove("바나나");    // 바나나 문자열 데이터 항목 삭제
        strList.RemoveAt(0);        // 0번째 데이터 삭제

        // 리스트 또는 배열을 구분기호가 있는 문자열로 출력함
        string printStr = string.Join(", ", strList);

        Debug.Log($"리스트 요소 출력 : {printStr}");

        
        Debug.Log($"리스트 하트생명 아이템의 인덱스 : {strList.IndexOf("하트생명")}");

        // 문자열값이 얼음벽 또는 미사일일 경우 해당 데이터를 삭제함
        strList.RemoveAll(x => (x == "얼음벽" || x == "미사일"));

        printStr = string.Join(", ", strList);

        Debug.Log($"리스트 요소 출력 : {printStr}");

        Debug.Log("리스트의 모든 데이터를 제거 ==================");
        
        // 리스트안의 모든 데이터를 제거함
        strList.Clear();

        Debug.Log($"리스트의 요소 갯수 : {strList.Count}");
    }
}
