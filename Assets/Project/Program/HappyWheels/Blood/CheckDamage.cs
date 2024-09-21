using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static CheckDamage;
using Debug = UnityEngine.Debug;

/// <summary>
/// ���̃X�N���v�g�͊e�g�̃p�[�c�ɃA�^�b�`����
/// </summary>
public class CheckDamage : MonoBehaviour
{
    public enum BodyParts
    {
        Head,           // ��
        Chest,          // ��
        RightShoulder,  // �E��
        RightArm,       // �E�r
        RightHand,      // �E��
        LeftShoulder,   // ����
        LeftArm,        // ���r
        LeftHand,       // ����
        Waist,          // ��
        RightThigh,     // �E������
        RightShin,      // �E����
        RightFoot,      // �E�ܐ�
        LeftThigh,      // ��������
        LeftShin,       // ������
        LeftFoot,       // ���ܐ�
        None,           // �����l
    }

    /// <summary>
    /// �o���ӏ�
    /// </summary>
    public enum BleedingLocation
    {
        // ��
        OnHead,             // ���ƌq�����Ă���
        OnRightShoulder,    // �E���ƌq�����Ă���
        OnLeftShoulder,     // �����ƌq�����Ă���
        OnWaist,            // ���ƌq�����Ă���

        // ��
        OnRightThigh = 1,   // �E�������ƌq�����Ă���
        OnLeftThigh,        // ���������ƌq�����Ă���

        // ����ȊO
        Myself = -1,        // ���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�Ɛڑ����Ă����ӏ�
        OppositeSide = 1,   // ���Α�
    }

    [SerializeField]
    [Tooltip("�A�����ďo�����镔��")]
    private GameObject linkageBleeding;

    private void Start()
    {
        //Debug.Log(bodyPartsType);
    }

    /// <summary>
    /// Joint���O�ꂽ�Ƃ�
    /// </summary>
    void OnJointBreak(float breakForce)
    {
        // �_���[�W���𗬂�
        //parent.GetComponent<AudioSource>().Play();

        // ���̃I�u�W�F�N�g����o��
        // �o���ӏ��̃Q�[���I�u�W�F�N�g���擾
        GameObject bleedingMySelf = transform.GetChild(0).gameObject;
        IsBloodLoss(bleedingMySelf);

        // ���̃I�u�W�F�N�g�̐ڑ���̃I�u�W�F�N�g����o��
        // �ڑ����Ă���g�̃p�[�c�����݂��Ă��Ȃ��Ƃ��͏o�����Ȃ�
        if (linkageBleeding.name != BodyParts.None.ToString())
        {
            IsBloodLoss(linkageBleeding);
        }
    }

    /// <summary>
    /// �o���������s��
    /// </summary>
    /// <param name="BleedingLocation"> �o���ӏ��I�u�W�F�N�g </param>
    private void IsBloodLoss(GameObject BleedingLocation)
    {
        // BloodLost�X�N���v�g���擾
        BloodLost bloodLost = BleedingLocation.GetComponent<BloodLost>();

        // �o������������Ă��Ȃ��Ƃ�
        if (bloodLost != null)
        {
            // �X�N���v�g��L���ɂ��ďo���������J�n����
            bloodLost.enabled = true;

            // �w�莞�Ԍo�߂ŏo�����~�߂�
            bloodLost.BloodLossStopAafter();
        }
    }
}
