using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        // �l�ԃI�u�W�F�N�g���͈͓�����o���Ƃ�
        if (other.transform.CompareTag("BodyParts"))
        {
            // ���̉ӏ������������Ƃ�
            if (other.transform.parent.CompareTag("Chest"))
            {
                // �v���C���[�̂Ƃ�
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    // �^���[���폜
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
