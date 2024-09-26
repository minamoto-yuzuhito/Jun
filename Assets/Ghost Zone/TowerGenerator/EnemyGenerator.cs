using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        // ゲームマネージャーを取得
        RagdollDivingGameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // 敵の数が上限より少ないとき
        if (gameManager.GetNowEnemyNum() < gameManager.GetEnemyGenerateLimit())
        {
            // 指定の位置に生成
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);

            // 敵の数のカウントを+1
            gameManager.SetNowEnemyNum(1);
        }
    }
}
