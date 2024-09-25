using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void SetScoreNumText()
    {
        ScoreNum++;
        clearRoomText.text = "Score:" + ScoreNum;
    }

    // �˔j������
    private int ScoreNum = 0;
    public int GetClearRoomNum() { return ScoreNum; }   // �Q�b�^�[
    public void CountClearRoomNum() { ScoreNum++; }   // 1�J�E���g����

    // �Q�[���I�[�o�[���ɁA
    // �Ȃ�炩�̃L�[���}�E�X�{�^����������Ă���Ƃ�true
    bool isGameOverInputAnyKey;

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

        isGameOverInputAnyKey = true;
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
            // ��x�L�[�𗣂��Ȃ��Ƃ����Ȃ�
            if (!Input.anyKey)
            {
                isGameOverInputAnyKey = false;
            }

            if (!isGameOverInputAnyKey)
            {
                if (Input.anyKey)
                {
                    Debug.Log("A key or mouse click has been detected");

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

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
