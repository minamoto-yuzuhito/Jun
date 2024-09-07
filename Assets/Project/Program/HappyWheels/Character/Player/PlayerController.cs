using UnityEngine;
using System.Collections;
using Cinemachine;

/// <summary>
/// �󒆕��V�ړ�
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("CinemachineVirtualCamera")]
    private CinemachineVirtualCamera suctionVirtualCamera;

    private const float G = 9.9f;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    public void IsMove()
    {
        // �J�����������낵���_�ɐݒ�
        suctionVirtualCamera.enabled = false;

        // �ʒuY�����Œ�
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //--- �ړ� ---//
        //var velocity = new Vector3(0, 0, 0);
        //velocity.x += Input.GetAxis("Horizontal");
        //velocity.z += Input.GetAxis("Vertical");
        //rb.velocity = velocity * 500 * Time.deltaTime;

        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(hori, 0, vert) * 10;

        //--- �ړ������ɏ����X���� ---//
        var zEular = 0.0f;
        if (rb.velocity.x > 0)
        {
            zEular = -5.0f;
        }
        else if (rb.velocity.x < 0)
        {
            zEular = 5.0f;
        }

        var xEular = 0.0f;
        if (rb.velocity.z > 0)
        {
            xEular = 5.0f;
        }
        else if (rb.velocity.z < 0)
        {
            xEular = -5.0f;
        }
        var eular = new Vector3(xEular, 0, zEular);
        //rb.rotation = Quaternion.Euler(eular);
    }

    /// <summary>
    /// ��~
    /// </summary>
    public void IsStop()
    {
        // �����猩��
        suctionVirtualCamera.enabled = true;

        // ���x
        var velocity = new Vector3(0, 0, 0);
        rb.velocity = velocity * Time.deltaTime;

        // �p�x
        rb.rotation = Quaternion.identity;

        // ��]�A�ʒu�Ƃ��ɌŒ�
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}