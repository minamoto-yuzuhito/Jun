using UnityEngine;
using System.Collections;

/// <summary>
/// ‹ó’†•‚—VˆÚ“®
/// </summary>
public class FlyingObject : MonoBehaviour
{
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
        //--- ˆÚ“® ---//
        var velocity = new Vector3(0, 0, 0);
        velocity.x += Input.GetAxis("Horizontal");
        velocity.z += Input.GetAxis("Vertical");
        rb.velocity = velocity * 500 * Time.deltaTime + new Vector3(0, G + Random.Range(0.0f, 10.0f), 0) * Time.deltaTime;

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
        rb.rotation = Quaternion.Euler(eular);
    }

    /// <summary>
    /// ’âŽ~
    /// </summary>
    public void IsStop()
    {
        // ‘¬“x
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // Šp“x
        rb.rotation = Quaternion.identity;
    }
}