using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 흭득 처리 컴포넌트
public class PickUpItem : MonoBehaviour
{
    // 게임 매니저 컴포넌트 참조 변수
    [SerializeField] private GameManager gameManager;

    // 아이템 흭득 이펙트 프리펩
    [SerializeField] private GameObject pickUpEffectPrefab;

    // 아이템 흭득 사운드 재생기(컴포넌트) 참조
    [SerializeField] private AudioSource pickUpAudioSource;

    // Trigger가 활성화된 콜라이더와 충돌 됨(유니티 이벤트 메소드)
    private void OnTriggerEnter(Collider collider)
    {
        // 흭득한(충돌한) 게임오브젝트의 태그가 Slime이면
        if(collider.tag.Equals("Item"))
        {
            gameManager.TimeUp(10); // 10초 증가

            // 오디오 재생기 실행
            pickUpAudioSource.Play();

            // 흭득한 아이템 게임 오브젝트 최상위 게임오브젝트를 파괴
            //Destroy(collider.transform.parent.gameObject);
            Destroy(collider.transform.root.gameObject);
        }
    }
}
