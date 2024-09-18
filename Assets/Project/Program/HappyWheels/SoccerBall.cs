using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    [SerializeField]
    [Tooltip("TableSoccerController")]
    private TableSoccerController tableSoccerController;

    /// <summary>
    /// プレイヤーのセンサーに触れたとき
    /// レイヤー設定によってサッカーボールオブジェクトはプレイヤーのセンサーしか検知できない
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject.GetComponent<SoccerPlayerSensor>().GetOperationObject();

        tableSoccerController.SetOperationObject(obj);
    }
}
