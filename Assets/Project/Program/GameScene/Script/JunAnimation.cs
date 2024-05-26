using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JunAnimation : MonoBehaviour
{
    private Vector3 junInitialPos;
    private Vector3 junInitialRot;

    // 成功時のアニメーション
    public float animationPlayTimeSuccess = 0.2f;   // アニメーションの再生時間
    public float animationPosXSuccess = -10f;       // 開始時の座標
    public float animationInitPosXSuccess = -30f;   // 終了時の座標

    // 失敗時のアニメーション
    public float animationPlayTimeMiss = 0.6f;   // アニメーションの再生時間
    public float animationInitPosYMiss = -5f;   // 終了時の座標

    private ToothController toothController;

    private void Start()
    {
        toothController = transform.GetChild(0).GetComponent<ToothController>();

        junInitialPos.x = transform.position.x;
        junInitialPos.y = transform.position.y;
        junInitialPos.z = transform.position.z;

        junInitialRot.x = transform.root.rotation.x;
        junInitialRot.y = transform.root.rotation.y;
        junInitialRot.z = transform.root.rotation.z;
    }

    /// <summary>
    /// 成功
    /// </summary>
    public void Success()
    {
        Vector3 rotate = Vector3.zero;
        rotate.x = transform.root.rotation.x;
        rotate.y = transform.root.rotation.y;
        rotate.z = transform.root.rotation.z;

        rotate.x = animationPosXSuccess;
        transform.DORotate(rotate, 0, RotateMode.WorldAxisAdd);  //ワールド軸に対して

        
        rotate.x = animationInitPosXSuccess;
        transform.DORotate(rotate, animationPlayTimeSuccess, RotateMode.WorldAxisAdd)   //ワールド軸に対して
            .SetLoops(-1, LoopType.Yoyo);

        // 指定秒後にアニメーションを停止する
        Invoke("StopAnimation", animationPlayTimeSuccess * 6);
    }

    /// <summary>
    /// 失敗
    /// </summary>
    public void Miss()
    {
        transform.DOMoveY(animationInitPosYMiss, animationPlayTimeMiss).
            SetEase(Ease.OutQuart).
            SetLoops(-1, LoopType.Yoyo);

        // 指定秒後にアニメーションを停止する
        Invoke("StopAnimation", animationPlayTimeMiss * 2);
    }

    private void StopAnimation()
    {
        transform.DOKill();

        transform.position = junInitialPos;
        transform.eulerAngles = junInitialRot;

        // アニメーションが終了した判定
        toothController.SetIsThrowFlag(true);
    }
}
