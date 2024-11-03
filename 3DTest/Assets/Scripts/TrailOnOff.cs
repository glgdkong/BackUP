using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailOnOff : MonoBehaviour
{
    // 트레일 렌더러 컴포넌트 참조
    [SerializeField] TrailRenderer trail;
    public void TrailOn()
    {
        trail.emitting = true;
    }
    public void TrailOff()
    {
        trail.emitting = false;
    }
    public bool GetTrailEmittiong()
    {
        return trail.emitting;
    }
}
