using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �v���C���[�̗̑͂�0�ɂȂ����ۂɐ�������鏰�ƁA
/// �v���C���[�̐ڐG�𔻒肷��
/// </summary>
public class DeleteIfTouched : MonoBehaviour
{
    // �v���C���[�Ƃ����ڐG���Ȃ��悤�Ƀ��C���[�ݒ肳��Ă���
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
