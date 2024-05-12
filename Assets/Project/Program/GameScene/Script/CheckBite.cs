using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 歯がほかのオブジェクトに当たった時
/// </summary>
public class CheckBite : MonoBehaviour
{
    // 初期座標（高さ）
    private float toothInitialPosY;

    void Start()
    {
        // 歯の初期座標を代入
        toothInitialPosY = transform.position.y;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("当たった!");

        // 他の歯に当たった時
        if (other.CompareTag("Tooth"))
        {
            transform.DOKill();

            // 歯を初期座標に戻す
            transform.DOMoveY(toothInitialPosY, 1).
            SetEase(Ease.InOutQuart);   // イージング設定
        }
    }
}
