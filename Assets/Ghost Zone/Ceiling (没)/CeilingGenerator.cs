using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CeilingGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成位置")]
    private Transform generatoePos;

    [SerializeField]
    [Tooltip("天井オブジェクトのPrefab")]
    private GameObject ceilingPrefab;

    [SerializeField]
    [Tooltip("天井の親に指定するオブジェクト")]
    private GameObject ceilingParent;

    private bool isTowergenerate = false;

    void OnTriggerEnter(Collider other)
    {
        // 天井を生成していないとき
        if (!isTowergenerate)
        {
            if (other.transform.parent.CompareTag("Chest"))
            {
                // 天井を生成
                Instantiate(ceilingPrefab, generatoePos.position, Quaternion.identity, ceilingParent.transform);
                isTowergenerate = true;
            }
        }
    }
}
