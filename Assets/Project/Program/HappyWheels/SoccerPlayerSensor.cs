using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Z���T�[�����m�����ۂɑ��삷��I�u�W�F�N�g���삷��I�u�W�F�N�g")]
    private GameObject operationObject;

    [SerializeField]
    [Tooltip("TableSoccerController")]
    private TableSoccerController tableSoccerController;

    /// <summary>
    /// ���C���[�ݒ�ɂ����SoccerBallSensor�I�u�W�F�N�g�̓v���C���[�Z���T�[�I�u�W�F�N�g�������m�ł��Ȃ�
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        tableSoccerController.SetOperationObject(operationObject);
    }
}
