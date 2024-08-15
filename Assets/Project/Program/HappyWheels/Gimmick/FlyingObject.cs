using UnityEngine;
using System.Collections;
using Cinemachine;

/// <summary>
/// 空中浮遊移動
/// </summary>
public class FlyingObject : MonoBehaviour
{
    [SerializeField]
    [Tooltip("CinemachineVirtualCamera")]
    private CinemachineVirtualCamera playerMoveVirtualCamera;

    private const float G = 9.9f;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 移動
    /// </summary>
    public void IsMove()
    {
        // カメラを見下ろし視点に設定
        playerMoveVirtualCamera.enabled = true;

        // 位置Yだけ固定
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //--- 移動 ---//
        var velocity = new Vector3(0, 0, 0);
        velocity.x += Input.GetAxis("Horizontal");
        velocity.z += Input.GetAxis("Vertical");
        rb.velocity = velocity * 500 * Time.deltaTime + new Vector3(0, G + Random.Range(0.0f, 10.0f), 0) * Time.deltaTime;

        //--- 移動方向に少し傾ける ---//
        var zEular = 0.0f;
        if (rb.velocity.x > 0)
        {
            zEular = -5.0f;
        }
        else if (rb.velocity.x < 0)
        {
            zEular = 5.0f;
        }

        var xEular = 0.0f;
        if (rb.velocity.z > 0)
        {
            xEular = 5.0f;
        }
        else if (rb.velocity.z < 0)
        {
            xEular = -5.0f;
        }
        var eular = new Vector3(xEular, 0, zEular);
        rb.rotation = Quaternion.Euler(eular);
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void IsStop()
    {
        // 横から見る
        playerMoveVirtualCamera.enabled = false;

        // 速度
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // 角度
        rb.rotation = Quaternion.identity;

        // 回転、位置ともに固定
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}