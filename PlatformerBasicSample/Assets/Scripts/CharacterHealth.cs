using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IHitable
{
    // 체력
    [SerializeField] protected int hp;

    // 사망 이펙트 프리펩
    [SerializeField] protected GameObject destroyEffectPrefab;

    // 사망 이펙트 Y 표시 위치
    [SerializeField] protected float destroyEffectYPos;

    // 피격 메소드
    public void Hit(int damage)
    {
        // 체력 감소
        hp -= damage;
        // 체력이 0이하면
        if(hp <=0)
        { 
            Die(); 
        }
    }

    // 사망 처리
    private void Die()
    {
        // 캐릭터 파괴 처리
        Vector3 effectPosition = new Vector3(transform.position.x, transform.position.y + destroyEffectYPos, transform.position.z);

        // 이펙트 생성
        GameObject effcet = Instantiate(destroyEffectPrefab, effectPosition, Quaternion.identity);
        Destroy(effcet, 2f);

        // 캐릭터 파괴
        Destroy(gameObject);
    }
}
