using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾オブジェクト")]
    private GameObject bullet;

    // 発射中の時true
    private bool isShot;

    /// <summary>
    /// Cannonのセンサーがプレイヤーオブジェクトを検知したとき
    /// （Cannonオブジェクトはレイヤーの設定により、プレイヤーのみ検知できる）
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        // プレイヤーの方向に自身を回転させる
        transform.LookAt(other.transform);

        // 発射していないとき
        if (!isShot)
        {
            // 弾を生成
            Instantiate(bullet, transform.position, transform.localRotation);

            // 発射した判定
            isShot = true;

            // 指定時間後に再発射可能
            Invoke("Reload", 3);
        }
    }

    /// <summary>
    /// リロード
    /// </summary>
    void Reload()
    {
        isShot = false;
    }
}
