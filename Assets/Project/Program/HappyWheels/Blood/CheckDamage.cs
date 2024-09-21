using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static CheckDamage;
using Debug = UnityEngine.Debug;

/// <summary>
/// このスクリプトは各身体パーツにアタッチする
/// </summary>
public class CheckDamage : MonoBehaviour
{
    public enum BodyParts
    {
        Head,           // 頭
        Chest,          // 胸
        RightShoulder,  // 右肩
        RightArm,       // 右腕
        RightHand,      // 右手
        LeftShoulder,   // 左肩
        LeftArm,        // 左腕
        LeftHand,       // 左手
        Waist,          // 腰
        RightThigh,     // 右太もも
        RightShin,      // 右すね
        RightFoot,      // 右つま先
        LeftThigh,      // 左太もも
        LeftShin,       // 左すね
        LeftFoot,       // 左つま先
        None,           // 初期値
    }

    /// <summary>
    /// 出血箇所
    /// </summary>
    public enum BleedingLocation
    {
        // 胸
        OnHead,             // 頭と繋がっている
        OnRightShoulder,    // 右肩と繋がっている
        OnLeftShoulder,     // 左肩と繋がっている
        OnWaist,            // 腰と繋がっている

        // 腰
        OnRightThigh = 1,   // 右太ももと繋がっている
        OnLeftThigh,        // 左太ももと繋がっている

        // それ以外
        Myself = -1,        // このスクリプトがアタッチされたオブジェクトと接続していた箇所
        OppositeSide = 1,   // 反対側
    }

    [SerializeField]
    [Tooltip("連動して出血する部位")]
    private GameObject linkageBleeding;

    private void Start()
    {
        //Debug.Log(bodyPartsType);
    }

    /// <summary>
    /// Jointが外れたとき
    /// </summary>
    void OnJointBreak(float breakForce)
    {
        // ダメージ音を流す
        //parent.GetComponent<AudioSource>().Play();

        // このオブジェクトから出血
        // 出血箇所のゲームオブジェクトを取得
        GameObject bleedingMySelf = transform.GetChild(0).gameObject;
        IsBloodLoss(bleedingMySelf);

        // このオブジェクトの接続先のオブジェクトから出血
        // 接続している身体パーツが存在していないときは出血しない
        if (linkageBleeding.name != BodyParts.None.ToString())
        {
            IsBloodLoss(linkageBleeding);
        }
    }

    /// <summary>
    /// 出血処理を行う
    /// </summary>
    /// <param name="BleedingLocation"> 出血箇所オブジェクト </param>
    private void IsBloodLoss(GameObject BleedingLocation)
    {
        // BloodLostスクリプトを取得
        BloodLost bloodLost = BleedingLocation.GetComponent<BloodLost>();

        // 出血処理がされていないとき
        if (bloodLost != null)
        {
            // スクリプトを有効にして出血処理を開始する
            bloodLost.enabled = true;

            // 指定時間経過で出血を止める
            bloodLost.BloodLossStopAafter();
        }
    }
}
