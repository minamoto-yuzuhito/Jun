using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// ���̃X�N���v�g�͊e�g�̃p�[�c�ɃA�^�b�`����
/// </summary>
public class CheckDamage : MonoBehaviour
{
    public enum BodyParts
    {
        Head,           // ��
        Neck,           // ��
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
        RightFoot,      // �E�܂���
        LeftThigh,      // ��������
        LeftShin,       // ������
        LeftFoot,       // ���܂���
    }

    // ���̃X�N���v�g���A�^�b�`�����Q�[���I�u�W�F�N�g�Ɋւ������
    private BodyParts bodyPartsType;    // �g�̃p�[�c�̎��
    private GameObject parent;          // �e�I�u�W�F�N�g

    private void Start()
    {
        // �e�I�u�W�F�N�g���擾
        parent = transform.parent.gameObject;

        // �^�O�̕������enum�^�֕ϊ�
        bodyPartsType = (BodyParts)Enum.Parse(typeof(BodyParts), transform.tag);

        Debug.Log(bodyPartsType);
    }

    // Update is called once per frame
    void Update()
    {
        // �W���C���g�R���|�[�l���g���A�^�b�`����Ă��邩�𔻒�
        // �i�p�[�c���m���Ȃ����Ă��邩�𒲂ׂ�j
        // �Ȃ����Ă��Ȃ��Ƃ�
        if (!GetComponent<CharacterJoint>())
        {
            BodyParts bleedingLocation = BodyParts.Chest;

            switch (bodyPartsType)
            {
                // ���`��
                case BodyParts.Head: bleedingLocation = BodyParts.Neck; break;  // �y���z�񂩂�o��
                case BodyParts.Neck: break; // �y��z���ォ��o��

                // ���ɂ͌����炱�̃X�N���v�g���A�^�b�`����Ă��Ȃ��̂ŃX���[
                case BodyParts.Chest: break;

                // �E���`�E��
                case BodyParts.RightShoulder: break;    // �y�E���z���E����o��
                case BodyParts.RightArm: bleedingLocation = BodyParts.RightShoulder; break; // �y�E�r�z�E������o��
                case BodyParts.RightHand: bleedingLocation = BodyParts.RightArm; break;     // �y�E��z�E�r����o��

                // �����`����
                case BodyParts.LeftShoulder: break; // �y�����z��������o��
                case BodyParts.LeftArm: bleedingLocation = BodyParts.LeftShoulder; break;   // �y���r�z��������o��
                case BodyParts.LeftHand: bleedingLocation = BodyParts.LeftArm; break;       // �y����z���r����o��

                // ��
                case BodyParts.Waist: break;    // �y���z��������o��

                // �E�������`�E�ܐ�
                case BodyParts.RightThigh: break;   // �y�E�������z���E������o��
                case BodyParts.RightShin: bleedingLocation = BodyParts.RightThigh; break;   // �y�E���ˁz�E����������o��
                case BodyParts.RightFoot: bleedingLocation = BodyParts.RightShin; break;    // �y�E�ܐ�z�E���˂���o��

                // ���������`���ܐ�
                case BodyParts.LeftThigh: break;    // �y���������z����������o��
                case BodyParts.LeftShin: bleedingLocation = BodyParts.LeftThigh; break;     // �y�����ˁz������������o��
                case BodyParts.LeftFoot: bleedingLocation = BodyParts.LeftShin; break;      // �y���ܐ�z�����˂���o��
            }

            if(bleedingLocation != BodyParts.Chest)
            {
                SetBleedingLocation(bleedingLocation);
            }
        }
    }

    /// <summary>
    /// �o���ꏊ��ݒ�
    /// </summary>
    /// <param name="BodyParts"></param>
    private void SetBleedingLocation(BodyParts BodyParts)
    {
        // �o���ꏊ�̃Q�[���I�u�W�F�N�g���擾
        GameObject bleedingLocation = parent.transform.GetChild((int)BodyParts).gameObject;

        bleedingLocation.transform.GetChild(0).GetComponent<BloodLost>().enabled = true;
    }
}
