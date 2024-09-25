using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

/// <summary>
/// 塔生成クラス
/// </summary>
public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("TowerオブジェクトPrefab")]
    private GameObject towerPrefab;

    [SerializeField]
    [Tooltip("新しいTowerオブジェクトの生成位置（DangerZoneオブジェクトを指定）")]
    private Transform towerGeneratePos;

    private bool isTowergenerate = false;

    private void Start()
    {
        // 障害物を生成
        GetComponent<ObstaclesGenerator>().GenerateObstacles();

        // スコアを生成
        GetComponent<ScoreGenerator>().GenerateScore();
    }

    void OnTriggerEnter(Collider other)
    {
        // 人間オブジェクトが範囲内に入ったとき
        if (other.transform.CompareTag("BodyParts"))
        {
            if (other.transform.parent.CompareTag("Chest"))
            {
                // プレイヤーのとき
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    // 塔を生成
                    GenerateTower();

                    // 敵を生成
                    GetComponent<EnemyGenerator>().GenerateEnemy();
                }
            }
        }
    }

    /// <summary>
    /// 塔を生成
    /// </summary>
    void GenerateTower()
    {
        // 部屋を生成していないとき
        if (!isTowergenerate)
        {
            // ゲームマネージャーを取得
            RagdollDivingGameManager ragdollDivingGameManager =
                        GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

            // 現在の階層をカウント
            ragdollDivingGameManager.SetScoreNumText();

            // 新しい部屋を生成
            Instantiate(towerPrefab, towerGeneratePos.position, Quaternion.identity);
            isTowergenerate = true;
        }
    }
}
