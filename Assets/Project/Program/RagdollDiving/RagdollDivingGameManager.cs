using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerControllerクラス")]
    private PlayerController playerController;
    public void InitPlayerController() { playerController = null; }

    [SerializeField]
    [Tooltip("ゲームプレイ中に表示するスコア")]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    [Tooltip("ゲームオーバー画面に表示するスコア")]
    private TextMeshProUGUI gameOverScoreText;

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
    /// スコアを加算して、テキストを更新
    /// </summary>
    public void SetScoreText(int Value)
    {
        ScoreNum += Value;
        scoreText.text = "Score:" + ScoreNum;
    }

    // 突破した数
    private int ScoreNum = 0;
    public int GetClearRoomNum() { return ScoreNum; }   // ゲッター
    public void CountClearRoomNum() { ScoreNum++; }   // 1カウントする

    // ゲームオーバー時に、
    // なんらかのキーかマウスボタンが押されているときtrue
    bool isGameOverInputAnyKey;

    // ゲームオーバー判定
    private bool isGameOver;
    /// <summary>
    /// ゲームオーバー時に実行される
    /// </summary>
    public void IsGameOver()
    {
        isGameOver = true;
        gameCanvas.DOFade(0.0f, 0.0f);      // 非表示

        // スコアを代入
        gameOverScoreText.text = scoreText.text;
        gameOverCanvas.DOFade(1.0f, 0.0f);  // 表示

        isGameOverInputAnyKey = true;
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
            // 一度キーを離さないといけない
            if (!Input.anyKey)
            {
                isGameOverInputAnyKey = false;
            }

            if (!isGameOverInputAnyKey)
            {
                if (Input.anyKey)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            return;
        }

        if (playerController != null)
        {
            // キー入力を受け付ける
            playerController.IsMoveInput();
        }
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

        if (playerController != null)
        {
            // プレイヤーの操作
            playerController.IsMove();
        }
    }
}
