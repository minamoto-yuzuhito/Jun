using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SoccerBal : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�T�b�J�[�{�[�����΂�����")]
    private Vector3 moveShaking = new Vector3(0.0f, 0.0f, -5.0f);

    [SerializeField]
    [Tooltip("�ő呬�x")]
    private Vector3 speedLimit = new Vector3(10.0f, 10.0f, 10.0f);

    [SerializeField]
    [Tooltip("���ˎ��ɕt�^���鑬�x")]
    private float reflectSpeed = 5.0f;

    [SerializeField]
    [Tooltip("���X�ɏグ�鑬�x�̔{��\n���݂̑��x / accelerationSpeed �𖈃t���[�����Z���Ă���")]
    private float accelerationSpeed = 50.0f;

    private Rigidbody ballRb;

    // ���C���I�u�W�F�N�g�ɓ��������ہA�擾�������
    private RaycastHit fastRayHitInfo;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();

        // ��΂�
        GetComponent<Rigidbody>().AddForce(moveShaking, ForceMode.Impulse);
    }

    private void Update()
    {
        // ���C�̔��˕���
        Vector3 velocity = ballRb.velocity;         // ���x�x�N�g��
        Vector3 direction = velocity.normalized;    // ���x�x�N�g���𐳋K������

        var radius = GetComponent<SphereCollider>().radius;

        var isHit = Physics.SphereCast(transform.position, radius, direction * 10, out fastRayHitInfo);
    }

    /// <summary>
    /// ���X�ɉ������Ă���
    /// </summary>
    public void Acceleration()
    {
        Vector3 ballVelocity = ballRb.velocity;

        // X�������ɉ���
        ballVelocity.x += ballVelocity.x / accelerationSpeed;
        // ��Βl�Ŕ�r
        if(Mathf.Abs( ballVelocity.x) > speedLimit.x)
        {
            // ���̐��̎�
            if(Mathf.Sign(ballVelocity.x) == -1)
            {
                ballVelocity.x = -speedLimit.x;
            }
            else
            {
                ballVelocity.x = speedLimit.x;
            }
        }

        // Z�������ɉ���
        ballVelocity.z += ballVelocity.z / accelerationSpeed;
        // ��Βl�Ŕ�r
        if (Mathf.Abs(ballVelocity.z) > speedLimit.z)
        {
            // ���̐��̎�
            if (Mathf.Sign(ballVelocity.z) == -1)
            {
                ballVelocity.z = -speedLimit.z;
            }
            else
            {
                ballVelocity.z = speedLimit.z;
            }
        }

        ballRb.velocity = ballVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ReflectObject"))
        {
            // ���˃x�N�g���i���x�j
            var inDirection = ballRb.velocity.normalized;

            // �@���x�N�g��
            var inNormal = fastRayHitInfo.normal;

            // ���˃x�N�g���i���x�j
            var result = Vector3.Reflect(inDirection, inNormal).normalized;

            // �o�E���h��̑��x���{�[���ɔ��f
            ballRb.velocity = result * reflectSpeed;
        }
    }
}
