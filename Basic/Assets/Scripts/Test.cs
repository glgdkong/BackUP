using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Test : MonoBehaviour
{
    // 1. Class란 무엇인지 아는대로 상세하게 서술

    // Class란 사용자 정의 데이터 타입이다. 사용자가 class 내에 임의의 변수와 메소드를 선언하여 사용하기 위해 선언하는 것

    // 2. MonoBehaviour를 상속 받은 Class와 상속받지 않은 Class의 차이점

    // MonoBehaviour를 상속 받지 않은 Class는 유니티의 이벤트 메소드를 사용할 수 없으며 게임 오브젝트에 컴포넌트로 추가 할 수 없고 유니티 API에 접근할 수 없다.
    // 또한 class와 메소드에 Unity 스크립트 메시지가 사라진다

    // 3. 변수란 무엇인지 서술

    // 변수란 값을 저장하는 공간을 의미하며 언제, 어디서든 값을 변경할 수 있다.

    // 4. 외부에 공개하고 문자열 형 데이터를 다루는 변수 myName을 선언

    public string myName;

    // 5. 4번에서 선언한 변수를 Start() 함수에서 임의의 값으로 초기화.

    private void Start()
    {
        myName = "서원빈";
        PrintNum711();
        AddListNum();
    }

    // 6. F1키를 눌렀을 때 1000부터 1까지 출력하는 코드 작성
    
    private void PrintNum()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 1000; i >= 1; i--)
            {
                Debug.Log((i));
            }
        }
    }

    // 7. 1부터 10000까지의 수 중 7또는 11의 배수들의 합.
    private void PrintNum711()
    {
        int numResult = 0;
        for (int i = 1; i <= 10000; i++)
        {
            if (i % 7 == 0 || i % 11 == 0)
            {
                numResult += i; // 결과값 11046042
            }
        }
        Debug.Log(numResult);
    }
    // 8. 외부에 공개하지 않고 리턴 타입이 Vector3이며 실수 형 매개변수 3개를 필요로 하는 함수 작성,
    //    매개변수로 들어온 3개의 실수 값을 Vector3의 형식에 맞게 대입하여 리턴

    private Vector3 ToVector(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }

    // 9. 실수형 데이터를 다루는 배열을 선언과 동시에 1.24f, 321.51f, 1238.5f로 초기화

    private float[] floatNum = { 1.24f, 321.51f, 1238.5f };

    // 10. 정수를 다루는 리스트 A와 B를 서언

    List<int> listNumA = new List<int>();

    List<int> listNumB = new List<int>();

    // 11. 리스트 A에 1부터 100까지 추가

    public void AddListNum()
    {
        for (int i = 0; i < 100; i++)
        {
            listNumA.Add(i+1);
            Debug.Log($"리스트A 에 값 추가 : {listNumA[i]}");
            
        }
    }

    // 12. 정수형 랜덤의 범위로 0부터 99까지 나오도록 작성 후, 나온 랜덤 값을 인덱스로 활용하여
    //     리스트A에서 해당 인덱스의 원소를 제거하고 리스트 B에 추가하기.
    public void RandomRemoveAndAddB()
    {
        int randomNum = Random.Range(0, listNumA.Count);
        Debug.Log($"랜덤 인덱스 번호 {randomNum}");
        listNumB.Add(listNumA[randomNum]);
        Debug.Log($"리스트B에 요소추가 값 : {listNumA[randomNum]}");
        Debug.Log($"리스트A {randomNum} 인덱스에서 {listNumA[randomNum]}값 제거");
        listNumA.RemoveAt(randomNum);
    }

    // 13. 12번 문제를 F2키를 누를 때 마다 실행 되도록 수정하기

    private void RandomRemoveAndAddBRepeat()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            RandomRemoveAndAddB();
        }
    }

    // 14. 리스트 A 원소들의 순서를 반전시키기

    public void ReverseListA()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            listNumA.Reverse();
            Debug.Log("리스트 A 반전");
        }
    }

    // 15. 리스트A의 원소를 오름차순 정렬하기

    public void SortListA()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {    
            listNumA.Sort();
            Debug.Log("리스트 A 오름차순 정렬");
        }
    }

    private void Update()
    {
        PrintNum();
        RandomRemoveAndAddBRepeat();
        PrintListNumA();
        PrintListNumB();
        ReverseListA();
        SortListA();
    }

    private void PrintListNumA()
    {
        int i = 0;
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (var item in listNumA)
            {
                Debug.Log($"[{i++}]번째 리스트A 값 : {item}");
            }
        }
    }

    private void PrintListNumB()
    {
        int i = 0;
        if (Input.GetKeyDown(KeyCode.F4))
        {
            foreach (var item in listNumB)
            {
                Debug.Log($"[{i++}]번째 리스트B 값 : {item}");
            }
        }
    }
}
