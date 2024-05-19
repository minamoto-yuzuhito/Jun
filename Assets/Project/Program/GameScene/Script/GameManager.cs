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

    // �L���[�ɓo�^������
    private int QueueSetCnt;
    public void SetQueueSetCnt(int Value) { QueueSetCnt += Value; }    // �Z�b�^�[

    // ������ő吔
    private int TotalQueue;

    // ��������
    private int ThrowCnt;

    // Start is called before the first frame update
    void Start()
    {
        TotalQueue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // �ǂ��̎��Ɍ������ĕ��𓊂��邩�����߂Ă���
        // �ő吔�����Ă��Ȃ��Ƃ�
        if(QueueSetCnt != TotalQueue)
        {
            // �v���C���[�������ׂ��L�[��񎦂���
            toothController.PresentProblem();

            // �����镨��S�Č��ߏI�������
            if (QueueSetCnt >= TotalQueue)
            {
                // �������点�Ȃ�����
                toothController.AllToothNotShining();

                // �I�񂾏ꏊ�ɕ�����������i��������j
                StartCoroutine(ThrowBasedOnQueue());

                QueueSetCnt = 0;
            }
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
            if (ThrowCnt >= TotalQueue) break;

            ToothPosition target = GetComponent<ThrowingObjectSettings>().GetThrowingObjects()[ThrowCnt];

            // �L���[�ɓo�^�����ꏊ�ɕ��𓊂���
            throwing.IsThrowingObject(target);

            // �������񐔂��J�E���g
            ThrowCnt++;
        }

        //allThrowCnt = 3;
    }
}
