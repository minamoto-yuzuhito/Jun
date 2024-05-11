using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �㉺�̎��𓮂����āA���ޓ�������s����
/// </summary>
public class BiteWithTeeth : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��̎�")]
    public GameObject upperTooth;

    [SerializeField]
    [Tooltip("���̎�")]
    public GameObject lowerTooth;

    [SerializeField]
    [Tooltip("������鑬�x")]
    public float mouthCloseSpeed = 0.5f;

    [SerializeField]
    [Tooltip("�����J�����x")]
    public float mouthOpenSpeed = 1.0f;

    // �������W�i�����j
    private float upperToothInitialPosY;
    private float lowerToothInitialPosY;

    // Start is called before the first frame update
    void Start()
    {
        // �㉺�̎��̏������W����
        upperToothInitialPosY = upperTooth.transform.position.y;    // ��̎�
        lowerToothInitialPosY = lowerTooth.transform.position.y;    // ���̎�
    }

    /// <summary>
    /// ���ޓ�������s
    /// </summary>
    public void IsBite()
    {
        // ���������Ă���Ƃ��͊��܂Ȃ�
        if(upperToothInitialPosY != upperTooth.transform.position.y ||
            lowerToothInitialPosY != lowerTooth.transform.position.y)
        {
            return;
        }

        // ��̎������Ɉړ�
        upperTooth.transform.DOMoveY(lowerToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�

        // ���̎�����Ɉړ�
        lowerTooth.transform.DOMoveY(upperToothInitialPosY, mouthCloseSpeed).
        SetEase(Ease.InOutQuart);   // �C�[�W���O�ݒ�
    }
}