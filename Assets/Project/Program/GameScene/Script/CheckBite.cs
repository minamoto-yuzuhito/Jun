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
        Debug.Log("��������!");

        // ���̎��ɓ���������
        if (other.CompareTag("Tooth"))
        {
            GameObject tooths = transform.parent.gameObject;

            // �㉺�̎����������W�ɖ߂�
            tooths.GetComponent<BiteWithTeeth>().SetInit();
        }
    }
}
