using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    [Tooltip("操作するオブジェクト")]
    private GameObject controlObject;

    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("触れた");
        controlObject.transform.DOScaleY(transform.localScale.y, 1.0f).
        SetEase(Ease.InOutQuart);   // イージング設定
    }
}