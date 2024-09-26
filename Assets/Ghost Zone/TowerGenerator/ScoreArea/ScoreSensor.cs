using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ScoreAreaに触れた際の得点")]
    private int scoreNum = 5;

    [SerializeField]
    [Tooltip("オブジェクトが削除されるまでの時間")]
    private float lifeTime = 10.0f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
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
                    // ゲームマネージャーを取得
                    RagdollDivingGameManager ragdollDivingGameManager =
                        GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

                    // プレイヤーの体力を回復
                    ragdollDivingGameManager.PlayerHPBarHealing();
                }
            }
        }
    }
}
