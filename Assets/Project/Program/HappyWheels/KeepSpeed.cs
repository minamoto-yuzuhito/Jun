using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeepSpeed : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerController")]
    private PlayerController playerController;

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("“–‚½‚Á‚Ä‚¢‚é");

        playerController.InversionDirectionHori(-5);
        playerController.InversionDirectionVert(-5
            );
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("—£‚ê‚½");

        playerController.InversionDirectionHori(1);
        playerController.InversionDirectionVert(1);
    }
}
