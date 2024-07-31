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

    // このスクリプトをアタッチしたゲームオブジェクトに関するもの
    private BodyParts bodyPartsType;    // 身体パーツの種類
    private GameObject parent;          // 親オブジェクト

    private void Start()
    {
        // 一番上の親オブジェクトを取得
        parent = transform.root.gameObject;

        // タグの文字列をenum型へ変換
        bodyPartsType = (BodyParts)Enum.Parse(typeof(BodyParts), transform.tag);

        //Debug.Log(bodyPartsType);
    }

    // <summary>
    // 指定されたオブジェクトから出血する
    // </summary>
    // <param name = "BodyParts" ></ param >
    private void SetBleedingLocation(BodyParts BodyParts, BleedingLocation BleedingLocation)
    {
        // このスクリプトがアタッチされたオブジェクトと接続していた箇所から出血
        if(BleedingLocation == BleedingLocation.Myself)
        {
            // 出血箇所のゲームオブジェクトを取得
            GameObject bleedingLocation = transform.GetChild(0).gameObject;
            IsBloodLoss(bleedingLocation);
        }
        // 接続先のオブジェクトから出血
        else
        {
            // 出血場所のゲームオブジェクトを取得
            GameObject bleedingLocation = parent.transform.GetChild((int)BodyParts).gameObject;
            GameObject bleedingLocationParent = bleedingLocation.transform.GetChild((int)BleedingLocation).gameObject;
            IsBloodLoss(bleedingLocationParent);
        }
    }

    /// <summary>
    /// Jointが外れたとき
    /// </summary>
    void OnJointBreak(float breakForce)
    {
        // このスクリプトがアタッチされたオブジェクトと接続していた箇所から出血
        SetBleedingLocation(BodyParts.None, BleedingLocation.Myself);

        // 接続先のオブジェクトから出血
        switch (bodyPartsType)
        {
            // 頭が外れたとき、胸上から出血
            case BodyParts.Head: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnHead); break;

            // 胸には元からこのスクリプトがアタッチされていないのでスルー
            case BodyParts.Chest: break;

            //--- 右肩～右手 ---//
            // 右肩が外れたとき、胸右から出血
            case BodyParts.RightShoulder: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnRightShoulder); break;
            // 右腕が外れたとき、右肩から出血
            case BodyParts.RightArm: SetBleedingLocation(BodyParts.RightShoulder, BleedingLocation.OppositeSide); break;
            // 右手が外れたとき、右腕から出血
            case BodyParts.RightHand: SetBleedingLocation(BodyParts.RightArm, BleedingLocation.OppositeSide); break;

            //--- 左肩～左手 ---//
            // 左肩が外れたとき、胸左から出血
            case BodyParts.LeftShoulder: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnLeftShoulder); break;
            // 左腕が外れたとき、左肩から出血
            case BodyParts.LeftArm: SetBleedingLocation(BodyParts.LeftShoulder, BleedingLocation.OppositeSide); break;
            // 左手が外れたとき、左腕から出血
            case BodyParts.LeftHand: SetBleedingLocation(BodyParts.LeftArm, BleedingLocation.OppositeSide); break;

            // 腰が外れたとき、胸下から出血
            case BodyParts.Waist: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnWaist); break;

            //--- 右太もも～右つま先 ---//
            // 右太ももが外れたとき、腰右から出血
            case BodyParts.RightThigh: SetBleedingLocation(BodyParts.Waist, BleedingLocation.OnRightThigh); break;
            // 右すねが外れたとき、右太ももから出血
            case BodyParts.RightShin: SetBleedingLocation(BodyParts.RightThigh, BleedingLocation.OppositeSide); break;
            // 右つま先が外れたとき、右すねから出血
            case BodyParts.RightFoot: SetBleedingLocation(BodyParts.RightShin, BleedingLocation.OppositeSide); break;

            //--- 左太もも～左つま先 ---//
            // 左太ももが外れたとき、腰左から出血
            case BodyParts.LeftThigh: SetBleedingLocation(BodyParts.Waist, BleedingLocation.OnLeftThigh); break;
            // 左すねが外れたとき、左太ももから出血
            case BodyParts.LeftShin: SetBleedingLocation(BodyParts.LeftThigh, BleedingLocation.OppositeSide); break;
            // 左つま先が外れたとき、左すねから出血
            case BodyParts.LeftFoot: SetBleedingLocation(BodyParts.LeftShin, BleedingLocation.OppositeSide); break;
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
