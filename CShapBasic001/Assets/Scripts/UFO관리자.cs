using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UFO관리(컨트롤)하는 총관리 클래스 -> UFOController
public class UFO관리자 : MonoBehaviour
{
    // UFO이동컴포넌트참조변수
    public UFO이동컴포넌트 이동컴포넌트참조변수;

    // UFO타격컴포넌트참조변수
    public UFO타격컴포넌트 타격컴포넌트참조변수;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update 메소드 : 유니티가 현재 컴포넌트를 가진 게임오브젝트가
    //                  화면에 그려질때마다 미리 실행해주는 유니티 이벤트 메소드
    void Update()
    {
        // 이동컴포넌트참조변수를 통해 이동 컴포넌트(객체) 메모리에 접근해 입력이동처리 메소드를 실행함
        // -> 현재 UFO를 키입력을 통해 이동 처리
        이동컴포넌트참조변수?.입력이동처리하기();
    }

    // OnMouseDown 메소드 : 유니티가 현재 컴포넌트를 가진 게임오브젝트를
    //                      왼쪽 마우스 버튼으로 클릭할때 실행해 주는 유니티 이벤트 메소드
    // * 전제 조건 : 해당 게임 오브젝트에 충돌 영역이 형성되어 있어야 함
    private void OnMouseDown()
    {
        Debug.Log("유저가 UFO를 마우스 왼쪽버튼을 클릭했습니다.");

        // UFO타격컴포넌트의 타격하기 메소드를 실행(호출)
        타격컴포넌트참조변수?.타격하기();

    }


}
