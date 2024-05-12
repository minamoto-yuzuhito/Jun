using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ق��̃I�u�W�F�N�g�ɓ���������
/// </summary>
public class CheckBite : MonoBehaviour
{
    // �������W�i�����j
    private float toothInitialPosY;

    void Start()
    {
        // ���̏������W����
        toothInitialPosY = transform.position.y;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("��������!");

        // ���̎��ɓ���������
        if (other.CompareTag("Tooth"))
        {
            transform.DOKill();

            // �����������W�ɖ߂�
            transform.DOMoveY(toothInitialPosY, 1).
            SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�
        }
    }
}
