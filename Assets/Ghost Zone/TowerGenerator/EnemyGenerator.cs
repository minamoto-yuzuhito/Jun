using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵キャラクター生成クラス
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("敵オブジェクトPrefab")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("敵の生成位置")]
    private GameObject enemyGeneratePos;

    /// <summary>
    /// 敵を生成
    /// </summary>
    public void GenerateEnemy()
    {
        // 敵が存在していないとき
        if (!GameObject.FindWithTag("Enemy"))
        {
            // 指定の位置に生成
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);
        }
    }
}
