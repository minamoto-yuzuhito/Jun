using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;

    /// <summary>
    /// �����ł͑�����͂��s��
    /// </summary>
    private void Update()
    {
        // �L�[���͂��󂯕t����
        playerController.IsMoveInput();
    }

    /// <summary>
    /// �����Ŏ��ۂɃv���C���[���ړ�������
    /// Rigidbody���g�p����ړ���FixedUpdate�ōs��
    /// </summary>
    private void FixedUpdate()
    {
        // �v���C���[�̑���
        playerController.IsMove();
    }
}
