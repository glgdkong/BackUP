using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{

    // List : 동일한 데이터 타입 여러 개를 하나으 변수로 관리하고 싶을 때 사용.
    // 리스트는 게임 중에도 크기가 변할 수 있습니다. (배열과 가장 큰 차이점)
    // 즉, 게임 중에 동적으로 크기가 변하는 것을 구현할 때 사용

    // 리스트의 선언
    // 접근제한자 List<데이터타입> 변수명 = new List<데이터타입>();
    // 리스트는 크기 선언이 없습니다.
    public List<int> intList = new List<int>();

    void Start()
    {
        // 리스트에 원소를 추가 하기전에 접근을 시도할 시에
        // 리스트에 원소를 아직 추가하지 않았기 때문에 out of range 오류가 뜨게된다
        //intList[0] = 1;

        // 리스트에 원소 추가 List.Add(값);
        intList.Add(0);

        // 리스트의 원소에 접근 방법은 배열과 동일하다.
        intList[0] = 1;

        // 리스트에 현재 1이 들어가 있습니다.
        // 2부터 100 까지 마저 채워 보세요

        // List.Count = 리스트 안에 있는 원소의 개수
        for (int i = 2; i <= 100; i++)
        {
            intList.Add(i);
        }

        // 리스트에 총 100개의 원소가 들어가 있음.
        //Debug.Log(intList.Count);

        // 1 ~ 100 이 들어가 있습니다.
        // 100 ~ 1이 들어가도록 수정해보세요.

        // 정방향
        for (int i = 0; i < intList.Count; i++)
        {
            intList[i] = intList.Count - i;
        }

        // 역순으로 수정
        /*for (int i = 99; i >= 0; i++)
        {
            intList[i] = intList.Count - i;
        }*/

        // 1. 리스트의 원소 제거
        // 검색한 값이 나왔을 때 가장 첫번째 원소를 제거
        // List.Remove(값);
        // 즉 값에 해당하는 배열을 찾아 가장 낮은 배열을 먼저 제거
        // 100 ~ 1

        intList.Remove(7);
        

        // 2. 리스트의 원소 제거
        // List.RemoveAt(index);
        // index에 해당하는 원소를 제거 
        // 즉 index번째에 해당하는 배열을 제거 
        intList.RemoveAt(30);

        // 리스트의 원소를 제거하면 공백의 자리로 남는것이 아니라 자리 자체도 사라진다.
        // 즉 리스트의 카운트가 줄어든다.

        // 3. 리스트의 원소 제거 
        // 모든 원소를 제거
        intList.Clear();
        
        for (int i = 0; i <= 99; i++)
        {
            intList.Add(i + 1);
        }

        // 원소의 순서를 거꾸로 뒤집음
        intList.Reverse();

        // 오름차순 정렬
        intList.Sort();

    }
}
