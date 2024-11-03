using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectByHitCollisionColor : DetectByHitCollision
{
    // 충돌 대상 스프라이트렌더러 컴포넌트
    [SerializeField]protected SpriteRenderer spriteRenderer;

    // 충돌 색상효과 사용 유무
    [SerializeField]protected bool showHitColor;

    // 충돌 색상효과 표시 카운트
    [SerializeField]protected int showHitColorCount;

    // 충돌 색상효과 유지 시간
    [SerializeField]protected float showHitColorTime;

    // 충돌 색상효과 재생 중 여부
    private bool showing = false;

    protected override void HitProcess(Collider2D collider)
    {
        ShowHitColor();

        HitDamage(collider);
    }
    protected void ShowHitColor()
    {
        if (!showing)
        {
            StartCoroutine("HitShowColorCoroutine");
        }
    }

    // 피격 색상 변경 코루틴
    IEnumerator HitShowColorCoroutine()
    {
        showing = true;
        // 충돌 색상 효과 표시 카운트 만큼 색상 효과를 표시
        for (int i = 0; i < showHitColorCount; i++)
        {
            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(showHitColorTime);

            spriteRenderer.color = new Color(1f, 0f, 0f, 0.5f);

            yield return new WaitForSeconds(showHitColorTime);

            spriteRenderer.color = Color.white;
        }
        showing = false;
    }
}
