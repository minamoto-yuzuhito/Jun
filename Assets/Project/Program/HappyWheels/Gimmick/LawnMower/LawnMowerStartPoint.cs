using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LawnMowerStartPoint : MonoBehaviour
{
    // 目的地
    private GameObject endPoint;

    [SerializeField]
    [Tooltip("芝刈り機がオブジェクトを吸い込む速度")]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = transform.parent.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 吸い込み口を目的地まで移動
        transform.position =
        Vector3.MoveTowards(
            transform.position,
            endPoint.transform.position,
            speed * Time.deltaTime);
    }
}
