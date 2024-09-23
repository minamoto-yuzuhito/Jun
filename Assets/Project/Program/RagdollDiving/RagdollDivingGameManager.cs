using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;

    [SerializeField]
    [Tooltip("���݂̊K�w��\������Text�^�̕ϐ�")]
    private TextMeshProUGUI clearRoomText;

    /// <summary>
    /// �N���A���������J�E���g���āA�e�L�X�g���X�V
    /// </summary>
    public void SetClearRoomText()
    {
        clearRoomNum++;
        clearRoomText.text = "Clear:" + clearRoomNum;
    }

    // �˔j������
    private int clearRoomNum = 0;
    public int GetClearRoomNum() { return clearRoomNum; }   // �Q�b�^�[
    public void CountClearRoomNum() { clearRoomNum++; }   // 1�J�E���g����

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
