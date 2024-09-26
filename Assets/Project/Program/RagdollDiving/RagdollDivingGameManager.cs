using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerHPBarクラス")]
    private PlayerHPBar playerHPBar;

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

    [SerializeField]
    [Tooltip("プレイヤーの体力のUI")]
    private CanvasGroup playerHPBarCanvas;

    [SerializeField]
    [Tooltip("制限時間終了時に生成する床")]
    private GameObject invisibleFloor;

    /// <summary>
    /// 回復時の処理
    /// </summary>
    public void AddScore(int Value)
    {
        // スコア加算
        ScoreNum += Value;

        // テキスト更新
        scoreText.text = "Score:" + ScoreNum;
    }

    /// <summary>
    /// 回復時の処理
    /// </summary>
    public void PlayerHPBarHealing()
    {
        // 体力回復
        playerHPBar.IsHealing(10.0f);
    }

    // 突破した数
    private int ScoreNum = 0;
    public int GetClearRoomNum() { return ScoreNum; }   // ゲッター
    public void CountClearRoomNum() { ScoreNum++; }   // 1カウントする

    // ゲームオーバー時に、
    // なんらかのキーかマウスボタンが押されているときtrue
    bool isGameOverInputAnyKey = true;

    // ゲームオーバー判定
    private bool isGameOver;
    /// <summary>
    /// ゲームオーバー時に実行される
    /// </summary>
    public void IsGameOver()
    {
        // ゲームオーバー判定
        isGameOver = true;

        // ゲームUI
        gameCanvas.DOFade(0.0f, 0.0f);  // 非表示

        // プレイヤーの体力のUI
        playerHPBarCanvas.DOFade(0.0f, 0.0f);   // 非表示

        // スコアUI
        gameOverCanvas.DOFade(1.0f, 0.0f);          // 表示
        gameOverScoreText.text = scoreText.text;    // スコアを代入
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
        // 時間経過でプレイヤーのHPバーを減らす
        // HPバーが0になったときtrueを返す
        if (playerHPBar.DamageInPlayer())
        {
            // 操作するプレイヤーオブジェクトが指定されているとき
            if (playerController != null)
            {
                // 高速で落下しているとき
                if (playerController.GetVelocityY() < -50.0f)
                {
                    // 生成座標
                    Vector3 newPos = playerController.transform.position;
                    newPos.y -= 5.0f;

                    // プレイヤーのすぐ下に床を生成する
                    Instantiate(invisibleFloor, newPos, Quaternion.identity);

                    // ゲームオーバー処理
                    IsGameOver();
                }
            }
            else
            {
                // ゲームオーバー処理
                IsGameOver();
            }
        }

        // ゲームオーバー時
        if (isGameOver)
        {
            // キーに触れていないとき
            if (!Input.anyKey)
            {
                isGameOverInputAnyKey = false;
            }

            // ゲームオーバー時に何かしらのキーに触れていた場合、
            // 一度離さないとキー入力を受け付けられない
            if (!isGameOverInputAnyKey)
            {
                // 何かしらのキーに触れたとき
                if (Input.anyKey)
                {
                    // リトライ
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            return;
        }

        // 操作するプレイヤーオブジェクトが指定されているとき
        if (playerController != null)
        {
            // プレイヤー操作のキー入力を受け付ける
            playerController.IsMoveInput();
        }
    }

    /// <summary>
    /// ここで実際にプレイヤーを移動させる
    /// Rigidbodyを使用する移動はFixedUpdateで行う
    /// </summary>
    private void FixedUpdate()
    {
        // ゲームオーバー時
        if (isGameOver)
        {
            return;
        }

        // 操作するプレイヤーオブジェクトが指定されているとき
        if (playerController != null)
        {
            // プレイヤーの操作
            playerController.IsMove();
        }
    }
}
