using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("投げる視点のカメラ")]
    private Camera ThrowCamera;

    [SerializeField]
    [Tooltip("歯の正面視点のカメラ")]
    private Camera ToothCamera;

    [SerializeField]
    [Tooltip("サブカメラのキャンバスグループ")]
    private CanvasGroup SubCamera;

    /// <summary>
    /// 投げる視点のカメラに切り替える
    /// </summary>
    public void SetThrowCamera()
    {
        ThrowCamera.enabled = true;
        ToothCamera.enabled = false;
        SubCamera.alpha = 0.0f;
    }

    /// <summary>
    /// 発射中の視点に切り替える
    /// </summary>
    public void SetToothCamera()
    {
        ThrowCamera.enabled = false;
        ToothCamera.enabled = true;
        SubCamera.alpha = 1.0f;
    }
}
