using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

/// <summary>
/// 芝刈り機がオブジェクトを破壊する処理
/// </summary>
public class DestructionByLawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Destroyする時間を指定する")]
    private float time = 5.0f;

    /// <summary>
    /// オブジェクトがすり抜けたとき
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // キャラクター
        if (other.gameObject.CompareTag("BodyParts"))
        {
            // 身体パーツの親オブジェクト
            Transform human = other.transform.parent.parent;
            // 身体パーツ（頭や腕などのこと）
            Transform parts = other.transform.parent;
            string partsName = BodyParts.None.ToString();

            GameObject obj = new GameObject(partsName);
            obj.transform.parent = human;

            // Hierarchyでの順番を取得
            int siblingIndex = parts.transform.GetSiblingIndex();

            // 順番を入れ替える
            obj.transform.SetSiblingIndex(siblingIndex);

            // その部位全てのオブジェクトを削除
            // 指定時間経過で削除
            Destroy(parts.gameObject);
        }
        // 芝刈り機の奥に連れていくオブジェクト
        else if (other.transform.CompareTag("PullBehindTheLawnMower"))
        {
            // 指定時間経過で削除
            Destroy(other.gameObject, time);
        }
    }
}
