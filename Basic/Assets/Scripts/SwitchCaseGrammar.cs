using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwitchCaseGrammar : MonoBehaviour
{
    // switch ~ case 문
    // switch : 분기하다, case : 경우.
    // 경우에 의해 분기하는 코드

    private int inputNumber;
    private string myName;
    private string weather;

    void Start()
    {
        // inputNumber의 경우의 수가 100가지라면 case 100가지를 만들어야 하는데
        // 효율적이지 않다.
        // 경우의 수가 많지 않고 정확하게 정해져 있을 때 사용한다.
        switch (inputNumber)
        {
            case 0:
                Debug.Log("0");
                break; // break; : switch 문을 끝낸다.

            case 1:
                Debug.Log("1");
                break;
                    
            case 2:
                Debug.Log("2");
                break;
                    
            case 3:
                Debug.Log("3");
                break;
                    
            case  4:
                Debug.Log("4");
                break;

            default:
                Debug.Log("0 ~ 4 가 아닌 수");
                break;
        }
        switch (myName)
        {
            case "강철웅":
                Debug.Log("강사님의 이름입니다");
                break;
            case "서원빈":
                Debug.Log("원빈 학생의 이름입니다");
                break;
            case "남택연":
                Debug.Log("택연 학생의 이름입니다");
                break;
            default:
                Debug.Log("강철웅, 원빈, 택연 그 누구의 이름도 아닙니다");
                break;
        }
        switch (weather)
        {
            case "비":
            case "눈":
                Debug.Log($"오늘의 날씨는 {weather}이(가) 예상되므로 우산을 챙기는 것을 추천합니다");
                break;
            case "태풍":
                Debug.Log($"오늘의 날씨는 {weather}이(가) 예상되므로 가벼운 옷차림을 추천합니다");
                break;
            case "폭염":
                Debug.Log($"오늘의 날씨는 {weather}이(가) 예상되므로 따뜻한 옷차림을 추천합니다");
                break;
            case "폭설":
                Debug.Log($"오늘의 날씨는 {weather}이(가) 예상되므로 따뜻한 옷차림을 추천합니다");
                break;
            case "황사":
                Debug.Log($"오늘의 날씨는 {weather}이(가) 예상되므로 따뜻한 옷차림을 추천합니다");
                break;
        }

    }

}
