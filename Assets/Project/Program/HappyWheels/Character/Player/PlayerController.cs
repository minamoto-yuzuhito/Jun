using UnityEngine;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using static UnityEngine.GridBrushBase;
using static ToothController;

/// <summary>
/// �󒆕��V�ړ�
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GrabPoint")]
    private GameObject grabPoint;

    [SerializeField]
    [Tooltip("RightHand")]
    private Rigidbody rightHand;
    
    [SerializeField]
    [Tooltip("LeftHand")]
    private Rigidbody leftHand;

    // �ړ�����I�u�W�F�N�g��Rigidbody
    Rigidbody rb;

    // �������x��Ԃ�
    public float GetVelocityY() { return rb.velocity.y; }

    private float hori;
    private float vert;

    private float directionHori = 1.0f;
    public void InversionDirectionHori(float Value) { directionHori = Value; }
    private float directionVert = 1.0f;
    public void InversionDirectionVert(float Value) { directionVert = Value; }

    private GameObject grabPointObject;

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
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = hori * 10 * directionHori;
        newVelocity.z = vert * 10 * directionVert;

        // ���x����
        if(rb.velocity.y < -50.0f)
        {
            newVelocity.y = -50.0f;
        }

        rb.velocity = newVelocity;
    }

    // �͂�
    public void IsGrapple()
    {
        // ���N���b�N���ꂽ�u��
        if (Input.GetMouseButtonDown(0))
        {
            // ��������̏�ŌŒ�
            //leftHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            IsRotation(leftHand.gameObject);
        }
        
        // ���N���b�N�𗣂����Ƃ�
        else if (Input.GetMouseButtonUp(0))
        {
            if(grabPointObject != null)
            {
                // �e�q�֌W������
                leftHand.transform.parent.parent = null;

                // �폜
                Destroy(grabPointObject);
            }
        }

        // �E�N���b�N���ꂽ�u��
        if (Input.GetMouseButtonDown(1))
        {
            IsRotation(rightHand.gameObject);
        }
        
        // �E�N���b�N�𗣂����Ƃ�
        else if (Input.GetMouseButtonUp(1))
        {
            if (grabPointObject != null)
            {
                // �e�q�֌W������
                rightHand.transform.parent.parent = null;

                // �폜
                Destroy(grabPointObject);
            }
        }
    }

    void IsRotation(GameObject HandObject)
    {
        grabPointObject = Instantiate(grabPoint, HandObject.transform.position, Quaternion.identity);

        if(HandObject == leftHand.gameObject)
        {
            grabPointObject.GetComponent<Rotation>().IsRotateLeft();
        }
        else if (HandObject == rightHand.gameObject)
        {
            grabPointObject.GetComponent<Rotation>().IsRotateRight();
        }

        HandObject.transform.parent.parent = grabPointObject.transform;
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