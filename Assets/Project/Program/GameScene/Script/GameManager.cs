using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ToothController;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothController�N���X")]
    private ToothController toothController;

    [SerializeField]
    [Tooltip("Throwing�N���X")]
    private Throwing throwing;

    [SerializeField]
    [Tooltip("Countdown�N���X")]
    private Countdown countdown;

    // CameraController�N���X
    private CameraController cameraController;

    private ThrowingObjectSettings throwingObjectSettings;

    // ���˕��̐����J�E���g
    private int QueueSetCnt;
    public int GetQueueSetCnt() { return QueueSetCnt; }    // �Q�b�^�[

    // ������ő吔
    private int TotalQueue;

    // ��������
    private int ThrowCnt;
    public int GetThrowCnt() { return ThrowCnt; }   // �Q�b�^�[

    // true�̎��A�������点��
    private bool isPresentProblem;

    // true�̎��A�L�[���͂��󂯕t����
    private bool isKeyInput = true;

    // �L�[���͎�t����
    private float keyInputReceptionTime;

    // �J�E���g�_�E��
    private float countdownSeconds; // �^�C�}�[
    private bool isCountdown = false; // true�̂Ƃ��J�E���g�_�E�����s��

    // Start is called before the first frame update
    void Start()
    {
        throwingObjectSettings = GetComponent<ThrowingObjectSettings>();
        cameraController = GetComponent<CameraController>();

        // �����鎋�_�̃J�����ɐ؂�ւ���
        cameraController.SetThrowCamera();

        // ������ő吔��ݒ�
        TotalQueue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= throwingObjectSettings.GetThrowingObjects().Count; i++)
        {
            Debug.Log(i + "�F" + throwingObjectSettings.GetThrowingObjects()[i - 1]);
        }

        // �ǂ̎��Ɍ������ĕ��𓊂��邩�����߂�
        if (!isPresentProblem)
        {
            // �v���C���[�������ׂ��������点��
            toothController.ShiningTooth();

            // �w�莞�Ԍo�߂��邩�A�L�[���͂��s����܂Ō��点�鎕���Œ�
            isPresentProblem = true;

            // �J�E���g�_�E�����s���ۂ̕ϐ��̒l��ݒ�
            SetCountdownStatus();
        }

        // �J�E���g�_�E�����s���āA
        // �w�肳�ꂽ���ԃL�[���͂��ꂽ���𔻒肷��
        if (isCountdown)
        {
            // ���Ԃ��J�E���g
            countdownSeconds += Time.deltaTime;

            // ������ꏊ��I�΂��Ɏw�莞�Ԍo�߂������A
            // �I�΂Ȃ�����������L���[�ɒǉ�����
            if (countdownSeconds >= keyInputReceptionTime)
            {
                // �I�΂Ȃ�����������L���[�ɒǉ�
                throwingObjectSettings.GetThrowingObjects().Add(ToothPosition.Empty);

                NextTurn();
            }
            else
            {
                // �J�E���g�_�E��UI��`��
                countdown.IsCountdown(keyInputReceptionTime);
            }
        }

        // �L�[���͂��󂯕t���āA�ǂ̎��ɓ����邩�����߂�
        if (isKeyInput)
        {
            throwingObjectSettings.SetThrowingObject();
        }
    }

    /// <summary>
    /// �J�E���g�_�E�����s���ۂ̕ϐ��̒l��ݒ�
    /// </summary>
    private void SetCountdownStatus()
    {
        // �J�E���g�_�E�����s��
        isCountdown = true;

        // �L�[���͎�t���Ԃ�ݒ�
        keyInputReceptionTime = 2.0f;

        // �J�E���g�_�E���^�C�}�[�����Z�b�g
        countdownSeconds = 0.0f;

        // ���[�^�[��\��
        countdown.IsViewMeter(true);
    }

    /// <summary>
    /// �^�[����i�߂�
    /// </summary>
    public void NextTurn()
    {
        // �J�E���g�_�E�����~
        isCountdown = false;

        // ���[�^�[���\��
        countdown.IsViewMeter(false);

        // ���˕��̐����J�E���g
        QueueSetCnt++;

        // �����镨��S�Č��ߏI�������
        if (QueueSetCnt >= TotalQueue)
        {
            // �L�[���͂��󂯕t���Ȃ�
            isKeyInput = false;

            // �J�E���g�_�E�����s��Ȃ�
            isCountdown = false;

            // ���˒��̎��_�ɐ؂�ւ���
            cameraController.SetToothCamera();

            // �S�Ă̎������点�Ȃ�����
            toothController.AllToothNotShining();

            // ���𓊂����锻��ɂ���
            toothController.SetIsThrowFlag(true);

            // �I�񂾏ꏊ�ɕ�����������i��������j
            StartCoroutine(ThrowBasedOnQueue());
        }
        else
        {
            // �Ăю������点��
            isPresentProblem = false;
        }
    }

    /// <summary>
    /// �L���[�ɕۑ�����Ă��镨�𓊂���
    /// </summary>
    /// <returns></returns>
    private IEnumerator ThrowBasedOnQueue()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            // �S�ē����I�������
            if (ThrowCnt >= TotalQueue)
            {
                // �L�[���͂��󂯕t����
                isKeyInput = true;

                // �����鎋�_�̃J�����ɐ؂�ւ���
                cameraController.SetThrowCamera();

                // �Ăю������点��
                isPresentProblem = false;

                QueueSetCnt = 0;
                ThrowCnt = 0;

                // �L���[���폜
                throwingObjectSettings.GetThrowingObjects().Clear();    // �v���C���[��������ꏊ
                toothController.GetShiningTooths().Clear();             // �񎦂��ꂽ�i���������j������ꏊ

                break;
            }

            if(toothController.GetIsThrowFlag())
            {
                // �������񐔂��J�E���g
                ThrowCnt++;

                toothController.SetIsThrowFlag(false);

                // ������ꏊ���ۑ����ꂽ�L���[����A
                // ���Ԃɒl�������o��
                ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt - 1];

                // ������ꏊ���I������Ă����Ƃ�
                if (target >= 0)
                {
                    // �L���[�ɓo�^�����ꏊ�ɕ��𓊂���
                    throwing.IsThrowingObject(target);
                }
                else
                {
                    Debug.Log("�����Ȃ�����");
                    toothController.SetIsThrowFlag(true);
                }
            }
        }
    }
}
