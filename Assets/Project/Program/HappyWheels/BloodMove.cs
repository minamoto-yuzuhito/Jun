using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("—‰º‘¬“x")]
    private float speed = -0.005f;

    // Update is called once per frame
    void Update()
    {
        // ƒtƒŒ[ƒ€‚²‚Æ‚É“™‘¬‚Å—‰º‚³‚¹‚é
        transform.Translate(0, speed, 0);
    }
}
