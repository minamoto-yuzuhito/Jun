using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodLost : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ŒŒ")]
    private GameObject blood;

    // Update is called once per frame
    void Update()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// w’èŠÔŒã‚ÉoŒŒ‚ğ~‚ß‚é
    /// </summary>
    public void BloodLossStopAafter()
    {
        // 2•bŒã‚ÉoŒŒ‚ğ~‚ß‚é
        Invoke("BloodLossStop", 5);
    }

    /// <summary>
    /// oŒŒ‚ğ~‚ß‚é
    /// </summary>
    void BloodLossStop()
    {
        GetComponent<BloodLost>().enabled = false;
    }
}
