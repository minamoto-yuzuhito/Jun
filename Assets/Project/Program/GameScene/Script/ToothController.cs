using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ToothController : MonoBehaviour
{
    /// <summary>
    /// キーごとに対応する歯
    /// </summary>
    public enum ToothPosition
    {
        ToothA, ToothS, ToothD, ToothF,     // 左手で操作する歯
        ToothJ, ToothK, ToothL, ToothPlus,  // 右手で操作する歯
        AllTooth, // スペースキーは全ての歯で噛む
    }

    /// <summary>
    /// 歯のマテリアル
    /// </summary>
    public enum ToothMaterial
    {
        Normal,
        Shining
    }

    [SerializeField]
    [Tooltip("GameManager")]
    public GameManager gameManager;

    [SerializeField]
    [Tooltip("ThrowingObjectSettings")]
    public ThrowingObjectSettings throwingObjectSettings;

    [SerializeField]
    [Tooltip("PlayerInput")]
    public PlayerInput playerInput;

    // 歯オブジェクトを格納する配列
    private List<GameObject> tooths = new List<GameObject>();

    [SerializeField]
    [Tooltip("歯のマテリアル")]
    public Material[] materialArray = new Material[2];

    // trueの時、歯を光らせる
    private bool isPresentProblem;

    private void Start()
    {
        // 子を順番に配列に格納
        for (int i = 0; i <= (int)ToothPosition.ToothPlus; i++)
        {
            tooths.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// プレイヤーが押すべきキーを提示する
    /// </summary>
    public void PresentProblem()
    {
        // どの歯に投げるかを選択する
        if(!isPresentProblem)
        {
            // キー入力を受け付ける
            playerInput.enabled = true;

            // キー入力が行われた場合、
            // ThrowingObjectSettingsクラスでIsToothShining関数が呼び出されるため、
            // InvokeでIsToothShining関数を呼び出す必要がなくなるためInvokeを停止する
            //CancelInvoke("IsToothShining");

            // 歯を光らせる
            ToothShining();

            // 指定時間経過するか、キー入力が行われるまで歯を光らせない
            isPresentProblem = true;
        }
        // 発射されているとき
        else
        {
            // 指定時間経過した時、再び歯を光らせる
            //Invoke("IsToothShining", 2);
        }
    }

    /// <summary>
    /// 再び歯を光らせる
    /// </summary>
    public void IsToothShining()
    {
        isPresentProblem = false;

        // 放射物の数をカウント
        gameManager.SetQueueSetCnt(1);
    }

    /// <summary>
    /// 歯を光らせる
    /// </summary>
    private void ToothShining()
    {
        // 一旦全ての歯の発光を止める
        AllToothNotShining();

        // 8本の歯の内から1本、光らせる歯を決める
        int rnd = Random.Range(0, (int)ToothPosition.ToothPlus + 1);

        // 上下の歯のマテリアルを操作して発光させる
        for (int j = 0; j < 2; j++)
        {
            tooths[rnd].transform.GetChild(j).
                    gameObject.GetComponent<MeshRenderer>().material = materialArray[(int)ToothMaterial.Shining];
        }
    }

    /// <summary>
    /// 全ての歯の発光を止める
    /// </summary>
    public void AllToothNotShining()
    {
        // 全ての歯に通常マテリアルを適用
        for (int i = 0; i <= (int)ToothPosition.ToothPlus; i++)
        {
            // 上下の歯のマテリアルを操作する
            for (int j = 0; j < 2; j++)
            {
                tooths[i].transform.GetChild(j).
                    gameObject.GetComponent<MeshRenderer>().material = materialArray[(int)ToothMaterial.Normal];
            }
        }
    }

    /// <summary>
    /// 放射物が歯の射程範囲に入った時
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // 放射物に当たった時
        if (other.CompareTag("ThrowingObject"))
        {
            // 回転、位置ともに固定
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            // 物が投げられた回数
            int throwCnt = gameManager.GetThrowCnt();

            // 物が投げられる歯の種類
            ToothPosition toothPosition = throwingObjectSettings.GetThrowingObjects()[throwCnt - 1];

            // 物が投げられる歯を取得
            GameObject tooth = transform.GetChild((int)toothPosition).gameObject;

            // 取得した歯で噛む動作を実行
            tooth.GetComponent<BiteWithTeeth>().IsBite();
        }
    }
}