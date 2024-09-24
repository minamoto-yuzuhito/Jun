using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

public class TowerGenerator : MonoBehaviour
{
    //--- 塔 ---//
    [SerializeField]
    [Tooltip("TowerオブジェクトPrefab")]
    private GameObject towerPrefab;
    [SerializeField]
    [Tooltip("新しいTowerオブジェクトの生成位置（DangerZoneオブジェクトを指定）")]
    private Transform towerGeneratePos;

    //--- 障害物 ---//
    [SerializeField]
    [Tooltip("障害物オブジェクトPrefab")]
    private GameObject obstaclesPrefab;
    [SerializeField]
    [Tooltip("障害物の生成位置")]
    private GameObject obstaclesGeneratePos;
    [SerializeField]
    [Tooltip("障害物の親")]
    private GameObject obstaclesParentObject;

    //--- Enemy ---//
    [SerializeField]
    [Tooltip("敵オブジェクトPrefab")]
    private GameObject enemyPrefab;
    [SerializeField]
    [Tooltip("敵の生成位置")]
    private GameObject enemyGeneratePos;

    // RagdollDivingGameManager
    private RagdollDivingGameManager ragdollDivingGameManager;

    private bool isTowergenerate = false;

    private void Start()
    {
        // ゲームマネージャーを格納
        ragdollDivingGameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // 障害物を生成
        GenerateObstacles();
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
                    GenerateEnemy();
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
            // 現在の階層をカウント
            ragdollDivingGameManager.SetClearRoomText();

            // 新しい部屋を生成
            Instantiate(towerPrefab, towerGeneratePos.position, Quaternion.identity);
            isTowergenerate = true;
        }
    }

    /// <summary>
    /// 障害物を生成
    /// </summary>
    void GenerateObstacles()
    {
        // 指定の位置に生成
        GameObject obj = Instantiate(obstaclesPrefab, obstaclesGeneratePos.transform.position, Quaternion.identity);
        obj.transform.parent = obstaclesParentObject.transform;
    }

    /// <summary>
    /// 敵を生成
    /// </summary>
    void GenerateEnemy()
    {
        // 敵が存在していないとき
        if(!GameObject.FindWithTag("Enemy"))
        {
            // 指定の位置に生成
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);
        }
    }
}
