using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.transform.tag);

        // プレイヤーに触れた時
        if (collision.transform.GetComponent<CheckImpact>() != null)
        {
            Debug.Log("プレイヤーをキック");

            Vector3 newVelocity = GetComponent<Rigidbody>().velocity;
            newVelocity.x *= 5.0f;
            newVelocity.z *= 5.0f;
            collision.rigidbody.velocity = newVelocity;
        }
    }
}
