using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trail 렌더러 컴포넌트 활성 비활성 처리
public class TrailOnOff : MonoBehaviour
{
    // Trail Renderer 컴포넌트 참조
    [SerializeField] private TrailRenderer trailRenderer;
    
    public void TrailOn()
    {
        // 트레일 렌더러 활성화
        trailRenderer.emitting = true;
    }
    public void TrailOff()
    {
        // 트레일 렌더러 비활성화
        trailRenderer.emitting = false;
    }
}
