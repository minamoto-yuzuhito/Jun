using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 芝刈り機の動き
/// </summary>
public class LawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("芝刈り機がオブジェクトを吸い込む速度")]
    private float speed;

    [SerializeField]
    [Tooltip("芝刈り機の吸い込み口オブジェクト")]
    private GameObject lawnMowerStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 芝刈り機の「底」に向かう方向ベクトル
        //Vector3 direction = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.down;
        //carvedList[i].transform.parent.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
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

            // 吸い込み口を生成
            GameObject startPoint = Instantiate(
                lawnMowerStartPoint, other.transform.position, Quaternion.identity, transform.parent);

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
