using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SoccerBal : MonoBehaviour
{
    [SerializeField]
    [Tooltip("サッカーボールを飛ばす方向")]
    private Vector3 moveShaking = new Vector3(0.0f, 0.0f, -5.0f);

    [SerializeField]
    [Tooltip("最大速度")]
    private Vector3 speedLimit = new Vector3(10.0f, 10.0f, 10.0f);

    [SerializeField]
    [Tooltip("反射時に付与する速度")]
    private float reflectSpeed = 5.0f;

    [SerializeField]
    [Tooltip("徐々に上げる速度の倍率\n現在の速度 / accelerationSpeed を毎フレーム加算していく")]
    private float accelerationSpeed = 50.0f;

    private Rigidbody ballRb;

    // レイがオブジェクトに当たった際、取得される情報
    private RaycastHit fastRayHitInfo;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();

        // 飛ばす
        GetComponent<Rigidbody>().AddForce(moveShaking, ForceMode.Impulse);
    }

    private void Update()
    {
        // レイの発射方向
        Vector3 velocity = ballRb.velocity;         // 速度ベクトル
        Vector3 direction = velocity.normalized;    // 速度ベクトルを正規化する

        var radius = GetComponent<SphereCollider>().radius;

        var isHit = Physics.SphereCast(transform.position, radius, direction * 10, out fastRayHitInfo);
    }

    /// <summary>
    /// 徐々に加速していく
    /// </summary>
    public void Acceleration()
    {
        Vector3 ballVelocity = ballRb.velocity;

        // X軸方向に加速
        ballVelocity.x += ballVelocity.x / accelerationSpeed;
        // 絶対値で比較
        if(Mathf.Abs( ballVelocity.x) > speedLimit.x)
        {
            // 負の数の時
            if(Mathf.Sign(ballVelocity.x) == -1)
            {
                ballVelocity.x = -speedLimit.x;
            }
            else
            {
                ballVelocity.x = speedLimit.x;
            }
        }

        // Z軸方向に加速
        ballVelocity.z += ballVelocity.z / accelerationSpeed;
        // 絶対値で比較
        if (Mathf.Abs(ballVelocity.z) > speedLimit.z)
        {
            // 負の数の時
            if (Mathf.Sign(ballVelocity.z) == -1)
            {
                ballVelocity.z = -speedLimit.z;
            }
            else
            {
                ballVelocity.z = speedLimit.z;
            }
        }

        ballRb.velocity = ballVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ReflectObject"))
        {
            // 入射ベクトル（速度）
            var inDirection = ballRb.velocity.normalized;

            // 法線ベクトル
            var inNormal = fastRayHitInfo.normal;

            // 反射ベクトル（速度）
            var result = Vector3.Reflect(inDirection, inNormal).normalized;

            // バウンド後の速度をボールに反映
            ballRb.velocity = result * reflectSpeed;
        }
    }
}
