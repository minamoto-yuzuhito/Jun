using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("センサーが感知した際に操作するオブジェクト操作するオブジェクト")]
    private GameObject operationObject;

    [SerializeField]
    [Tooltip("TableSoccerController")]
    private TableSoccerController tableSoccerController;

    /// <summary>
    /// レイヤー設定によってSoccerBallSensorオブジェクトはプレイヤーセンサーオブジェクトしか検知できない
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        tableSoccerController.SetOperationObject(operationObject);
    }
}
