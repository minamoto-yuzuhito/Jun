using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerControllerクラス")]
    private PlayerController playerController;

    [SerializeField]
    [Tooltip("現在の階層を表示するText型の変数")]
    private TextMeshProUGUI clearRoomText;

    /// <summary>
    /// クリアした数をカウントして、テキストを更新
    /// </summary>
    public void SetClearRoomText()
    {
        clearRoomNum++;
        clearRoomText.text = "Clear:" + clearRoomNum;
    }

    // 突破した数
    private int clearRoomNum = 0;
    public int GetClearRoomNum() { return clearRoomNum; }   // ゲッター
    public void CountClearRoomNum() { clearRoomNum++; }   // 1カウントする

    /// <summary>
    /// ここでは操作入力を行う
    /// </summary>
    private void Update()
    {
        // キー入力を受け付ける
        playerController.IsMoveInput();
    }

    /// <summary>
    /// ここで実際にプレイヤーを移動させる
    /// Rigidbodyを使用する移動はFixedUpdateで行う
    /// </summary>
    private void FixedUpdate()
    {
        // プレイヤーの操作
        playerController.IsMove();
    }
}
