using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI�g���Ƃ��͖Y�ꂸ�ɁB
using UnityEngine.UI;

public class HPBarDirection : MonoBehaviour
{
    public Canvas canvas;

    void Update()
    {
        Vector3 newCanvasPos = transform.position;
        newCanvasPos.z = transform.position.z + 1.5f;
        // EnemyCanvas��Main Camera�Ɍ�������
        canvas.transform.position = newCanvasPos;
    }
}