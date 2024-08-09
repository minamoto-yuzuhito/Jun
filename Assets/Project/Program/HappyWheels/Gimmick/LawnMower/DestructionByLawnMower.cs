using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            // ���̕��ʑS�ẴI�u�W�F�N�g���폜
            // �w�莞�Ԍo�߂ō폜
            Destroy(other.gameObject.transform.parent.gameObject, time);
        }
        // �Ŋ���@�̉��ɘA��Ă����I�u�W�F�N�g
        else if (other.gameObject.CompareTag("PullBehindTheLawnMower"))
        {
            // �w�莞�Ԍo�߂ō폜
            Destroy(other.gameObject, time);
        }
    }
}
