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

    // ���̃X�N���v�g���A�^�b�`�����Q�[���I�u�W�F�N�g�Ɋւ������
    private BodyParts bodyPartsType;    // �g�̃p�[�c�̎��
    private GameObject parent;          // �e�I�u�W�F�N�g

    private void Start()
    {
        // ��ԏ�̐e�I�u�W�F�N�g���擾
        parent = transform.root.gameObject;

        // �^�O�̕������enum�^�֕ϊ�
        bodyPartsType = (BodyParts)Enum.Parse(typeof(BodyParts), transform.tag);

        //Debug.Log(bodyPartsType);
    }

    // <summary>
    // �w�肳�ꂽ�I�u�W�F�N�g����o������
    // </summary>
    // <param name = "BodyParts" ></ param >
    private void SetBleedingLocation(BodyParts BodyParts, BleedingLocation BleedingLocation)
    {
        // ���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�Ɛڑ����Ă����ӏ�����o��
        if(BleedingLocation == BleedingLocation.Myself)
        {
            // �o���ӏ��̃Q�[���I�u�W�F�N�g���擾
            GameObject bleedingLocation = transform.GetChild(0).gameObject;
            IsBloodLoss(bleedingLocation);
        }
        // �ڑ���̃I�u�W�F�N�g����o��
        else
        {
            // �o���ꏊ�̃Q�[���I�u�W�F�N�g���擾
            GameObject bleedingLocation = parent.transform.GetChild((int)BodyParts).gameObject;
            GameObject bleedingLocationParent = bleedingLocation.transform.GetChild((int)BleedingLocation).gameObject;
            IsBloodLoss(bleedingLocationParent);
        }
    }

    /// <summary>
    /// Joint���O�ꂽ�Ƃ�
    /// </summary>
    void OnJointBreak(float breakForce)
    {
        // ���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�Ɛڑ����Ă����ӏ�����o��
        SetBleedingLocation(BodyParts.None, BleedingLocation.Myself);

        // �ڑ���̃I�u�W�F�N�g����o��
        switch (bodyPartsType)
        {
            // �����O�ꂽ�Ƃ��A���ォ��o��
            case BodyParts.Head: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnHead); break;

            // ���ɂ͌����炱�̃X�N���v�g���A�^�b�`����Ă��Ȃ��̂ŃX���[
            case BodyParts.Chest: break;

            //--- �E���`�E�� ---//
            // �E�����O�ꂽ�Ƃ��A���E����o��
            case BodyParts.RightShoulder: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnRightShoulder); break;
            // �E�r���O�ꂽ�Ƃ��A�E������o��
            case BodyParts.RightArm: SetBleedingLocation(BodyParts.RightShoulder, BleedingLocation.OppositeSide); break;
            // �E�肪�O�ꂽ�Ƃ��A�E�r����o��
            case BodyParts.RightHand: SetBleedingLocation(BodyParts.RightArm, BleedingLocation.OppositeSide); break;

            //--- �����`���� ---//
            // �������O�ꂽ�Ƃ��A��������o��
            case BodyParts.LeftShoulder: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnLeftShoulder); break;
            // ���r���O�ꂽ�Ƃ��A��������o��
            case BodyParts.LeftArm: SetBleedingLocation(BodyParts.LeftShoulder, BleedingLocation.OppositeSide); break;
            // ���肪�O�ꂽ�Ƃ��A���r����o��
            case BodyParts.LeftHand: SetBleedingLocation(BodyParts.LeftArm, BleedingLocation.OppositeSide); break;

            // �����O�ꂽ�Ƃ��A��������o��
            case BodyParts.Waist: SetBleedingLocation(BodyParts.Chest, BleedingLocation.OnWaist); break;

            //--- �E�������`�E�ܐ� ---//
            // �E���������O�ꂽ�Ƃ��A���E����o��
            case BodyParts.RightThigh: SetBleedingLocation(BodyParts.Waist, BleedingLocation.OnRightThigh); break;
            // �E���˂��O�ꂽ�Ƃ��A�E����������o��
            case BodyParts.RightShin: SetBleedingLocation(BodyParts.RightThigh, BleedingLocation.OppositeSide); break;
            // �E�ܐ悪�O�ꂽ�Ƃ��A�E���˂���o��
            case BodyParts.RightFoot: SetBleedingLocation(BodyParts.RightShin, BleedingLocation.OppositeSide); break;

            //--- ���������`���ܐ� ---//
            // �����������O�ꂽ�Ƃ��A��������o��
            case BodyParts.LeftThigh: SetBleedingLocation(BodyParts.Waist, BleedingLocation.OnLeftThigh); break;
            // �����˂��O�ꂽ�Ƃ��A������������o��
            case BodyParts.LeftShin: SetBleedingLocation(BodyParts.LeftThigh, BleedingLocation.OppositeSide); break;
            // ���ܐ悪�O�ꂽ�Ƃ��A�����˂���o��
            case BodyParts.LeftFoot: SetBleedingLocation(BodyParts.LeftShin, BleedingLocation.OppositeSide); break;
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
