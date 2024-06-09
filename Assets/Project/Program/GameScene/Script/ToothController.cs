using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static ToothController;

public class ToothController : MonoBehaviour
{
    /// <summary>
    /// キーごとに対応する歯
    /// </summary>
    public enum ToothPosition
    {
        ToothA, ToothS, ToothD, ToothF,     // 左手で操作する歯
        ToothJ, ToothK, ToothL, ToothPlus,  // 右手で操作する歯
        AllTooth,   // スペースキーは全ての歯で噛む
        Empty = -1,      // 時間内にキーを押さなかった時
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
    private GameManager gameManager;

    [SerializeField]
    [Tooltip("ThrowingObjectSettings")]
    private ThrowingObjectSettings throwingObjectSettings;

    [SerializeField]
    [Tooltip("JunAnimation")]
    private JunAnimation junAnimation;

    // 歯オブジェクトを格納する配列
    private List<GameObject> tooths = new List<GameObject>();

    // 光った歯の種類が順番に格納される
    private List<int> shiningTooths = new List<int>();
    public List<int> GetShiningTooths() { return shiningTooths; }

    [SerializeField]
    [Tooltip("歯のマテリアル")]
    private Material[] materialArray = new Material[2];

    // trueのとき物を投げた後のアニメーションが終了
    // 再び物が投げられる状態にあります
    private bool isThrowFlag = false;
    public bool GetIsThrowFlag() {  return isThrowFlag; }   // ゲッター
    public void SetIsThrowFlag(bool Flag) { isThrowFlag = Flag; }   // セッター

    private void Start()
    {
        // 子を順番に配列に格納
        for (int i = 0; i <= (int)ToothPosition.ToothPlus; i++)
        {
            tooths.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// 歯を光らせる
    /// </summary>
    public void ShiningTooth()
    {
        // 一旦全ての歯の発光を止める
        AllToothNotShining();

        // 8本の歯の内から1本、光らせる歯を決める
        int rnd = Random.Range(0, (int)ToothPosition.ToothPlus + 1);
        shiningTooths.Add(rnd);

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
            // 放射物の回転、位置ともに固定
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            // 物が投げられた回数
            int throwCnt = gameManager.GetThrowCnt();

            // 物が投げられる歯の種類
            ToothPosition toothPosition = throwingObjectSettings.GetThrowingObjects()[throwCnt - 1];

            // 全ての歯で噛む
            if(toothPosition == ToothPosition.AllTooth)
            {
                for(int i = 0;i < (int)ToothPosition.AllTooth; i++)
                {
                    // 物が投げられる歯を取得
                    GameObject tooth = transform.GetChild(i).gameObject;

                    // 取得した歯で噛む動作を実行
                    tooth.GetComponent<BiteWithTeeth>().IsBite();
                }
            }
            // 指定の歯のみで噛む
            else
            {
                // 物が投げられる歯を取得
                GameObject tooth = transform.GetChild((int)toothPosition).gameObject;

                // 取得した歯で噛む動作を実行
                tooth.GetComponent<BiteWithTeeth>().IsBite();
            }
        }
    }

    /// <summary>
    /// 正しい場所に投げられたかを判定
    /// 結果に応じたアニメーションを実行
    /// </summary>
    public void CheckRightTheow()
    {
        // 物が投げられた回数
        int throwCnt = gameManager.GetThrowCnt();

        // 物が投げられる歯の種類
        ToothPosition toothPosition = throwingObjectSettings.GetThrowingObjects()[throwCnt - 1];

        // 光った歯に物が投げられられたとき
        if ((int)toothPosition == shiningTooths[throwCnt - 1])
        {
            // 成功アニメーションを実行
            junAnimation.Success();
        }
        else
        {
            // 失敗アニメーションを実行
            junAnimation.Miss();
        }
    }
}