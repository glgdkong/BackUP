using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailOnOff : MonoBehaviour
{
    // Ʈ���� ������ ������Ʈ ����
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
