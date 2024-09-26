using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �G�L�����N�^�[�����N���X
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�G�I�u�W�F�N�gPrefab")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("�G�̐����ʒu")]
    private GameObject enemyGeneratePos;

    /// <summary>
    /// �G�𐶐�
    /// </summary>
    public void GenerateEnemy()
    {
        // �Q�[���}�l�[�W���[���擾
        RagdollDivingGameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // �G�̐��������菭�Ȃ��Ƃ�
        if (gameManager.GetNowEnemyNum() < gameManager.GetEnemyGenerateLimit())
        {
            // �w��̈ʒu�ɐ���
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);

            // �G�̐��̃J�E���g��+1
            gameManager.SetNowEnemyNum(1);
        }
    }
}
