using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 함수(메소드) : 어떠한 기능 처리를 위해 만들어 놓은 코드
// 마이크로소프트, 유니티가 미리 만들어 놓은 함수들과 
// 사용자 필요에 의해 직접 만든 사용자 정의 함수가 있다.
// 코드의 가독성과 재사용을 용이하도록 한다.
// 함수는 호출해야 사용이 된다.

// 함수의 정의
// 1.접근제한자 2.리턴타입 3.함수명(4.매개변수) {}
// 함수 명 명명규칙 : 첫 글자가 대문자 이후 카멜표기법
public class Function : MonoBehaviour
{
    public float a;
    public float b;
    public float c;
    public int d;

    public string h;
    public string w;

    private int gold;

    private int arrowCount = 100;


    // 유니티 이벤트 함수, 파란색, Unity메시지
    // 유니티 이벤트 함수는 사용자가 호출하지 않아도 유니티에 의해 자동 호출된다.
    void Start()
    {
        /*// 함수의 사용
        // 함수명();
        // 다른 함수 내에서 호출하여 사용할 수 있다.
        PrintInfo();
        // 매개변수가 존재하는 함수는 매개변수를 넣어줘야 호출된다.
        Sum(a, b, c);

        //Debug.Log(gold);
        //gold = GetNumber(); // 100이라는 값이 들어있습니다.
        //Debug.Log(gold);

        // 코드의 실행 순서
        // 왼쪽에서 오른쪽으로, 동일한 컨텍스트 내에서는 위에서 아래로 실행

        // = 현실세계에서 '같다'라는 의미
        // 하지만 프로그래밍에서는 의미가 완전 다르다.
        // = 대입 연산자 : 오른쪽의 값을 왼쪽에 대입(할당)
        Debug.Log(IsDie());

        // 첫 번째 방법 디버그 로그에 그대로 함수 호출
        Debug.Log(HelloWorld(h, w));
        // 두 번째 방법 임시 변수 선언해서 디버그 로그 호출
        //string temp = HelloWorld(h, w);
        //Debug.Log(temp);
        d = 10;
        a = Random.Range(9f, 11f);
        Debug.Log(Equal(d, a));

        // 유니티 데이터 타입의 변수명은 이미 유니티가 정해 놓았다.
        // GameObject : 데이터 타입
        // gameObject : 게임 오브젝트 변수명
        // gameObject란 스크립트(컴포넌트)가 할당된 게임오브젝트를 의미한다.
        Debug.Log(GetName(gameObject));

        // Transform형 변수명은 -> transform
*/
        SetRandomPosition(gameObject);

    }



    void Update()
    {
        /*// 만약 회살 개수가 0 이하라면 함수 종료
        if (arrowCount <= 0) 
        { 
            return; 
        }

        ArrowShoot();*/
    }

    // 외부에 공개하지 않고 리턴타입이 없고 함수명은 알아서 지으세요. 매개변수가 없는 함수 정의하기.
    private void PrintInfo()
    {
        //PrintInfo();   // 재귀호출(같은 함수내에서 동일한 함수 호출)
        Debug.Log($"플레이어의 정보");
    }

    // 매개변수가 존재하는 함수
    // 매개변수 선언 방법 함수명(데이터타입 변수명)
    // 함수 실행의 준비물로 정수형 데이터타입 하나를 필요로 하는 형태.
    // 아래의 함수를 수정해보세요.
    // 외부에 공개하고 리턴 타입이 없고 실수형 매개변수 3개를 필요로하는 함수이고
    // 기능은 디버그 로그로 매개변수 3개를 모두 더한 값을 출력하는 기능.
    public void Sum(float a, float b, float c)
    {
        Debug.Log($"{a} + {b} + {c} = {a + b + c}");
    }

    // 리턴 타입이 존재하는 함수
    // 함수 정의할 떄 리턴 타입의 자리에 돌려받을 데이터 타입을 적어야 한다.
    // return 키워드를 사용하여 값을 반환해야 함수가 종료된다.
    // return 값; 의 형태로 사용
    public int GetNumber()
    {
        return 100;
    }

    // 외부에 공개하지 않고 논리형 데이터를 반환하고 매개변수가 없는 함수를 정의(함수명 알아서)
    private bool IsDie()
    {
        return false;
    }

    // 리턴 타입도 존재하고, 매개변수도 존재하는 함수
    // 외부에 공개하고 문자열 데이터를 반환하고 매개변수로 문자열 두 가지를 필요로 하는 함수(함수명 알아서)
    // 기능은 두 매개변수로 들어온 문자열들을 더한 값을 반환한다.
    public string HelloWorld(string hello, string world)
    {
        return hello + world;
    }

    // 함수와 리턴
    // 함수를 종료하려면 return을 해줘야 합니다.
    // 리턴타입이 없는 void함수의 경우
    // return이 생략이 되어있다.
    // return키워드를 사용하여 원하는 시점에 함수를 종료시킬 수 있다.

    private void ArrowShoot()
    {
        // 화살 쏘는 기능
        //활 쏠 때마다 화살 갯수 하나씩 줄어 듦
        arrowCount--;
        Debug.Log($"화살 발사 남은 화살({arrowCount})");
    }    

    // 외부에 공개하지 않고 논리형 데이터를 반환하고 매개변수로 정수형 하나와 실수형 하나를 필요로 하는 함수 작성
    
    private bool Equal(int a, float b)
    {
        return a == (int)b; 
    }

    // 기본 데이터 타입이 아닌, 유니티 데이터 타입을 사용한 함수
    // 외부에 공개하고 리턴 타입이 문자열이고 매개변수로 GameObject타입 하나를 필요로 하는 함수
    // 기능은 매개변수로 들어온 게임오브젝트의 이름을 반환
    public string GetName(GameObject gameObject)
    { 
        return gameObject.name;
    }

    // 외부에 공개하고 리턴 타입이 없고 매개변수로 GameObject타입 하나를 필요로하는 함수
    // 기능은 게임오브젝트 변수 안에 트랜스폼 변수 안에 position을 랜덤으로 바꾸는 기능.
    public void SetRandomPosition(GameObject setPosition)
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        setPosition.transform.position = new Vector3 (x, y, z);
    }

}
