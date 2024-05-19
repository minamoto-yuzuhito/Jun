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
    public void SetQueueSetCnt(int Value) { QueueSetCnt += Value; }    // セッター

    // 投げる最大数
    private int TotalQueue;

    // 投げた回数
    private int ThrowCnt;
    public int GetThrowCnt() { return ThrowCnt; }   // ゲッター

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
        // どこの歯に向かって物を投げるかを決めている
        // 最大数投げていないとき
        if (QueueSetCnt != TotalQueue)
        {
            // プレイヤーが押すべきキーを提示する
            toothController.PresentProblem();

            // キー入力を受け付けて、どの歯に投げるかを決める
            throwingObjectSettings.SetThrowingObject();

            // 投げる物を全て決め終わった時
            if (QueueSetCnt >= TotalQueue)
            {
                // 歯を光らせなくする
                toothController.AllToothNotShining();

                // 選んだ場所に物が投げられる（自動操作）
                StartCoroutine(ThrowBasedOnQueue());
            }
        }

        Debug.Log(QueueSetCnt);
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
                QueueSetCnt = 0;
                ThrowCnt = 0;

                // キューを削除
                List<ToothPosition> throwingObjects = throwingObjectSettings.GetThrowingObjects();
                throwingObjects.Clear();

                break;
            }

            ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt];

            // キューに登録した場所に物を投げる
            throwing.IsThrowingObject(target);

            // 投げた回数をカウント
            ThrowCnt++;
        }

        //allThrowCnt = 3;
    }
}
