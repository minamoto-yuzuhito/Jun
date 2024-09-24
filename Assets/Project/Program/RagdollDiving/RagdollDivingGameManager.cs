using DG.Tweening;
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

    [SerializeField]
    [Tooltip("ゲーム中のUI")]
    private CanvasGroup gameCanvas;

    [SerializeField]
    [Tooltip("BGM表示のUI")]
    private CanvasGroup soundCanvas;

    [SerializeField]
    [Tooltip("ゲームオーバー時のUI")]
    private CanvasGroup gameOverCanvas;

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

    private bool isGameOver;
    public void IsGameOver()
    {
        isGameOver = true;
        gameCanvas.DOFade(0.0f, 0.0f);      // 非表示
        gameOverCanvas.DOFade(1.0f, 0.0f);  // 表示
    }

    private void Start()
    {
        // 指定時間後に実行
        Invoke("SoundCanvasFade", 2.0f);
    }

    void SoundCanvasFade()
    {
        // 指定時間かけて非表示にする
        soundCanvas.DOFade(0.0f, 1.0f);
    }

    /// <summary>
    /// ここでは操作入力を行う
    /// </summary>
    private void Update()
    {
        if(isGameOver)
        {
            return;
        }

        // キー入力を受け付ける
        playerController.IsMoveInput();
    }

    /// <summary>
    /// ここで実際にプレイヤーを移動させる
    /// Rigidbodyを使用する移動はFixedUpdateで行う
    /// </summary>
    private void FixedUpdate()
    {
        if (isGameOver)
        {
            return;
        }

        // プレイヤーの操作
        playerController.IsMove();
    }
}
