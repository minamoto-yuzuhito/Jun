using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("敵を倒した際の得点")]
    private int scoreNum = 10;

    // true：既に実行中
    private bool isMyDestroy;

    public void MyDestroy()
    {
        // 既に実行中の場合は終了
        if (isMyDestroy) return;

        // 実行した判定
        isMyDestroy = true;

        // 指定時間後に敵を削除
        Invoke("Destroy", 3.0f);
    }

    private void Destroy()
    {
        // ゲームマネージャーを取得
        RagdollDivingGameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // スコアを加算
        gameManager.AddScore(scoreNum);

        // 敵の数のカウントを-1
        gameManager.SetNowEnemyNum(-1);

        // 敵を削除
        Destroy(transform.gameObject);
    }
}
