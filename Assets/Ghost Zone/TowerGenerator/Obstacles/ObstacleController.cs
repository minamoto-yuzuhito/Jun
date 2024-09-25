using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    //--- 直線移動する障害物 ---//
    [SerializeField]
    [Tooltip("ture：直線移動する障害物が2個")]
    private bool thisIsObstacleMoveDual;
    [SerializeField]
    [Tooltip("true：直線移動する障害物が4個")]
    private bool thisIsObstacleMoveQuad;
    [SerializeField]
    [Tooltip("目的地")]
    private Transform crossMoveEndPos;
    [SerializeField]
    [Tooltip("移動にかかる時間")]
    private float crossMoveSpeed = 5.0f;

    //--- 回転する障害物 ---//
    [SerializeField]
    [Tooltip("true：回転する障害物")]
    private bool thisIsObstacleRotation;
    [SerializeField]
    [Tooltip("回転にかかる時間")]
    private float ObstacleRotationSpeed = 5.0f;

    [SerializeField]
    [Tooltip("オブジェクトが削除されるまでの時間")]
    private float lifeTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //--- 直線移動する障害物 ---//
        // 2個の時
        if (thisIsObstacleMoveDual)
        {
            Destroy(transform.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }
        // 4個の時
        else if(thisIsObstacleMoveQuad)
        {
            Destroy(transform.parent.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }

        //--- 回転する障害物 ---//
        if (thisIsObstacleRotation)
        {
            ObstacleRotationOperation();
        }

        // 指定時間後に障害物を削除
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// 回転する障害物
    /// </summary>
    void ObstacleRotationOperation()
    {
        transform.DORotate(new Vector3(0, 360, 0), ObstacleRotationSpeed, RotateMode.LocalAxisAdd). // ローカル軸に対して回転
            SetLoops(-1, LoopType.Restart). // 完了時に最初からやり直す
            SetEase(Ease.Linear);   // 緩急のない動き
    }

    /// <summary>
    /// 直線移動する障害物
    /// </summary>
    void ObstacleMoveOperation()
    {
        transform.DOMove(crossMoveEndPos.position, crossMoveSpeed).
            SetLoops(-1, LoopType.Yoyo). // 繰り返し
            SetEase(Ease.Linear);   // 緩急のない動き
    }
}
