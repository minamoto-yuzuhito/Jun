using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    [Tooltip("操作するオブジェクト")]
    private GameObject controlObject;

    [SerializeField]
    [Tooltip("サイズ")]
    private GameObject size;

    [SerializeField]
    [Tooltip("true：天井")]
    private bool isCeiling = false;

    [SerializeField]
    [Tooltip("サイズ変更にかかる時間")]
    private float scaleTime = 1.0f;

    private void Start()
    {
        if(isCeiling)
        {
            size = GameObject.FindWithTag("RoomSize");

            Invoke("BootDangerZone", 5.0f);
        }
    }

    private void BootDangerZone()
    {
        controlObject.transform.DOScaleY(size.transform.localScale.y, scaleTime).
            SetEase(Ease.Linear);   // イージング設定
    }

    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (!isCeiling)
        {
            // サイズ変更
            BootDangerZone();
        }
    }
}