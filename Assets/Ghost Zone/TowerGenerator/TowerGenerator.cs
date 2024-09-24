using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

/// <summary>
/// �������N���X
/// </summary>
public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tower�I�u�W�F�N�gPrefab")]
    private GameObject towerPrefab;

    [SerializeField]
    [Tooltip("�V����Tower�I�u�W�F�N�g�̐����ʒu�iDangerZone�I�u�W�F�N�g���w��j")]
    private Transform towerGeneratePos;

    // RagdollDivingGameManager
    private RagdollDivingGameManager ragdollDivingGameManager;

    private bool isTowergenerate = false;

    private void Start()
    {
        // �Q�[���}�l�[�W���[���i�[
        ragdollDivingGameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // ��Q���𐶐�
        GetComponent<ObstaclesGenerator>().GenerateObstacles();
    }

    void OnTriggerEnter(Collider other)
    {
        // �l�ԃI�u�W�F�N�g���͈͓��ɓ������Ƃ�
        if (other.transform.CompareTag("BodyParts"))
        {
            if (other.transform.parent.CompareTag("Chest"))
            {
                // �v���C���[�̂Ƃ�
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    // ���𐶐�
                    GenerateTower();

                    // �G�𐶐�
                    GetComponent<EnemyGenerator>().GenerateEnemy();
                }
            }
        }
    }

    /// <summary>
    /// ���𐶐�
    /// </summary>
    void GenerateTower()
    {
        // �����𐶐����Ă��Ȃ��Ƃ�
        if (!isTowergenerate)
        {
            // ���݂̊K�w���J�E���g
            ragdollDivingGameManager.SetClearRoomText();

            // �V���������𐶐�
            Instantiate(towerPrefab, towerGeneratePos.position, Quaternion.identity);
            isTowergenerate = true;
        }
    }
}
