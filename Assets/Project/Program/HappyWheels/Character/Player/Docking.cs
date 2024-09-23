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

        // êlä‘Ç…êGÇÍÇΩÇ∆Ç´
        if (objectName == "BodyParts")
        {
            Debug.Log("êlä‘Ç…êGÇÍÇΩ");
            FixedJoint fixedJoint = collision.transform.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = GetComponent<Rigidbody>();
        }
    }
}
