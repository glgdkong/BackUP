using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trail ������ ������Ʈ Ȱ�� ��Ȱ�� ó��
public class TrailOnOff : MonoBehaviour
{
    // Trail Renderer ������Ʈ ����
    [SerializeField] private TrailRenderer trailRenderer;
    
    public void TrailOn()
    {
        // Ʈ���� ������ Ȱ��ȭ
        trailRenderer.emitting = true;
    }
    public void TrailOff()
    {
        // Ʈ���� ������ ��Ȱ��ȭ
        trailRenderer.emitting = false;
    }
}
