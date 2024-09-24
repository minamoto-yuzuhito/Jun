using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    //--- �N���X���[�u ---//
    [SerializeField]
    [Tooltip("Obstacle_CrossMove")]
    private bool thisIsObstacleCrossMove;
    [SerializeField]
    [Tooltip("�ړI�n")]
    private Transform crossMoveEndPos;
    [SerializeField]
    [Tooltip("�ړ��ɂ����鎞��")]
    private float crossMoveSpeed = 5.0f;

    //--- ��] ---//
    [SerializeField]
    [Tooltip("Obstacle_Rotation")]
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
        transform.DORotate(new Vector3(0, 360, 0), ObstacleRotationSpeed, RotateMode.LocalAxisAdd). // ���[�J�����ɑ΂��ĉ�]
            SetLoops(-1, LoopType.Restart). // �������ɍŏ������蒼��
            SetEase(Ease.Linear);   // �ɋ}�̂Ȃ�����
    }

    void ObstacleMoveOperation()
    {
        transform.DOMove(crossMoveEndPos.position, crossMoveSpeed).
            SetLoops(-1, LoopType.Yoyo). // �J��Ԃ�
            SetEase(Ease.Linear);   // �ɋ}�̂Ȃ�����
    }
}
