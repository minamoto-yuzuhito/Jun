using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteIfTouched : MonoBehaviour
{
    // プレイヤーとしか接触しないようにレイヤー設定されている
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
