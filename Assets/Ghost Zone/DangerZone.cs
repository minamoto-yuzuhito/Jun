using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���삷��I�u�W�F�N�g")]
    private GameObject controlObject;

    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ꂽ");
        controlObject.transform.DOScaleY(transform.localScale.y, 1.0f).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�
    }
}