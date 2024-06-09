using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("落下速度")]
    private float speed = -0.005f;

    // Update is called once per frame
    void Update()
    {
        // フレームごとに等速で落下させる
        transform.Translate(0, speed, 0);
    }
}
