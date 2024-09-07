using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CheckDamage;

/// <summary>
/// �Ŋ���@���I�u�W�F�N�g��j�󂷂鏈��
/// </summary>
public class DestructionByLawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Destroy���鎞�Ԃ��w�肷��")]
    private float time = 5.0f;

    /// <summary>
    /// �I�u�W�F�N�g�����蔲�����Ƃ�
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // �L�����N�^�[
        if (other.gameObject.CompareTag("BodyParts"))
        {
            // �g�̃p�[�c�̐e�I�u�W�F�N�g
            Transform human = other.transform.parent.parent;
            // �g�̃p�[�c�i����r�Ȃǂ̂��Ɓj
            Transform parts = other.transform.parent;
            string partsName = BodyParts.None.ToString();

            GameObject obj = new GameObject(partsName);
            obj.transform.parent = human;

            // Hierarchy�ł̏��Ԃ��擾
            int siblingIndex = parts.transform.GetSiblingIndex();

            // ���Ԃ����ւ���
            obj.transform.SetSiblingIndex(siblingIndex);

            // ���̕��ʑS�ẴI�u�W�F�N�g���폜
            // �w�莞�Ԍo�߂ō폜
            Destroy(parts.gameObject);
        }
        // �Ŋ���@�̉��ɘA��Ă����I�u�W�F�N�g
        else if (other.transform.CompareTag("PullBehindTheLawnMower"))
        {
            // �w�莞�Ԍo�߂ō폜
            Destroy(other.gameObject, time);
        }
    }
}
