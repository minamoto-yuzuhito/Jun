using UnityEngine;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using static UnityEngine.GridBrushBase;
using static ToothController;

/// <summary>
/// 空中浮遊移動
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GrabPoint")]
    private GameObject grabPoint;

    [SerializeField]
    [Tooltip("RightHand")]
    private Rigidbody rightHand;
    
    [SerializeField]
    [Tooltip("LeftHand")]
    private Rigidbody leftHand;

    // 移動するオブジェクトのRigidbody
    Rigidbody rb;

    // 落下速度を返す
    public float GetVelocityY() { return rb.velocity.y; }

    private float hori;
    private float vert;

    private float directionHori = 1.0f;
    public void InversionDirectionHori(float Value) { directionHori = Value; }
    private float directionVert = 1.0f;
    public void InversionDirectionVert(float Value) { directionVert = Value; }

    private GameObject grabPointObject;

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
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = hori * 10 * directionHori;
        newVelocity.z = vert * 10 * directionVert;

        // 速度制限
        if(rb.velocity.y < -50.0f)
        {
            newVelocity.y = -50.0f;
        }

        rb.velocity = newVelocity;
    }

    // 掴む
    public void IsGrapple()
    {
        // 左クリックされた瞬間
        if (Input.GetMouseButtonDown(0))
        {
            // 左手をその場で固定
            //leftHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            IsRotation(leftHand.gameObject);
        }
        
        // 左クリックを離したとき
        else if (Input.GetMouseButtonUp(0))
        {
            if(grabPointObject != null)
            {
                // 親子関係を解除
                leftHand.transform.parent.parent = null;

                // 削除
                Destroy(grabPointObject);
            }
        }

        // 右クリックされた瞬間
        if (Input.GetMouseButtonDown(1))
        {
            IsRotation(rightHand.gameObject);
        }
        
        // 右クリックを離したとき
        else if (Input.GetMouseButtonUp(1))
        {
            if (grabPointObject != null)
            {
                // 親子関係を解除
                rightHand.transform.parent.parent = null;

                // 削除
                Destroy(grabPointObject);
            }
        }
    }

    void IsRotation(GameObject HandObject)
    {
        grabPointObject = Instantiate(grabPoint, HandObject.transform.position, Quaternion.identity);

        if(HandObject == leftHand.gameObject)
        {
            grabPointObject.GetComponent<Rotation>().IsRotateLeft();
        }
        else if (HandObject == rightHand.gameObject)
        {
            grabPointObject.GetComponent<Rotation>().IsRotateRight();
        }

        HandObject.transform.parent.parent = grabPointObject.transform;
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