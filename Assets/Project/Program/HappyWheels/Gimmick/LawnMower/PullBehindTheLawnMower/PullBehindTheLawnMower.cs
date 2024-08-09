using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBehindTheLawnMower : MonoBehaviour
{
    // 芝刈り機を構成するオブジェクト
    public enum LawnMowerObjects
    {
        kInhaleZone,    // 入口のセンサー。検知したものを奥に吸い込む
        kBreakZone,     // 終点のセンサー。検知したものを破壊する
    }

    // 目的地
    private GameObject endPoint;

    [SerializeField]
    [Tooltip("芝刈り機がオブジェクトを吸い込む速度")]
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = transform.parent.transform.GetChild((int)LawnMowerObjects.kBreakZone).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 芝刈り機の奥に連れていくオブジェクトを目的地まで移動
        transform.position =
        Vector3.MoveTowards(
            transform.position,
            endPoint.transform.position,
            speed * Time.deltaTime);
    }
}
