using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class CheckImpact : MonoBehaviour
{
    [SerializeField]
    [Tooltip("����")]
    private GameObject pieceOfMeat;

    [SerializeField]
    [Tooltip("Docking�̎��ʗp")]
    private string objectName = "BodyParts";
    public string GetObjectName() { return objectName; }    //�Q�b�^�[

    [SerializeField]
    [Tooltip("�G��|�����ۂ̓��_")]
    private int scoreNum = 10;

    /// <summary>
    /// �Ռ����󂯂��ʒu�ɓ��Ђ𐶐�
    /// </summary>
    public void GeneratePieceOfMeat()
    {
        // �_���[�W���𗬂�
        transform.parent.GetComponent<AudioSource>().Play();

        for (int i = 0; i < 7; i++)
        {
            Instantiate(pieceOfMeat, transform.position, Quaternion.identity, transform.parent);
        }
    }

    /// <summary>
    /// �g�̂̃p�[�c�������Ռ����󂯂�����Ђɒu������
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // �����Ռ����󂯂��Ƃ�
        if (collision.impulse.magnitude > 40)
        {
            // �Ռ����󂯂��ʒu�ɓ��Ђ𐶐�
            GeneratePieceOfMeat();

            // �v���C���[
            if (transform.parent.CompareTag("Player"))
            {
                // �w��̕��ʂ��j�󂳂ꂽ��
                if (transform.CompareTag("Head") ||
                    transform.CompareTag("Chest") ||
                    transform.CompareTag("Waist"))
                {
                    // �Q�[���I�[�o�[
                    GameObject.FindWithTag("GameManager").GetComponent<RagdollDivingGameManager>().IsGameOver();
                }
            }
            // �G
            else if (transform.parent.CompareTag("Enemy"))
            {
                string objectName = GetComponent<CheckImpact>().GetObjectName();

                // �w��̕��ʂ��j�󂳂ꂽ��
                if (objectName == "Head" ||
                    objectName == "Chest" ||
                    objectName == "Waist")
                {
                    transform.parent.GetComponent<EnemyDestroy>().MyDestroy();
                }
            }

            // �Ռ����󂯂��̂̕��ʂ��폜
            Destroy(gameObject);

            //// �g�̃p�[�c�̐e�I�u�W�F�N�g
            //Transform human = transform.parent;
            //// �g�̃p�[�c�i����r�Ȃǂ̂��Ɓj
            //Transform parts = transform;
            //string partsName = BodyParts.None.ToString();

            //GameObject obj = new GameObject(partsName);
            //obj.transform.parent = human;

            //// Hierarchy�ł̏��Ԃ��擾
            //int siblingIndex = parts.transform.GetSiblingIndex();

            //// ���Ԃ����ւ���
            //obj.transform.SetSiblingIndex(siblingIndex);

            //// �Ռ����󂯂��̂̕��ʂ��폜
            //Destroy(parts.gameObject);
        }
    }
}
