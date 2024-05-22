using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����鎋�_�̃J����")]
    public Camera ThrowCamera;

    [SerializeField]
    [Tooltip("���̐��ʎ��_�̃J����")]
    public Camera ToothCamera;

    [SerializeField]
    [Tooltip("�T�u�J�����̃L�����o�X�O���[�v")]
    public CanvasGroup SubCamera;

    /// <summary>
    /// �����鎋�_�̃J�����ɐ؂�ւ���
    /// </summary>
    public void SetThrowCamera()
    {
        ThrowCamera.enabled = true;
        ToothCamera.enabled = false;
        SubCamera.alpha = 0.0f;
    }

    /// <summary>
    /// ���˒��̎��_�ɐ؂�ւ���
    /// </summary>
    public void SetToothCamera()
    {
        ThrowCamera.enabled = false;
        ToothCamera.enabled = true;
        SubCamera.alpha = 1.0f;
    }
}
