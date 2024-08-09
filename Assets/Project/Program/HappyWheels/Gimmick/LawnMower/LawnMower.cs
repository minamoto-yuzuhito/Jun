using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ToothController;

/// <summary>
/// �Ŋ���@�̓���
/// </summary>
public class LawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Ŋ���@�̉��ɘA��Ă����I�u�W�F�N�g")]
    private GameObject pullBehindTheLawnMower;

    [SerializeField]
    [Tooltip("SuctionArea")]
    private GameObject suctionArea;

    // �J�E���g�_�E��
    [SerializeField]
    [Tooltip("�z�����݃G���A�����̃C���^�[�o��")]
    private float intervalOfCreateSuctionArea = 1.0f;
    private float coolTimeSeconds; // �^�C�}�[�v���p
    private bool isCoolTime = false; // true�̂Ƃ��J�E���g�_�E�����s��

    // ���������z�����݃G���A���i�[
    private List<GameObject> suctionAreas = new List<GameObject>();

    /// <summary>
    /// �Ŋ���@�Ɍ������Ă���z�����݃G���A�𐶐�
    /// </summary>
    public bool IsCreateSuctionArea()
    {
        // �N���b�N���Ă��邩�̔���
        bool isClick = false;

        // ���N���b�N��
        if (Input.GetMouseButton(0))
        {
            // �N���b�N���Ă��锻��
            isClick = true;

            // �N�[���^�C�����ł͂Ȃ��Ƃ�
            if (!isCoolTime)
            {
                // �z�����݃G���A����
                Vector3 pos = transform.position;
                pos.y -= 5.0f;
                suctionAreas.Add(Instantiate(suctionArea, pos, Quaternion.identity));   // �i�[

                // �N�[���^�C���˓�
                isCoolTime = true;
            }
        }
        // �������Ƃ�
        else
        {
            // �N�[���^�C������
            coolTimeSeconds = 0.0f;
            isCoolTime = false;

            // ���������������[�v
            for (int i = 0; i < suctionAreas.Count; i++)
            {
                Destroy(suctionAreas[i]);
            }
        }

        // �N�[���^�C����
        if (isCoolTime)
        {
            // ���Ԃ��J�E���g
            coolTimeSeconds += Time.deltaTime;

            // �w�莞�Ԍo�߂�����
            if (coolTimeSeconds >= intervalOfCreateSuctionArea)
            {
                // �N�[���^�C������
                coolTimeSeconds = 0.0f;
                isCoolTime = false;
            }
        }

        // �N���b�N���Ă��邩�̔����Ԃ�
        return isClick;
    }

    /// <summary>
    /// �I�u�W�F�N�g�����蔲�����Ƃ�
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // �L�����N�^�[�̎�
        if (other.gameObject.CompareTag("BodyParts"))
        {
            Debug.Log("���蔲�����I");

            // �Ŋ���@�̉��ɘA��Ă����I�u�W�F�N�g�𐶐�
            GameObject startPoint = Instantiate(
                pullBehindTheLawnMower, other.transform.position, Quaternion.identity, transform.parent);

            // FixedJoint�R���|�[�l���g���A�^�b�`����Ă��Ȃ��Ƃ�
            if (other.transform.parent.GetComponent<FixedJoint>() == null)
            {
                // �G��Ă����I�u�W�F�N�g�ɃW���C���g���A�^�b�`
                other.transform.parent.AddComponent<FixedJoint>();
            }
            
            // �W���C���g��ڑ�
            other.transform.parent.GetComponent<FixedJoint>().connectedBody = startPoint.GetComponent<Rigidbody>();
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g���ʂ蔲�����Ƃ�
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        Debug.Log("�ʂ蔲���I����");
    }

    /// <summary>
    /// �I�u�W�F�N�g�����蔲���Ă���Ƃ�
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BodyParts"))
        {
            Debug.Log("���蔲���Ă���I");
        }
    }
}
