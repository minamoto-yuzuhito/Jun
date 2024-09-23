using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Docking : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        string objectName = "";

        if (collision.transform.GetComponent<CheckImpact>() != null)
        {
            objectName = collision.transform.GetComponent<CheckImpact>().GetObjectName();
        }
        
        if (objectName == "") return;

        Debug.Log(objectName);

        // �l�ԂɐG�ꂽ�Ƃ�
        if (objectName == "BodyParts")
        {
            Debug.Log("�l�ԂɐG�ꂽ");
            FixedJoint fixedJoint = collision.transform.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = GetComponent<Rigidbody>();
        }
    }
}
