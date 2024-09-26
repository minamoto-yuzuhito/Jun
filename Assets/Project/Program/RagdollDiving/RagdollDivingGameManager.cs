using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerHPBar�N���X")]
    private PlayerHPBar playerHPBar;

    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;
    public void InitPlayerController() { playerController = null; }

    [SerializeField]
    [Tooltip("�Q�[���v���C���ɕ\������X�R�A")]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    [Tooltip("�Q�[���I�[�o�[��ʂɕ\������X�R�A")]
    private TextMeshProUGUI gameOverScoreText;

    [SerializeField]
    [Tooltip("�Q�[������UI")]
    private CanvasGroup gameCanvas;

    [SerializeField]
    [Tooltip("BGM�\����UI")]
    private CanvasGroup soundCanvas;

    [SerializeField]
    [Tooltip("�Q�[���I�[�o�[����UI")]
    private CanvasGroup gameOverCanvas;

    [SerializeField]
    [Tooltip("�v���C���[�̗̑͂�UI")]
    private CanvasGroup playerHPBarCanvas;

    [SerializeField]
    [Tooltip("���x���A�b�v���ɐ�������UI")]
    private GameObject levelUpCanvas;
    [SerializeField]
    [Tooltip("���x���A�b�v���ɐ�������UI�i�ő僌�x���j")]
    private GameObject levelMaxCanvas;

    private GameObject levelUpCanvasObj;

    [SerializeField]
    [Tooltip("���x���A�b�v�ɕK�v�ȃX�R�A")]
    private int[] levelUpScore = new int[] { 10, 30, 50 };

    [SerializeField]
    [Tooltip("�������ԏI�����ɐ������鏰")]
    private GameObject invisibleFloor;

    /// <summary>
    /// �X�R�A�����Z
    /// </summary>
    public void AddScore(int Value)
    {
        // �Q�[���I�[�o�[�ł͂Ȃ��Ƃ�
        if (!isGameOver)
        {
            // �X�R�A���Z
            ScoreNum += Value;

            bool isLevelUp = false;

            if (enemyGenerateLimit == 1)
            {
                if (ScoreNum >= levelUpScore[enemyGenerateLimit - 1])
                {
                    isLevelUp = true;
                    enemyGenerateLimit = 2;
                }
            }
            if (enemyGenerateLimit == 2)
            {
                if (ScoreNum >= levelUpScore[enemyGenerateLimit - 1])
                {
                    isLevelUp = true;
                    enemyGenerateLimit = 3;
                }
            }
            if (enemyGenerateLimit == 3)
            {
                if (ScoreNum >= levelUpScore[enemyGenerateLimit - 1])
                {
                    isLevelUp = true;
                    enemyGenerateLimit = 4;
                }
            }

            if (isLevelUp)
            {
                // ���ɐ�������Ă���Ƃ�
                if (levelUpCanvasObj != null) Destroy(levelUpCanvasObj);

                // ���x�����ő�̎��Ƃ���ȊO�̎��ŕ\������UI��ς���
                GameObject canvasObj = null;
                if (enemyGenerateLimit == 4) canvasObj = levelMaxCanvas;  // �ő僌�x��
                else canvasObj = levelUpCanvas;

                // ������ɓ_�ŏ��������s
                levelUpCanvasObj = Instantiate(canvasObj);
                levelUpCanvasObj.GetComponent<CanvasGroup>().
                    DOFade(0.0f, 1.0f).
                    SetLoops(5, LoopType.Yoyo). // �J��Ԃ�
                    OnComplete(() => Destroy(levelUpCanvasObj));
            }

            // �e�L�X�g�X�V
            scoreText.text = "Score:" + ScoreNum;
        }
    }

    /// <summary>
    /// �񕜎��̏���
    /// </summary>
    public void PlayerHPBarHealing()
    {
        // �̗͉�
        playerHPBar.IsHealing(10.0f);
    }

    // �˔j������
    private int ScoreNum = 0;
    public int GetClearRoomNum() { return ScoreNum; }   // �Q�b�^�[
    public void CountClearRoomNum() { ScoreNum++; }   // 1�J�E���g����

    // �Q�[���I�[�o�[���ɁA
    // �Ȃ�炩�̃L�[���}�E�X�{�^����������Ă���Ƃ�true
    bool isGameOverInputAnyKey = true;

    // �Q�[���I�[�o�[����
    private bool isGameOver;
    /// <summary>
    /// �Q�[���I�[�o�[���Ɏ��s�����
    /// </summary>
    public void IsGameOver()
    {
        // �Q�[���I�[�o�[����
        isGameOver = true;

        // �Q�[��UI
        gameCanvas.DOFade(0.0f, 0.0f);  // ��\��

        // �v���C���[�̗̑͂�UI
        playerHPBarCanvas.DOFade(0.0f, 0.0f);   // ��\��

        // �X�R�AUI
        gameOverCanvas.DOFade(1.0f, 0.0f);          // �\��
        gameOverScoreText.text = scoreText.text;    // �X�R�A����

        // ���ɐ�������Ă���Ƃ�
        if (levelUpCanvasObj != null) Destroy(levelUpCanvasObj);
    }

    // �����ł���G�̏����
    private int enemyGenerateLimit;
    public int GetEnemyGenerateLimit() { return enemyGenerateLimit; }   // �Q�b�^�[
    // ���݂���G�̐�
    private int nowEnemyNum;
    public int GetNowEnemyNum() { return nowEnemyNum; } // �Q�b�^�[
    public void SetNowEnemyNum(int Value) { nowEnemyNum += Value; } // �Z�b�^�[

    private void Start()
    {
        // �w�莞�Ԍ�Ɏ��s
        Invoke("SoundCanvasFade", 2.0f);

        // �����ł���G�̏����
        enemyGenerateLimit = 1;
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
        // ���Ԍo�߂Ńv���C���[��HP�o�[�����炷
        // HP�o�[��0�ɂȂ����Ƃ�true��Ԃ�
        if (playerHPBar.DamageInPlayer())
        {
            // ���삷��v���C���[�I�u�W�F�N�g���w�肳��Ă���Ƃ�
            if (playerController != null)
            {
                // �����ŗ������Ă���Ƃ�
                if (playerController.GetVelocityY() < -50.0f)
                {
                    // �������W
                    Vector3 newPos = playerController.transform.position;
                    newPos.y -= 5.0f;

                    // �v���C���[�̂������ɏ��𐶐�����
                    Instantiate(invisibleFloor, newPos, Quaternion.identity);

                    // �Q�[���I�[�o�[����
                    IsGameOver();
                }
            }
            else
            {
                // �Q�[���I�[�o�[����
                IsGameOver();
            }
        }

        // �Q�[���I�[�o�[��
        if (isGameOver)
        {
            // �L�[�ɐG��Ă��Ȃ��Ƃ�
            if (!Input.anyKey)
            {
                isGameOverInputAnyKey = false;
            }

            // �Q�[���I�[�o�[���ɉ�������̃L�[�ɐG��Ă����ꍇ�A
            // ��x�����Ȃ��ƃL�[���͂��󂯕t�����Ȃ�
            if (!isGameOverInputAnyKey)
            {
                // ��������̃L�[�ɐG�ꂽ�Ƃ�
                if (Input.anyKey)
                {
                    // ���g���C
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            return;
        }

        // ���삷��v���C���[�I�u�W�F�N�g���w�肳��Ă���Ƃ�
        if (playerController != null)
        {
            // �v���C���[����̃L�[���͂��󂯕t����
            playerController.IsMoveInput();
        }
    }

    /// <summary>
    /// �����Ŏ��ۂɃv���C���[���ړ�������
    /// Rigidbody���g�p����ړ���FixedUpdate�ōs��
    /// </summary>
    private void FixedUpdate()
    {
        // �Q�[���I�[�o�[��
        if (isGameOver)
        {
            return;
        }

        // ���삷��v���C���[�I�u�W�F�N�g���w�肳��Ă���Ƃ�
        if (playerController != null)
        {
            // �v���C���[�̑���
            playerController.IsMove();
        }
    }
}
