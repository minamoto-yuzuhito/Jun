using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;
    public void InitPlayerController() { playerController = null; }

    [SerializeField]
    [Tooltip("���݂̊K�w��\������Text�^�̕ϐ�")]
    private TextMeshProUGUI clearRoomText;

    [SerializeField]
    [Tooltip("�Q�[������UI")]
    private CanvasGroup gameCanvas;

    [SerializeField]
    [Tooltip("BGM�\����UI")]
    private CanvasGroup soundCanvas;

    [SerializeField]
    [Tooltip("�Q�[���I�[�o�[����UI")]
    private CanvasGroup gameOverCanvas;

    /// <summary>
    /// �N���A���������J�E���g���āA�e�L�X�g���X�V
    /// </summary>
    public void SetClearRoomText()
    {
        clearRoomNum++;
        clearRoomText.text = "Score:" + clearRoomNum;
    }

    // �˔j������
    private int clearRoomNum = 0;
    public int GetClearRoomNum() { return clearRoomNum; }   // �Q�b�^�[
    public void CountClearRoomNum() { clearRoomNum++; }   // 1�J�E���g����

    // �Q�[���I�[�o�[����
    private bool isGameOver;
    /// <summary>
    /// �Q�[���I�[�o�[���Ɏ��s�����
    /// </summary>
    public void IsGameOver()
    {
        isGameOver = true;
        gameCanvas.DOFade(0.0f, 0.0f);      // ��\��
        gameOverCanvas.DOFade(1.0f, 0.0f);  // �\��
    }

    private void Start()
    {
        // �w�莞�Ԍ�Ɏ��s
        Invoke("SoundCanvasFade", 2.0f);
    }

    void SoundCanvasFade()
    {
        // �w�莞�Ԃ����Ĕ�\���ɂ���
        soundCanvas.DOFade(0.0f, 1.0f);
    }

    /// <summary>
    /// �����ł͑�����͂��s��
    /// </summary>
    private void Update()
    {
        if(isGameOver)
        {
            return;
        }

        if (playerController != null)
        {
            // �L�[���͂��󂯕t����
            playerController.IsMoveInput();
        }
    }

    /// <summary>
    /// �����Ŏ��ۂɃv���C���[���ړ�������
    /// Rigidbody���g�p����ړ���FixedUpdate�ōs��
    /// </summary>
    private void FixedUpdate()
    {
        if (isGameOver)
        {
            return;
        }

        if (playerController != null)
        {
            // �v���C���[�̑���
            playerController.IsMove();
        }
    }
}
