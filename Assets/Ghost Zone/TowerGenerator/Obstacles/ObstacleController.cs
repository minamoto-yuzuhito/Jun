using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    //--- �����ړ������Q�� ---//
    [SerializeField]
    [Tooltip("ture�F�����ړ������Q����2��")]
    private bool thisIsObstacleMoveDual;
    [SerializeField]
    [Tooltip("true�F�����ړ������Q����4��")]
    private bool thisIsObstacleMoveQuad;
    [SerializeField]
    [Tooltip("�ړI�n")]
    private Transform crossMoveEndPos;
    [SerializeField]
    [Tooltip("�ړ��ɂ����鎞��")]
    private float crossMoveSpeed = 5.0f;

    //--- ��]�����Q�� ---//
    [SerializeField]
    [Tooltip("true�F��]�����Q��")]
    private bool thisIsObstacleRotation;
    [SerializeField]
    [Tooltip("��]�ɂ����鎞��")]
    private float ObstacleRotationSpeed = 5.0f;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g���폜�����܂ł̎���")]
    private float lifeTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //--- �����ړ������Q�� ---//
        // 2�̎�
        if (thisIsObstacleMoveDual)
        {
            Destroy(transform.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }
        // 4�̎�
        else if(thisIsObstacleMoveQuad)
        {
            Destroy(transform.parent.parent.gameObject, lifeTime);
            ObstacleMoveOperation();
            return;
        }

        //--- ��]�����Q�� ---//
        if (thisIsObstacleRotation)
        {
            ObstacleRotationOperation();
        }

        // �w�莞�Ԍ�ɏ�Q�����폜
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// ��]�����Q��
    /// </summary>
    void ObstacleRotationOperation()
    {
        transform.DORotate(new Vector3(0, 360, 0), ObstacleRotationSpeed, RotateMode.LocalAxisAdd). // ���[�J�����ɑ΂��ĉ�]
            SetLoops(-1, LoopType.Restart). // �������ɍŏ������蒼��
            SetEase(Ease.Linear);   // �ɋ}�̂Ȃ�����
    }

    /// <summary>
    /// �����ړ������Q��
    /// </summary>
    void ObstacleMoveOperation()
    {
        transform.DOMove(crossMoveEndPos.position, crossMoveSpeed).
            SetLoops(-1, LoopType.Yoyo). // �J��Ԃ�
            SetEase(Ease.Linear);   // �ɋ}�̂Ȃ�����
    }
}
