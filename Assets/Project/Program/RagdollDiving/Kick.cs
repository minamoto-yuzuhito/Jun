using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        // ÉvÉåÉCÉÑÅ[Ç…êGÇÍÇΩéû
        if (collision.transform.GetComponent<CheckImpact>() != null)
        {
            Vector3 newVelocity = GetComponent<Rigidbody>().velocity;
            newVelocity.x *= 5.0f;
            newVelocity.z *= 5.0f;
            collision.rigidbody.velocity = newVelocity;
        }
    }
}
