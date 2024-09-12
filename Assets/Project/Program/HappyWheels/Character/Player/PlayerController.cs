using UnityEngine;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;

/// <summary>
/// 空中浮遊移動
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("RightHand")]
    private Rigidbody rightHand;
    
    [SerializeField]
    [Tooltip("LeftHand")]
    private Rigidbody leftHand;

    Rigidbody rb;

    private float hori;
    private float vert;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 移動の入力
    /// </summary>
    public void IsMoveInput()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
    }

    public void IsMove()
    {
        rb.velocity = new Vector3(hori, 0, vert) * 10;
    }

    // 掴む
    public void IsGrapple()
    {
        // 左クリックされた瞬間
        if (Input.GetMouseButtonDown(0))
        {
            // 左手をその場で固定
            leftHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        
        // 左クリックを離したとき
        else if (Input.GetMouseButtonUp(0))
        {
            // 位置 Y だけ固定
            leftHand.constraints = RigidbodyConstraints.FreezePositionY;
        }

        // 右クリックされた瞬間
        if (Input.GetMouseButtonDown(1))
        {
            // 右手をその場で固定
            rightHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        
        // 右クリックを離したとき
        else if (Input.GetMouseButtonUp(1))
        {
            // 位置 Y だけ固定
            rightHand.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void IsStop()
    {
        // 速度
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // 角度
        rb.rotation = Quaternion.identity;

        // 回転、位置ともに固定
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}