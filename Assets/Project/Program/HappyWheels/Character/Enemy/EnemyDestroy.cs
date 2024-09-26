using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�G��|�����ۂ̓��_")]
    private int scoreNum = 10;

    // true�F���Ɏ��s��
    private bool isMyDestroy;

    public void MyDestroy()
    {
        // ���Ɏ��s���̏ꍇ�͏I��
        if (isMyDestroy) return;

        // ���s��������
        isMyDestroy = true;

        // �w�莞�Ԍ�ɓG���폜
        Invoke("Destroy", 3.0f);
    }

    private void Destroy()
    {
        // �Q�[���}�l�[�W���[���擾
        RagdollDivingGameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // �X�R�A�����Z
        gameManager.AddScore(scoreNum);

        // �G�̐��̃J�E���g��-1
        gameManager.SetNowEnemyNum(-1);

        // �G���폜
        Destroy(transform.gameObject);
    }
}
