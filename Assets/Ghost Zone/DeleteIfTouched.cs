using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤーの体力が0になった際に生成される床と、
/// プレイヤーの接触を判定する
/// </summary>
public class DeleteIfTouched : MonoBehaviour
{
    // プレイヤーとしか接触しないようにレイヤー設定されている
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
