using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// このスクリプトは各身体パーツにアタッチする
/// </summary>
public class CheckDamage : MonoBehaviour
{
    public enum BodyParts
    {
        Head,           // 頭
        Neck,           // 首
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
        RightFoot,      // 右つまさき
        LeftThigh,      // 左太もも
        LeftShin,       // 左すね
        LeftFoot,       // 左つまさき
    }

    // このスクリプトをアタッチしたゲームオブジェクトに関するもの
    private BodyParts bodyPartsType;    // 身体パーツの種類
    private GameObject parent;          // 親オブジェクト

    private void Start()
    {
        // 親オブジェクトを取得
        parent = transform.parent.gameObject;

        // タグの文字列をenum型へ変換
        bodyPartsType = (BodyParts)Enum.Parse(typeof(BodyParts), transform.tag);

        Debug.Log(bodyPartsType);
    }

    // Update is called once per frame
    void Update()
    {
        // ジョイントコンポーネントがアタッチされているかを判定
        // （パーツ同士がつながっているかを調べる）
        // つながっていないとき
        if (!GetComponent<CharacterJoint>())
        {
            BodyParts bleedingLocation = BodyParts.Chest;

            switch (bodyPartsType)
            {
                // 頭～首
                case BodyParts.Head: bleedingLocation = BodyParts.Neck; break;  // 【頭】首から出血
                case BodyParts.Neck: break; // 【首】胴上から出血

                // 胸には元からこのスクリプトがアタッチされていないのでスルー
                case BodyParts.Chest: break;

                // 右肩～右手
                case BodyParts.RightShoulder: break;    // 【右肩】胸右から出血
                case BodyParts.RightArm: bleedingLocation = BodyParts.RightShoulder; break; // 【右腕】右肩から出血
                case BodyParts.RightHand: bleedingLocation = BodyParts.RightArm; break;     // 【右手】右腕から出血

                // 左肩～左手
                case BodyParts.LeftShoulder: break; // 【左肩】胸左から出血
                case BodyParts.LeftArm: bleedingLocation = BodyParts.LeftShoulder; break;   // 【左腕】左肩から出血
                case BodyParts.LeftHand: bleedingLocation = BodyParts.LeftArm; break;       // 【左手】左腕から出血

                // 腰
                case BodyParts.Waist: break;    // 【腰】胴下から出血

                // 右太もも～右つま先
                case BodyParts.RightThigh: break;   // 【右太もも】腰右下から出血
                case BodyParts.RightShin: bleedingLocation = BodyParts.RightThigh; break;   // 【右すね】右太ももから出血
                case BodyParts.RightFoot: bleedingLocation = BodyParts.RightShin; break;    // 【右つま先】右すねから出血

                // 左太もも～左つま先
                case BodyParts.LeftThigh: break;    // 【左太もも】腰左下から出血
                case BodyParts.LeftShin: bleedingLocation = BodyParts.LeftThigh; break;     // 【左すね】左太ももから出血
                case BodyParts.LeftFoot: bleedingLocation = BodyParts.LeftShin; break;      // 【左つま先】左すねから出血
            }

            if(bleedingLocation != BodyParts.Chest)
            {
                SetBleedingLocation(bleedingLocation);
            }
        }
    }

    /// <summary>
    /// 出血場所を設定
    /// </summary>
    /// <param name="BodyParts"></param>
    private void SetBleedingLocation(BodyParts BodyParts)
    {
        // 出血場所のゲームオブジェクトを取得
        GameObject bleedingLocation = parent.transform.GetChild((int)BodyParts).gameObject;

        bleedingLocation.transform.GetChild(0).GetComponent<BloodLost>().enabled = true;
    }
}
