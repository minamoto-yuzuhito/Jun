using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("新しいTowerオブジェクトの生成位置（DangerZoneオブジェクトを指定）")]
    private Transform newTowerPos;

    [SerializeField]
    [Tooltip("TowerオブジェクトのPrefab")]
    private GameObject towerPrefab;

    // RagdollDivingGameManager
    private RagdollDivingGameManager ragdollDivingGameManager;

    private bool isTowergenerate = false;

    private void Start()
    {
        // ゲームマネージャーを格納
        ragdollDivingGameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // 部屋を生成していないとき
        if (!isTowergenerate)
        {
            // 人間オブジェクトが範囲内に入ったとき
            if (other.transform.CompareTag("BodyParts"))
            {
                if (other.transform.parent.CompareTag("Chest"))
                {
                    // プレイヤーのとき
                    if (other.transform.parent.parent.CompareTag("Player"))
                    {
                        // 現在の階層をカウント
                        ragdollDivingGameManager.SetClearRoomText();

                        // 新しい部屋を生成
                        Instantiate(towerPrefab, newTowerPos.position, Quaternion.identity);
                        isTowergenerate = true;
                    }
                }
            }
        }
    }
}
