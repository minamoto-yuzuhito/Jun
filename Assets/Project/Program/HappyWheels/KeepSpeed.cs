using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeepSpeed : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindWithTag("Chest").GetComponent<PlayerController>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<CheckImpact>() != null)
        {
            // プレイヤーが触れた時
            if (collision.transform.GetComponent<CheckImpact>().GetObjectName() == "BodyParts")
            {
                playerController.InversionDirectionHori(-5);
                playerController.InversionDirectionVert(-5);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.GetComponent<CheckImpact>() != null)
        {
            // プレイヤーが触れた時
            if (collision.transform.GetComponent<CheckImpact>().GetObjectName() == "BodyParts")
            {
                playerController.InversionDirectionHori(1);
                playerController.InversionDirectionVert(1);
            }
        }
    }
}
