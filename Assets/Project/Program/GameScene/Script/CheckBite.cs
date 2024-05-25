using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 歯がほかのオブジェクトに当たった時
/// </summary>
public class CheckBite : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 他の歯に当たった時
        if (other.CompareTag("Tooth"))
        {
            // 歯を初期座標に戻す
            transform.parent.gameObject.GetComponent<BiteWithTeeth>().IsMouthOpen();
        }

        // 放射物に当たった時
        if (other.CompareTag("ThrowingObject"))
        {
            // 放射物を削除
            Destroy(other.gameObject);
        }
    }
}
