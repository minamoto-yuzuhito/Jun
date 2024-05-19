using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothControllerクラス")]
    public ToothController toothController;

    [SerializeField]
    [Tooltip("Throwingクラス")]
    public Throwing throwing;

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

    // Start is called before the first frame update
    void Start()
    {
        throwingObjectSettings = GetComponent<ThrowingObjectSettings>();

        // 投げる最大数を設定
        TotalQueue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(QueueSetCnt);

        // どの歯に向かって物を投げるかを決める
        if (!isPresentProblem)
        {
            // プレイヤーが押すべきキーを提示する
            toothController.ToothShining();

            // 指定時間経過するか、キー入力が行われるまで歯を光らせない
            isPresentProblem = true;

            // 投げる場所を選ばずに指定時間経過した時、
            // 選ばなかった判定をキューに追加する
            Invoke("AfterNotSelect", 2);
        }

        // キー入力を受け付けて、どの歯に投げるかを決める
        if (isKeyInput)
        {
            throwingObjectSettings.SetThrowingObject();
        }
    }

    /// <summary>
    /// 投げる場所を選んだ後の処理
    /// </summary>
    public void AfterSelect()
    {
        // キーが押されたのでInvokeを停止
        CancelInvoke("AfterNotSelect");

        NextTurn();
    }

    /// <summary>
    /// 投げる場所を選ばなかった後の処理
    /// </summary>
    private void AfterNotSelect()
    {
        // 選ばなかった判定をキューに追加
        throwingObjectSettings.GetThrowingObjects().Add(ToothPosition.Empty);

        NextTurn();
    }

    /// <summary>
    /// 投げる場所を選んだ後の処理
    /// </summary>
    private void NextTurn()
    {
        // 放射物の数をカウント
        QueueSetCnt++;

        // 投げる物を全て決め終わった時
        if (QueueSetCnt >= TotalQueue)
        {
            // キー入力を受け付けない
            isKeyInput = false;

            // 歯を光らせなくする
            toothController.AllToothNotShining();

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
    /// キューに基づいて物を投げる
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
                // 再び歯を光らせる
                isPresentProblem = false;

                // キー入力を受け付ける
                isKeyInput = true;

                QueueSetCnt = 0;
                ThrowCnt = 0;

                // キューを削除
                List<ToothPosition> throwingObjects = throwingObjectSettings.GetThrowingObjects();
                throwingObjects.Clear();

                break;
            }

            // 投げた回数をカウント
            ThrowCnt++;

            // 投げる場所が保存されたキューから、
            // 順番に値を引き出す
            ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt - 1];

            // 投げる場所が選択されていたとき
            if(target > 0)
            {
                // キューに登録した場所に物を投げる
                throwing.IsThrowingObject(target);
            }
            else
            {
                Debug.Log("投げなかった");
            }
        }
    }
}
