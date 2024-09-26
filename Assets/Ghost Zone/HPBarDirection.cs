using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI使うときは忘れずに。
using UnityEngine.UI;

public class HPBarDirection : MonoBehaviour
{
    public Canvas canvas;

    void Update()
    {
        Vector3 newCanvasPos = transform.position;
        newCanvasPos.z = transform.position.z + 1.5f;
        // EnemyCanvasをMain Cameraに向かせる
        canvas.transform.position = newCanvasPos;
    }
}