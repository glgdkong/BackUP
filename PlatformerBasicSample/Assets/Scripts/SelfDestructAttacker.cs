using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌 데미지 부여 자폭 게임오브젝트 컴포넌트
public class SelfDestructAttacker : Attacker
{
    // 소멸 처리 메소드 재정의
    public override void Disappear()
    {
        Destroy(gameObject);
    }

}
