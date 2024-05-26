using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JunAnimation : MonoBehaviour
{
    private Vector3 junInitialPos;
    private Vector3 junInitialRot;

    // �������̃A�j���[�V����
    public float animationPlayTimeSuccess = 0.2f;   // �A�j���[�V�����̍Đ�����
    public float animationPosXSuccess = -10f;       // �J�n���̍��W
    public float animationInitPosXSuccess = -30f;   // �I�����̍��W

    // ���s���̃A�j���[�V����
    public float animationPlayTimeMiss = 0.6f;   // �A�j���[�V�����̍Đ�����
    public float animationInitPosYMiss = -5f;   // �I�����̍��W

    private ToothController toothController;

    private void Start()
    {
        toothController = transform.GetChild(0).GetComponent<ToothController>();

        junInitialPos.x = transform.position.x;
        junInitialPos.y = transform.position.y;
        junInitialPos.z = transform.position.z;

        junInitialRot.x = transform.root.rotation.x;
        junInitialRot.y = transform.root.rotation.y;
        junInitialRot.z = transform.root.rotation.z;
    }

    /// <summary>
    /// ����
    /// </summary>
    public void Success()
    {
        Vector3 rotate = Vector3.zero;
        rotate.x = transform.root.rotation.x;
        rotate.y = transform.root.rotation.y;
        rotate.z = transform.root.rotation.z;

        rotate.x = animationPosXSuccess;
        transform.DORotate(rotate, 0, RotateMode.WorldAxisAdd);  //���[���h���ɑ΂���

        
        rotate.x = animationInitPosXSuccess;
        transform.DORotate(rotate, animationPlayTimeSuccess, RotateMode.WorldAxisAdd)   //���[���h���ɑ΂���
            .SetLoops(-1, LoopType.Yoyo);

        // �w��b��ɃA�j���[�V�������~����
        Invoke("StopAnimation", animationPlayTimeSuccess * 6);
    }

    /// <summary>
    /// ���s
    /// </summary>
    public void Miss()
    {
        transform.DOMoveY(animationInitPosYMiss, animationPlayTimeMiss).
            SetEase(Ease.OutQuart).
            SetLoops(-1, LoopType.Yoyo);

        // �w��b��ɃA�j���[�V�������~����
        Invoke("StopAnimation", animationPlayTimeMiss * 2);
    }

    private void StopAnimation()
    {
        transform.DOKill();

        transform.position = junInitialPos;
        transform.eulerAngles = junInitialRot;

        // �A�j���[�V�������I����������
        toothController.SetIsThrowFlag(true);
    }
}
