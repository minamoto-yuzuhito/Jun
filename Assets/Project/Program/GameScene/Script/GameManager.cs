using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ToothController;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothControllerクラス")]
    private ToothController toothController;

    [SerializeField]
    [Tooltip("Throwingクラス")]
    private Throwing throwing;

    [SerializeField]
    [Tooltip("Countdownクラス")]
    private Countdown countdown;

    // CameraControllerクラス
    private CameraController cameraController;

    private ThrowingObjectSettings throwingObjectSettings;

    // 放射物の数をカウント
    private int QueueSetCnt;
    public int GetQueueSetCnt() { return QueueSetCnt; }    // ゲッター

    // 投げる最大数
    private int TotalQueue;

    // 投げた回数
    private int ThrowCnt;
    public int GetThrowCnt() { return ThrowCnt; }   // ゲッター

    // trueの時、歯を光らせる
    private bool isPresentProblem;

    // trueの時、キー入力を受け付ける
    private bool isKeyInput = true;

    // キー入力受付時間
    private float keyInputReceptionTime;

    // カウントダウン
    private float countdownSeconds; // タイマー
    private bool isCountdown = false; // trueのときカウントダウンを行う

    // Start is called before the first frame update
    void Start()
    {
        throwingObjectSettings = GetComponent<ThrowingObjectSettings>();
        cameraController = GetComponent<CameraController>();

        // 投げる視点のカメラに切り替える
        cameraController.SetThrowCamera();

        // 投げる最大数を設定
        TotalQueue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= throwingObjectSettings.GetThrowingObjects().Count; i++)
        {
            Debug.Log(i + "：" + throwingObjectSettings.GetThrowingObjects()[i - 1]);
        }

        // どの歯に向かって物を投げるかを決める
        if (!isPresentProblem)
        {
            // プレイヤーが押すべき歯を光らせる
            toothController.ShiningTooth();

            // 指定時間経過するか、キー入力が行われるまで光らせる歯を固定
            isPresentProblem = true;

            // カウントダウンを行う際の変数の値を設定
            SetCountdownStatus();
        }

        // カウントダウンを行って、
        // 指定された時間キー入力されたかを判定する
        if (isCountdown)
        {
            // 時間をカウント
            countdownSeconds += Time.deltaTime;

            // 投げる場所を選ばずに指定時間経過した時、
            // 選ばなかった判定をキューに追加する
            if (countdownSeconds >= keyInputReceptionTime)
            {
                // 選ばなかった判定をキューに追加
                throwingObjectSettings.GetThrowingObjects().Add(ToothPosition.Empty);

                NextTurn();
            }
            else
            {
                // カウントダウンUIを描画
                countdown.IsCountdown(keyInputReceptionTime);
            }
        }

        // キー入力を受け付けて、どの歯に投げるかを決める
        if (isKeyInput)
        {
            throwingObjectSettings.SetThrowingObject();
        }
    }

    /// <summary>
    /// カウントダウンを行う際の変数の値を設定
    /// </summary>
    private void SetCountdownStatus()
    {
        // カウントダウンを行う
        isCountdown = true;

        // キー入力受付時間を設定
        keyInputReceptionTime = 2.0f;

        // カウントダウンタイマーをリセット
        countdownSeconds = 0.0f;

        // メーターを表示
        countdown.IsViewMeter(true);
    }

    /// <summary>
    /// ターンを進める
    /// </summary>
    public void NextTurn()
    {
        // カウントダウンを停止
        isCountdown = false;

        // メーターを非表示
        countdown.IsViewMeter(false);

        // 放射物の数をカウント
        QueueSetCnt++;

        // 投げる物を全て決め終わった時
        if (QueueSetCnt >= TotalQueue)
        {
            // キー入力を受け付けない
            isKeyInput = false;

            // カウントダウンを行わない
            isCountdown = false;

            // 発射中の視点に切り替える
            cameraController.SetToothCamera();

            // 全ての歯を光らせなくする
            toothController.AllToothNotShining();

            // 物を投げられる判定にする
            toothController.SetIsThrowFlag(true);

            // 選んだ場所に物が投げられる（自動操作）
            StartCoroutine(ThrowBasedOnQueue());
        }
        else
        {
            // 再び歯を光らせる
            isPresentProblem = false;
        }
    }

    /// <summary>
    /// キューに保存されている物を投げる
    /// </summary>
    /// <returns></returns>
    private IEnumerator ThrowBasedOnQueue()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            // 全て投げ終わった時
            if (ThrowCnt >= TotalQueue)
            {
                // キー入力を受け付ける
                isKeyInput = true;

                // 投げる視点のカメラに切り替える
                cameraController.SetThrowCamera();

                // 再び歯を光らせる
                isPresentProblem = false;

                QueueSetCnt = 0;
                ThrowCnt = 0;

                // キューを削除
                throwingObjectSettings.GetThrowingObjects().Clear();    // プレイヤーが投げる場所
                toothController.GetShiningTooths().Clear();             // 提示された（光った歯）投げる場所

                break;
            }

            if(toothController.GetIsThrowFlag())
            {
                // 投げた回数をカウント
                ThrowCnt++;

                toothController.SetIsThrowFlag(false);

                // 投げる場所が保存されたキューから、
                // 順番に値を引き出す
                ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt - 1];

                // 投げる場所が選択されていたとき
                if (target >= 0)
                {
                    // キューに登録した場所に物を投げる
                    throwing.IsThrowingObject(target);
                }
                else
                {
                    Debug.Log("投げなかった");
                    toothController.SetIsThrowFlag(true);
                }
            }
        }
    }
}
