using UnityEngine;
using System.Collections;
using Cinemachine;

/// <summary>
/// ‹ó’†•‚—VˆÚ“®
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("CinemachineVirtualCamera")]
    private CinemachineVirtualCamera suctionVirtualCamera;

    private const float G = 9.9f;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// ˆÚ“®
    /// </summary>
    public void IsMove()
    {
        // ƒJƒƒ‰‚ğŒ©‰º‚ë‚µ‹“_‚Éİ’è
        suctionVirtualCamera.enabled = false;

        // ˆÊ’uY‚¾‚¯ŒÅ’è
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //--- ˆÚ“® ---//
        //var velocity = new Vector3(0, 0, 0);
        //velocity.x += Input.GetAxis("Horizontal");
        //velocity.z += Input.GetAxis("Vertical");
        //rb.velocity = velocity * 500 * Time.deltaTime;

        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(hori, 0, vert) * 10;

        //--- ˆÚ“®•ûŒü‚É­‚µŒX‚¯‚é ---//
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
        //rb.rotation = Quaternion.Euler(eular);
    }

    /// <summary>
    /// ’â~
    /// </summary>
    public void IsStop()
    {
        // ‰¡‚©‚çŒ©‚é
        suctionVirtualCamera.enabled = true;

        // ‘¬“x
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // Šp“x
        rb.rotation = Quaternion.identity;

        // ‰ñ“]AˆÊ’u‚Æ‚à‚ÉŒÅ’è
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}