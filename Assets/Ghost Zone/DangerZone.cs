using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���삷��I�u�W�F�N�g")]
    private GameObject controlObject;

    [SerializeField]
    [Tooltip("�T�C�Y")]
    private GameObject size;

    [SerializeField]
    [Tooltip("true�F�V��")]
    private bool isCeiling = false;

    [SerializeField]
    [Tooltip("�T�C�Y�ύX�ɂ����鎞��")]
    private float scaleTime = 1.0f;

    private void Start()
    {
        if(isCeiling)
        {
            size = GameObject.FindWithTag("RoomSize");

            Invoke("BootDangerZone", 5.0f);
        }
    }

    private void BootDangerZone()
    {
        controlObject.transform.DOScaleY(size.transform.localScale.y, scaleTime).
            SetEase(Ease.Linear);   // �C�[�W���O�ݒ�
    }

    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (!isCeiling)
        {
            // �T�C�Y�ύX
            BootDangerZone();
        }
    }
}