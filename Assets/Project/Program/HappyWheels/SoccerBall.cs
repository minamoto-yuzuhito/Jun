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
    /// �v���C���[�̃Z���T�[�ɐG�ꂽ�Ƃ�
    /// ���C���[�ݒ�ɂ���ăT�b�J�[�{�[���I�u�W�F�N�g�̓v���C���[�̃Z���T�[�������m�ł��Ȃ�
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject.GetComponent<SoccerPlayerSensor>().GetOperationObject();

        tableSoccerController.SetOperationObject(obj);
    }
}
