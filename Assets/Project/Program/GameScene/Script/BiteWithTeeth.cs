using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 上下の歯を動かして、噛む動作を実行する
/// </summary>
public class BiteWithTeeth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("上の歯")]
    public GameObject upperTooth;

    [SerializeField]
    [Tooltip("下の歯")]
    public GameObject lowerTooth;

    [SerializeField]
    [Tooltip("口を閉じる速度")]
    public float mouthCloseSpeed = 0.5f;

    [SerializeField]
    [Tooltip("口を開く速度")]
    public float mouthOpenSpeed = 1.0f;

    // 初期座標（高さ）
    private float upperToothInitialPosY;
    private float lowerToothInitialPosY;

    // Start is called before the first frame update
    void Start()
    {
        // 上下の歯の初期座標を代入
        upperToothInitialPosY = upperTooth.transform.position.y;    // 上の歯
        lowerToothInitialPosY = lowerTooth.transform.position.y;    // 下の歯
    }

    /// <summary>
    /// 噛む動作を実行
    /// </summary>
    public void IsBite()
    {
        // 歯が動いているときは噛まない
        if(upperToothInitialPosY != upperTooth.transform.position.y ||
            lowerToothInitialPosY != lowerTooth.transform.position.y)
        {
            return;
        }

        // 上の歯を下に移動
        upperTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定

        // 下の歯を上に移動
        lowerTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // イージング設定
    }
}