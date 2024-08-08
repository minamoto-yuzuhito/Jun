using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 芝刈り機がオブジェクトを破壊する処理
/// </summary>
public class DestructionByLawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Destroyする時間を指定する")]
    private float time = 5;

    /// <summary>
    /// オブジェクトがすり抜けたとき
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // キャラクター
        if (other.gameObject.CompareTag("BodyParts"))
        {
            // その部位全てのオブジェクトを削除
            // 指定時間経過で削除
            Destroy(other.gameObject.transform.parent.gameObject, time);
        }
        // 芝刈り機の吸い込み口オブジェクト
        else
        {
            // 指定時間経過で削除
            Destroy(other.gameObject, time);
        }
    }
}
