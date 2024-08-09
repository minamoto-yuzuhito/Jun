using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/// <summary>
/// 弾の生成時点で、弾はプレイヤーの方を向くように角度を設定される
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の速度")]
    private float speed = 5.0f;

    void Update()
    {
        // 弾の移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
