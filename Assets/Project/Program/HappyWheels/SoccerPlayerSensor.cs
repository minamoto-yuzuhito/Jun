using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("センサーが感知した際に操作するオブジェクト操作するオブジェクト")]
    private GameObject operationObject;
    public GameObject GetOperationObject() {  return operationObject; } // ゲッター
}
