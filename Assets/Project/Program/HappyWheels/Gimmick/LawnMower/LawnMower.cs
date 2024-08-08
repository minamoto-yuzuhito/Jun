using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �Ŋ���@�̓���
/// </summary>
public class LawnMower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Ŋ���@���I�u�W�F�N�g���z�����ޑ��x")]
    private float speed;

    [SerializeField]
    [Tooltip("�Ŋ���@�̋z�����݌��I�u�W�F�N�g")]
    private GameObject lawnMowerStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �Ŋ���@�́u��v�Ɍ����������x�N�g��
        //Vector3 direction = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.down;
        //carvedList[i].transform.parent.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
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

            // �z�����݌��𐶐�
            GameObject startPoint = Instantiate(
                lawnMowerStartPoint, other.transform.position, Quaternion.identity, transform.parent);

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
