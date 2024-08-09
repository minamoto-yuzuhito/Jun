using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�I�u�W�F�N�g")]
    private GameObject bullet;

    // ���˒��̎�true
    private bool isShot;

    /// <summary>
    /// �I�u�W�F�N�g�����蔲���Ă���Ƃ�
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        // �v���C���[
        if(other.CompareTag("Player"))
        {
            // �v���C���[�̕����Ɏ��g����]������
            transform.LookAt(other.transform);

            // ���˂��Ă��Ȃ��Ƃ�
            if (!isShot)
            {
                // �e�𐶐�
                Instantiate(bullet, transform.position, transform.localRotation);

                // ���˂�������
                isShot = true;

                // �w�莞�Ԍ�ɍĔ��ˉ\
                Invoke("Reload", 3);
            }
        }
    }

    /// <summary>
    /// �����[�h
    /// </summary>
    void Reload()
    {
        isShot = false;
    }
}
