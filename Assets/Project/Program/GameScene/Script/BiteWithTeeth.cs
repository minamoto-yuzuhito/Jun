using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

/// <summary>
/// 上下の歯を動かして、噛む動作を実行する
/// </summary>
public class BiteWithTeeth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("上の歯")]
    private GameObject upperTooth;

    [SerializeField]
    [Tooltip("下の歯")]
    private GameObject lowerTooth;

    [SerializeField]
    [Tooltip("口を閉じる速度")]
    private float mouthCloseSpeed = 0.5f;

    [SerializeField]
    [Tooltip("口を開く速度")]
    private float mouthOpenSpeed = 1.0f;

    // 初期座標（高さ）
    private float upperToothInitialPosY;
    private float lowerToothInitialPosY;

    private ToothController toothController;

    // Start is called before the first frame update
    void Start()
    {
        toothController = transform.parent.gameObject.GetComponent<ToothController>();

        // 上下の歯の初期座標を代入
        upperToothInitialPosY = upperTooth.transform.position.y;    // 上の歯
        lowerToothInitialPosY = lowerTooth.transform.position.y;    // 下の歯
    }

    /// <summary>
    /// 上下の歯が初期位置にあるときtrueを返す
    /// </summary>
    /// <returns></returns>
    public bool CheckMouthOpen()
    {
        if (upperToothInitialPosY == upperTooth.transform.position.y &&
            lowerToothInitialPosY == lowerTooth.transform.position.y)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 噛む動作を実行
    /// </summary>
    public void IsBite()
    {
        // 上の歯を下に移動
        upperTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定

        // 下の歯を上に移動
        lowerTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定
    }

    /// <summary>
    /// 口を開いた状態にする
    /// </summary>
    public void IsMouthOpen()
    {
        // IsBiteで実行されているものを停止
        upperTooth.transform.DOKill();
        lowerTooth.transform.DOKill();

        // 上の歯を初期位置に移動
        upperTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定

        // 下の歯を初期位置に移動
        lowerTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定

        // 
        StartCoroutine(ThrowBasedOnQueue());
    }

    private IEnumerator ThrowBasedOnQueue()
    {
        while (true)
        {
            // 歯が初期位置に戻った時
            if (CheckMouthOpen())
            {
                // 正しい場所に投げられたかを判定
                // 結果に応じたアニメーションを実行
                toothController.CheckRightTheow();
                break;
            }

            yield return null;
        }
    }
}