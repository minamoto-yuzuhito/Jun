using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    //--- ’¼üˆÚ“®‚·‚éáŠQ•¨ ---//
    [SerializeField]
    [Tooltip("tureF’¼üˆÚ“®‚·‚éáŠQ•¨‚ª2ŒÂ")]
    private bool thisIsObstacleMoveDual;
    [SerializeField]
    [Tooltip("trueF’¼üˆÚ“®‚·‚éáŠQ•¨‚ª4ŒÂ")]
    private bool thisIsObstacleMoveQuad;
    [SerializeField]
    [Tooltip("–Ú“I’n")]
    private Transform crossMoveEndPos;
    [SerializeField]
    [Tooltip("ˆÚ“®‚É‚©‚©‚éŠÔ")]
    private float crossMoveSpeed = 5.0f;

    //--- ‰ñ“]‚·‚éáŠQ•¨ ---//
    [SerializeField]
    [Tooltip("trueF‰ñ“]‚·‚éáŠQ•¨")]
    private bool thisIsObstacleRotation;
    [SerializeField]
    [Tooltip("‰ñ“]‚É‚©‚©‚éŠÔ")]
    private float ObstacleRotationSpeed = 5.0f;

    [SerializeField]
    [Tooltip("ƒIƒuƒWƒFƒNƒg‚ªíœ‚³‚ê‚é‚Ü‚Å‚ÌŠÔ")]
    private float lifeTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //--- ’¼üˆÚ“®‚·‚éáŠQ•¨ ---//
        // 2ŒÂ‚Ì
        if (thisIsObstacleMoveDual)
        {
            Destroy(transform.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }
        // 4ŒÂ‚Ì
        else if(thisIsObstacleMoveQuad)
        {
            Destroy(transform.parent.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }

        //--- ‰ñ“]‚·‚éáŠQ•¨ ---//
        if (thisIsObstacleRotation)
        {
            ObstacleRotationOperation();
        }

        // w’èŠÔŒã‚ÉáŠQ•¨‚ğíœ
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// ‰ñ“]‚·‚éáŠQ•¨
    /// </summary>
    void ObstacleRotationOperation()
    {
        transform.DORotate(new Vector3(0, 360, 0), ObstacleRotationSpeed, RotateMode.LocalAxisAdd). // ƒ[ƒJƒ‹²‚É‘Î‚µ‚Ä‰ñ“]
            SetLoops(-1, LoopType.Restart). // Š®—¹‚ÉÅ‰‚©‚ç‚â‚è’¼‚·
            SetEase(Ease.Linear);   // ŠÉ‹}‚Ì‚È‚¢“®‚«
    }

    /// <summary>
    /// ’¼üˆÚ“®‚·‚éáŠQ•¨
    /// </summary>
    void ObstacleMoveOperation()
    {
        transform.DOMove(crossMoveEndPos.position, crossMoveSpeed).
            SetLoops(-1, LoopType.Yoyo). // ŒJ‚è•Ô‚µ
            SetEase(Ease.Linear);   // ŠÉ‹}‚Ì‚È‚¢“®‚«
    }
}
