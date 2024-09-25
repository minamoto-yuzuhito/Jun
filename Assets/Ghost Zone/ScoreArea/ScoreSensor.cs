using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
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
                    // �Q�[���}�l�[�W���[���擾
                    RagdollDivingGameManager ragdollDivingGameManager =
                        GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

                    // ���݂̊K�w���J�E���g
                    ragdollDivingGameManager.SetScoreNumText();
                }
            }
        }
    }
}
