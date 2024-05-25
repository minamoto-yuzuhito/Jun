using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ق��̃I�u�W�F�N�g�ɓ���������
/// </summary>
public class CheckBite : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // ���̎��ɓ���������
        if (other.CompareTag("Tooth"))
        {
            // �����������W�ɖ߂�
            transform.parent.gameObject.GetComponent<BiteWithTeeth>().IsMouthOpen();
        }

        // ���˕��ɓ���������
        if (other.CompareTag("ThrowingObject"))
        {
            // ���˕����폜
            Destroy(other.gameObject);
        }
    }
}
