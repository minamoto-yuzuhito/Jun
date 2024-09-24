using System.Collections;
using System.Collections.Generic;
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
        // �G�����݂��Ă��Ȃ��Ƃ�
        if (!GameObject.FindWithTag("Enemy"))
        {
            // �w��̈ʒu�ɐ���
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);
        }
    }
}
