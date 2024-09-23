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
            for (int i = 0; i < 7; i++)
            {
                Instantiate(pieceOfMeat, transform.position, Quaternion.identity);
            }

            // �g�̃p�[�c�̐e�I�u�W�F�N�g
            Transform human = transform.parent;
            // �g�̃p�[�c�i����r�Ȃǂ̂��Ɓj
            Transform parts = transform;
            string partsName = BodyParts.None.ToString();

            GameObject obj = new GameObject(partsName);
            obj.transform.parent = human;

            // Hierarchy�ł̏��Ԃ��擾
            int siblingIndex = parts.transform.GetSiblingIndex();

            // ���Ԃ����ւ���
            obj.transform.SetSiblingIndex(siblingIndex);

            // �Ռ����󂯂��̂̕��ʂ��폜
            Destroy(parts.gameObject);
        }
    }
}
