using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーのセンサーに触れたとき
    /// レイヤー設定によってサッカーボールオブジェクトはプレイヤーのセンサーしか検知できない
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("すり抜けた！");


    }
}
