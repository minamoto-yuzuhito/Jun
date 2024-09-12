using UnityEngine;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;

/// <summary>
/// �󒆕��V�ړ�
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("RightHand")]
    private Rigidbody rightHand;
    
    [SerializeField]
    [Tooltip("LeftHand")]
    private Rigidbody leftHand;

    Rigidbody rb;

    private float hori;
    private float vert;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �ړ��̓���
    /// </summary>
    public void IsMoveInput()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
    }

    public void IsMove()
    {
        rb.velocity = new Vector3(hori, 0, vert) * 10;
    }

    // �͂�
    public void IsGrapple()
    {
        // ���N���b�N���ꂽ�u��
        if (Input.GetMouseButtonDown(0))
        {
            // ��������̏�ŌŒ�
            leftHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        
        // ���N���b�N�𗣂����Ƃ�
        else if (Input.GetMouseButtonUp(0))
        {
            // �ʒu Y �����Œ�
            leftHand.constraints = RigidbodyConstraints.FreezePositionY;
        }

        // �E�N���b�N���ꂽ�u��
        if (Input.GetMouseButtonDown(1))
        {
            // �E������̏�ŌŒ�
            rightHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        
        // �E�N���b�N�𗣂����Ƃ�
        else if (Input.GetMouseButtonUp(1))
        {
            // �ʒu Y �����Œ�
            rightHand.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    /// <summary>
    /// ��~
    /// </summary>
    public void IsStop()
    {
        // ���x
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // �p�x
        rb.rotation = Quaternion.identity;

        // ��]�A�ʒu�Ƃ��ɌŒ�
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}