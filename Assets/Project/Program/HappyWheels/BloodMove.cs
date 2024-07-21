using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("速度")]
    private float speed;

    // Destroyする時間を指定する
    public float time = 2;

    // Update is called once per frame
    void Start()
    {
        // 生成された血を少し上に飛ばす
        GetComponent<Rigidbody>().AddForce(transform.up * speed, ForceMode.Impulse);

        // 指定時間経過で血を削除
        Destroy(gameObject, time);
    }
}
