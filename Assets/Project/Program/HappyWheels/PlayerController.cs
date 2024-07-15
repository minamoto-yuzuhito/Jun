using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ���ǉ��i�X�p�C�_�[�t�b�N�j
    private enum State
    {
        Normal,
        ThrowingHook,
        FlyingPlayer
    }

    public GameObject FPSCamera;

    // ���ǉ��i�X�p�C�_�[�t�b�N�j
    public float hookRange = 100f;
    public Transform hookTargetMark;
    public Transform hookShot;
    private Vector3 hookPoint;
    private float hookShotSize;
    private State state;

    private void Start()
    {
        // ���ǉ��i�X�p�C�_�[�t�b�N�j
        state = State.Normal;
        hookShot.gameObject.SetActive(false);
        hookTargetMark.gameObject.SetActive(false);
    }

    private void Update()
    {
        // �����ǁ��ǉ��i�X�p�C�_�[�t�b�N�j
        // �i�e�N�j�b�N�j
        // enum��switch����g�ݍ��킹�邱�ƂŁA�w���̏�ԁi���[�h�j�̎��́A���̃��\�b�h�����s����x�Ƃ����d�g�݂�����B
        switch (state)
        {
            default:
            case State.Normal: // �m�[�}�����[�h�̎�
                HookStart();
                break;

            case State.ThrowingHook: // �t�b�N�������[�h�̎�
                HookThrow();
                break;

            case State.FlyingPlayer: // �v���[���[���󒆈ړ��̎�
                HookFlyingMovement();
                break;
        }
    }

    // ���ǉ��i�X�p�C�_�[�t�b�N�j
    void HookStart()
    {
        // �}�E�X�̉E�{�^���𐄂�����
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, hookRange))
            {
                // Ray�œ��肵���ʒu�Ƀ^�[�Q�b�g�}�[�N(�ڈ�j���ړ�������B
                hookTargetMark.position = hit.point;
                hookPoint = hit.point;

                state = State.ThrowingHook;
                hookShotSize = 0f;

                hookTargetMark.gameObject.SetActive(true);
                hookShot.gameObject.SetActive(true);
            }
        }
    }

    // ���ǉ��i�X�p�C�_�[�t�b�N�j
    void HookFlyingMovement()
    {
        Vector3 moveDir = (hookPoint - transform.position).normalized;

        // �i�e�N�j�b�N�j
        // ���ݒn�ƖړI�n�̋����������قǈړ����x�������i�߂��Ȃ�ɂ�Č����j
        float flyingSpeed = Vector3.Distance(transform.position, hookPoint) * 2f;

        transform.position += moveDir * flyingSpeed * Time.deltaTime;

        // �E�N���b�N�ŃX�p�C�_�[�t�b�N�̉���
        if (Input.GetMouseButtonDown(1))
        {
            // �m�[�}�����[�h�Ɉڍs����
            state = State.Normal;
            hookTargetMark.gameObject.SetActive(false);
            hookShot.gameObject.SetActive(false);
        }

        // �ڕW�n�_�̋߂��܂ŗ���ƃt�b�N�V���b�g�������I�ɉB��
        if (Vector3.Distance(transform.position, hookPoint) < 2f)
        {
            hookShot.gameObject.SetActive(false);
        }
    }

    // ���ǉ��i�X�p�C�_�[�t�b�N�j
    void HookThrow()
    {
        hookShot.LookAt(hookPoint);

        float hookShotSpeed = 50f;
        hookShotSize += hookShotSpeed * Time.deltaTime;
        hookShot.localScale = new Vector3(1, 1, hookShotSize);

        if (hookShotSize >= Vector3.Distance(transform.position, hookPoint))
        {
            // �󒆈ړ����[�h�Ɉڍs�i�󒆈ړ����J�n����j
            state = State.FlyingPlayer;
        }
    }
}