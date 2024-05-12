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

        // キー入力を受け付けない
        playerInput.enabled = false;
    }

    /// <summary>
    /// プレイヤーが押すべきキーを提示する
    /// </summary>
    public void PresentProblem()
    {
        // 放射物が発射されていないとき
        if(!isPresentProblem)
        {
            // キー入力が行われた場合、
            // ThrowingObjectSettingsクラスでIsToothShining関数が呼び出されるため、
            // InvokeでIsToothShining関数を呼び出す必要がなくなるためInvokeを停止する
            CancelInvoke("IsToothShining");

            // 歯を光らせる
            TargetSetting();

            // 指定時間、キー入力を受け付ける
            playerInput.enabled = true;

            // 指定時間経過するか、キー入力が行われるまで歯を光らせない
            isPresentProblem = true;
        }
        // 発射されているとき
        else
        {
            // 指定時間経過した時、再び歯を光らせる
            Invoke("IsToothShining", 2);
        }
    }

    /// <summary>
    /// 再び歯を光らせる
    /// </summary>
    public void IsToothShining() { isPresentProblem = false; }

    /// <summary>
    /// 歯を光らせる
    /// </summary>
    private void TargetSetting()
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

        // 光らせる歯を決める
        int rnd = Random.Range(0, (int)ToothPosition.ToothPlus + 1);    // 8本の歯の内から1本

        // 上下の歯のマテリアルを操作する
        for (int j = 0; j < 2; j++)
        {
            tooths[rnd].transform.GetChild(j).
                    gameObject.GetComponent<MeshRenderer>().material = materialArray[(int)ToothMaterial.Shining];
        }
    }

    /// <summary>
    /// 放射物が歯の射程範囲に入った時
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        
    }
}