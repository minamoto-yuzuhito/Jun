using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
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

                    // 現在の階層をカウント
                    ragdollDivingGameManager.SetScoreNumText();
                }
            }
        }
    }
}
