using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Enemy")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("生成位置")]
    private GameObject generatePos;

    [SerializeField]
    [Tooltip("親")]
    private GameObject parentObject;

    void OnTriggerEnter(Collider other)
    {
        // 人間オブジェクトが範囲内に入ったとき
        if (other.transform.CompareTag("BodyParts"))
        {
            // その箇所が胸だったとき
            if (other.transform.parent.CompareTag("Chest"))
            {
                // プレイヤーのとき
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    GameObject obj = Instantiate(enemyPrefab, generatePos.transform.position, Quaternion.identity);
                    obj.transform.parent = parentObject.transform;
                }
            }
        }
    }
}
