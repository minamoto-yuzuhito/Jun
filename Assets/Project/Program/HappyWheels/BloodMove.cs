using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("血を飛ばす際のぶれの最大値")]
    private Vector3 bloodMoveShaking = new Vector3(2.0f, 2.0f, 2.0f);

    [SerializeField]
    [Tooltip("速度")]
    private float speed;

    [SerializeField]
    [Tooltip("Destroyする時間を指定する")]
    private float time = 2;

    // Update is called once per frame
    void Start()
    {
        // 身体のパーツが向いている方向を、方向ベクトルに変換
        Vector3 direction = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward;

        // 現在時刻のミリ秒でシード値を初期化
        Random.InitState(DateTime.Now.Millisecond);

        // 発射方向を少しずらす
        direction.x += Random.Range(0.0f, bloodMoveShaking.x);
        direction.y += Random.Range(0.0f, bloodMoveShaking.y);
        direction.z += Random.Range(0.0f, bloodMoveShaking.z);

        // 血を飛ばす
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

        // 指定時間経過で血を削除
        Destroy(gameObject, time);
    }
}
