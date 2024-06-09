using System.Collections;
using System.Collections.Generic;
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
}
