using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ToothController;

/// <summary>
/// 芝刈り機の動き
/// </summary>
public class LawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("芝刈り機の奥に連れていくオブジェクト")]
    private GameObject pullBehindTheLawnMower;

    [SerializeField]
    [Tooltip("SuctionArea")]
    private GameObject suctionArea;

    // カウントダウン
    [SerializeField]
    [Tooltip("吸い込みエリア生成のインターバル")]
    private float intervalOfCreateSuctionArea = 1.0f;
    private float coolTimeSeconds; // タイマー計測用
    private bool isCoolTime = false; // trueのときカウントダウンを行う

    // 生成した吸い込みエリアを格納
    private List<GameObject> suctionAreas = new List<GameObject>();

    /// <summary>
    /// 芝刈り機に向かってくる吸い込みエリアを生成
    /// </summary>
    public bool IsCreateSuctionArea()
    {
        // クリックしているかの判定
        bool isClick = false;

        // 左クリック中
        if (Input.GetMouseButton(0))
        {
            // クリックしている判定
            isClick = true;

            // クールタイム中ではないとき
            if (!isCoolTime)
            {
                // 吸い込みエリア生成
                Vector3 pos = transform.position;
                pos.y -= 5.0f;
                suctionAreas.Add(Instantiate(suctionArea, pos, Quaternion.identity));   // 格納

                // クールタイム突入
                isCoolTime = true;
            }
        }
        // 離したとき
        else
        {
            // クールタイム解除
            coolTimeSeconds = 0.0f;
            isCoolTime = false;

            // 生成した数分ループ
            for (int i = 0; i < suctionAreas.Count; i++)
            {
                Destroy(suctionAreas[i]);
            }
        }

        // クールタイム中
        if (isCoolTime)
        {
            // 時間をカウント
            coolTimeSeconds += Time.deltaTime;

            // 指定時間経過した時
            if (coolTimeSeconds >= intervalOfCreateSuctionArea)
            {
                // クールタイム解除
                coolTimeSeconds = 0.0f;
                isCoolTime = false;
            }
        }

        // クリックしているかの判定を返す
        return isClick;
    }

    /// <summary>
    /// オブジェクトがすり抜けたとき
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // キャラクターの時
        if (other.gameObject.CompareTag("BodyParts"))
        {
            Debug.Log("すり抜けた！");

            // 芝刈り機の奥に連れていくオブジェクトを生成
            GameObject startPoint = Instantiate(
                pullBehindTheLawnMower, other.transform.position, Quaternion.identity, transform.parent);

            // FixedJointコンポーネントがアタッチされていないとき
            if (other.transform.parent.GetComponent<FixedJoint>() == null)
            {
                // 触れてきたオブジェクトにジョイントをアタッチ
                other.transform.parent.AddComponent<FixedJoint>();
            }
            
            // ジョイントを接続
            other.transform.parent.GetComponent<FixedJoint>().connectedBody = startPoint.GetComponent<Rigidbody>();
        }
    }

    /// <summary>
    /// オブジェクトが通り抜けたとき
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        Debug.Log("通り抜け終えた");
    }

    /// <summary>
    /// オブジェクトがすり抜けているとき
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BodyParts"))
        {
            Debug.Log("すり抜けている！");
        }
    }
}
