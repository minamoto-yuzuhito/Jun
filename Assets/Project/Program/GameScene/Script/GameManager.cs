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
    public void SetQueueSetCnt(int Value) { QueueSetCnt += Value; }    // �Z�b�^�[

    // ������ő吔
    private int TotalQueue;

    // ��������
    private int ThrowCnt;
    public int GetThrowCnt() { return ThrowCnt; }   // �Q�b�^�[

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
        // �ǂ��̎��Ɍ������ĕ��𓊂��邩�����߂Ă���
        // �ő吔�����Ă��Ȃ��Ƃ�
        if (QueueSetCnt != TotalQueue)
        {
            // �v���C���[�������ׂ��L�[��񎦂���
            toothController.PresentProblem();

            // �L�[���͂��󂯕t���āA�ǂ̎��ɓ����邩�����߂�
            throwingObjectSettings.SetThrowingObject();

            // �����镨��S�Č��ߏI�������
            if (QueueSetCnt >= TotalQueue)
            {
                // �������点�Ȃ�����
                toothController.AllToothNotShining();

                // �I�񂾏ꏊ�ɕ�����������i��������j
                StartCoroutine(ThrowBasedOnQueue());
            }
        }

        Debug.Log(QueueSetCnt);
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
                QueueSetCnt = 0;
                ThrowCnt = 0;

                // �L���[���폜
                List<ToothPosition> throwingObjects = throwingObjectSettings.GetThrowingObjects();
                throwingObjects.Clear();

                break;
            }

            ToothPosition target = throwingObjectSettings.GetThrowingObjects()[ThrowCnt];

            // �L���[�ɓo�^�����ꏊ�ɕ��𓊂���
            throwing.IsThrowingObject(target);

            // �������񐔂��J�E���g
            ThrowCnt++;
        }

        //allThrowCnt = 3;
    }
}
