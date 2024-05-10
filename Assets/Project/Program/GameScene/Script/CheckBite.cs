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
        Debug.Log("当たった!");

        // 他の歯に当たった時
        if (other.CompareTag("Tooth"))
        {
            GameObject tooths = transform.parent.gameObject;

            // 上下の歯を初期座標に戻す
            tooths.GetComponent<BiteWithTeeth>().SetInit();
        }
    }
}
