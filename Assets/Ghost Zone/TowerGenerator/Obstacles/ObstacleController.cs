using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    //--- クロスムーブ ---//
    [SerializeField]
    [Tooltip("Obstacle_CrossMove")]
    private bool thisIsObstacleCrossMove;
    [SerializeField]
    [Tooltip("目的地")]
    private Transform crossMoveEndPos;
    [SerializeField]
    [Tooltip("移動にかかる時間")]
    private float crossMoveSpeed = 5.0f;

    //--- 回転 ---//
    [SerializeField]
    [Tooltip("Obstacle_Rotation")]
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
        if (thisIsObstacleCrossMove)
        {
            Destroy(transform.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }

        Destroy(gameObject, lifeTime);

        if (thisIsObstacleRotation)
        {
            ObstacleRotationOperation();
        }
    }

    void ObstacleRotationOperation()
    {
        transform.DORotate(new Vector3(0, 360, 0), ObstacleRotationSpeed, RotateMode.LocalAxisAdd). // ローカル軸に対して回転
            SetLoops(-1, LoopType.Restart). // 完了時に最初からやり直す
            SetEase(Ease.Linear);   // 緩急のない動き
    }

    void ObstacleMoveOperation()
    {
        transform.DOMove(crossMoveEndPos.position, crossMoveSpeed).
            SetLoops(-1, LoopType.Yoyo). // 繰り返し
            SetEase(Ease.Linear);   // 緩急のない動き
    }
}
