using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ScoreArea�ɐG�ꂽ�ۂ̓��_")]
    private int scoreNum = 5;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g���폜�����܂ł̎���")]
    private float lifeTime = 10.0f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
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
                    // �Q�[���}�l�[�W���[���擾
                    RagdollDivingGameManager ragdollDivingGameManager =
                        GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>();

                    // �X�R�A�����Z
                    ragdollDivingGameManager.SetScoreText(scoreNum);
                }
            }
        }
    }
}
