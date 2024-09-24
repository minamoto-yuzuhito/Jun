using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

public class TowerGenerator : MonoBehaviour
{
    //--- �� ---//
    [SerializeField]
    [Tooltip("Tower�I�u�W�F�N�gPrefab")]
    private GameObject towerPrefab;
    [SerializeField]
    [Tooltip("�V����Tower�I�u�W�F�N�g�̐����ʒu�iDangerZone�I�u�W�F�N�g���w��j")]
    private Transform towerGeneratePos;

    //--- ��Q�� ---//
    [SerializeField]
    [Tooltip("��Q���I�u�W�F�N�gPrefab")]
    private GameObject obstaclesPrefab;
    [SerializeField]
    [Tooltip("��Q���̐����ʒu")]
    private GameObject obstaclesGeneratePos;
    [SerializeField]
    [Tooltip("��Q���̐e")]
    private GameObject obstaclesParentObject;

    //--- Enemy ---//
    [SerializeField]
    [Tooltip("�G�I�u�W�F�N�gPrefab")]
    private GameObject enemyPrefab;
    [SerializeField]
    [Tooltip("�G�̐����ʒu")]
    private GameObject enemyGeneratePos;

    // RagdollDivingGameManager
    private RagdollDivingGameManager ragdollDivingGameManager;

    private bool isTowergenerate = false;

    private void Start()
    {
        // �Q�[���}�l�[�W���[���i�[
        ragdollDivingGameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

        // ��Q���𐶐�
        GenerateObstacles();
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
                    GenerateEnemy();
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

    /// <summary>
    /// ��Q���𐶐�
    /// </summary>
    void GenerateObstacles()
    {
        // �w��̈ʒu�ɐ���
        GameObject obj = Instantiate(obstaclesPrefab, obstaclesGeneratePos.transform.position, Quaternion.identity);
        obj.transform.parent = obstaclesParentObject.transform;
    }

    /// <summary>
    /// �G�𐶐�
    /// </summary>
    void GenerateEnemy()
    {
        // �G�����݂��Ă��Ȃ��Ƃ�
        if(!GameObject.FindWithTag("Enemy"))
        {
            // �w��̈ʒu�ɐ���
            Instantiate(enemyPrefab, enemyGeneratePos.transform.position, Quaternion.identity);
        }
    }
}
