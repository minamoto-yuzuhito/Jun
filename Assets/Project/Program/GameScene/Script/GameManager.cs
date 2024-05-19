using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothController�N���X")]
    public ToothController toothController;

    [SerializeField]
    [Tooltip("Throwing�N���X")]
    public Throwing throwing;

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

    // Start is called before the first frame update
    void Start()
    {
        throwingObjectSettings = GetComponent<ThrowingObjectSettings>();

        // ������ő吔��ݒ�
        TotalQueue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(QueueSetCnt);

        // �ǂ̎��Ɍ������ĕ��𓊂��邩�����߂�
        if (!isPresentProblem)
        {
            // �v���C���[�������ׂ��L�[��񎦂���
            toothController.ToothShining();

            // �w�莞�Ԍo�߂��邩�A�L�[���͂��s����܂Ŏ������点�Ȃ�
            isPresentProblem = true;

            // ������ꏊ��I�΂��Ɏw�莞�Ԍo�߂������A
            // �I�΂Ȃ�����������L���[�ɒǉ�����
            Invoke("AfterNotSelect", 2);
        }

        // �L�[���͂��󂯕t���āA�ǂ̎��ɓ����邩�����߂�
        if (isKeyInput)
        {
            throwingObjectSettings.SetThrowingObject();
        }
    }

    /// <summary>
    /// ������ꏊ��I�񂾌�̏���
    /// </summary>
    public void AfterSelect()
    {
        // �L�[�������ꂽ�̂�Invoke���~
        CancelInvoke("AfterNotSelect");

        NextTurn();
    }

    /// <summary>
    /// ������ꏊ��I�΂Ȃ�������̏���
    /// </summary>
    private void AfterNotSelect()
    {
        // �I�΂Ȃ�����������L���[�ɒǉ�
        throwingObjectSettings.GetThrowingObjects().Add(ToothPosition.Empty);

        NextTurn();
    }

    /// <summary>
    /// ������ꏊ��I�񂾌�̏���
    /// </summary>
    private void NextTurn()
    {
        // ���˕��̐����J�E���g
        QueueSetCnt++;

        // �����镨��S�Č��ߏI�������
        if (QueueSetCnt >= TotalQueue)
        {
            // �L�[���͂��󂯕t���Ȃ�
            isKeyInput = false;

            // �������点�Ȃ�����
            toothController.AllToothNotShining();

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
    /// �L���[�Ɋ�Â��ĕ��𓊂���
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
                // �Ăю������点��
                isPresentProblem = false;

                // �L�[���͂��󂯕t����
                isKeyInput = true;

                QueueSetCnt = 0;
                ThrowCnt = 0;

                // �L���[���폜
                List<ToothPosition> throwingObjects = throwingObjectSettings.GetThrowingObjects();
                throwingObjects.Clear();

                break;
            }

            // �������񐔂��J�E���g
            ThrowCnt++;

            // ������ꏊ���ۑ����ꂽ�L���[����A
            // ���Ԃɒl�������o��
            ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt - 1];

            // ������ꏊ���I������Ă����Ƃ�
            if(target > 0)
            {
                // �L���[�ɓo�^�����ꏊ�ɕ��𓊂���
                throwing.IsThrowingObject(target);
            }
            else
            {
                Debug.Log("�����Ȃ�����");
            }
        }
    }
}
