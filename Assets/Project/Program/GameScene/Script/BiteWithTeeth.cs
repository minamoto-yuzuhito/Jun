using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

/// <summary>
/// �㉺�̎��𓮂����āA���ޓ�������s����
/// </summary>
public class BiteWithTeeth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��̎�")]
    private GameObject upperTooth;

    [SerializeField]
    [Tooltip("���̎�")]
    private GameObject lowerTooth;

    [SerializeField]
    [Tooltip("������鑬�x")]
    private float mouthCloseSpeed = 0.5f;

    [SerializeField]
    [Tooltip("�����J�����x")]
    private float mouthOpenSpeed = 1.0f;

    // �������W�i�����j
    private float upperToothInitialPosY;
    private float lowerToothInitialPosY;

    private ToothController toothController;

    // Start is called before the first frame update
    void Start()
    {
        toothController = transform.parent.gameObject.GetComponent<ToothController>();

        // �㉺�̎��̏������W����
        upperToothInitialPosY = upperTooth.transform.position.y;    // ��̎�
        lowerToothInitialPosY = lowerTooth.transform.position.y;    // ���̎�
    }

    /// <summary>
    /// �㉺�̎��������ʒu�ɂ���Ƃ�true��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool CheckMouthOpen()
    {
        if (upperToothInitialPosY == upperTooth.transform.position.y &&
            lowerToothInitialPosY == lowerTooth.transform.position.y)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// ���ޓ�������s
    /// </summary>
    public void IsBite()
    {
        // ��̎������Ɉړ�
        upperTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�

        // ���̎�����Ɉړ�
        lowerTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�
    }

    /// <summary>
    /// �����J������Ԃɂ���
    /// </summary>
    public void IsMouthOpen()
    {
        // IsBite�Ŏ��s����Ă�����̂��~
        upperTooth.transform.DOKill();
        lowerTooth.transform.DOKill();

        // ��̎��������ʒu�Ɉړ�
        upperTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�

        // ���̎��������ʒu�Ɉړ�
        lowerTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�

        // 
        StartCoroutine(ThrowBasedOnQueue());
    }

    private IEnumerator ThrowBasedOnQueue()
    {
        while (true)
        {
            // ���������ʒu�ɖ߂�����
            if (CheckMouthOpen())
            {
                // �������ꏊ�ɓ�����ꂽ���𔻒�
                // ���ʂɉ������A�j���[�V���������s
                toothController.CheckRightTheow();
                break;
            }

            yield return null;
        }
    }
}