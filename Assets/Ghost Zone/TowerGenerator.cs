using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�V����Tower�I�u�W�F�N�g�̐����ʒu�iDangerZone�I�u�W�F�N�g���w��j")]
    private Transform newTowerPos;

    [SerializeField]
    [Tooltip("Tower�I�u�W�F�N�g��Prefab")]
    private GameObject towerPrefab;

    // RagdollDivingGameManager
    private RagdollDivingGameManager ragdollDivingGameManager;

    private bool isTowergenerate = false;

    private void Start()
    {
        // �Q�[���}�l�[�W���[���i�[
        ragdollDivingGameManager = GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // �����𐶐����Ă��Ȃ��Ƃ�
        if (!isTowergenerate)
        {
            // �l�ԃI�u�W�F�N�g���͈͓��ɓ������Ƃ�
            if (other.transform.CompareTag("BodyParts"))
            {
                if (other.transform.parent.CompareTag("Chest"))
                {
                    // �v���C���[�̂Ƃ�
                    if (other.transform.parent.parent.CompareTag("Player"))
                    {
                        // ���݂̊K�w���J�E���g
                        ragdollDivingGameManager.SetClearRoomText();

                        // �V���������𐶐�
                        Instantiate(towerPrefab, newTowerPos.position, Quaternion.identity);
                        isTowergenerate = true;
                    }
                }
            }
        }
    }
}
