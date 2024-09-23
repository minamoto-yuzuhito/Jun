using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.transform.tag);

        if(collision.transform.GetComponent<CheckImpact>() != null)
        {
            // �v���C���[�ɐG�ꂽ��
            if (collision.transform.GetComponent<CheckImpact>().GetObjectName() == "BodyParts")
            {
                Debug.Log("�v���C���[���L�b�N");

                Vector3 newVelocity = GetComponent<Rigidbody>().velocity;
                newVelocity.x *= 5.0f;
                newVelocity.z *= 5.0f;
                collision.rigidbody.velocity = newVelocity;
            }
        }
    }
}
