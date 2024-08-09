using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PullBehindTheLawnMower;

public class Suction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����܂ł̎���")]
    private float time = 3.0f;

    [SerializeField]
    [Tooltip("�k����̒l")]
    private Vector3 afterScale = new Vector3(0.1f, 0.1f, 0.1f);

    // �ړI�n
    private GameObject endPoint;

    // Start is called before the first frame update
    void Start()
    {
        // �Ŋ���@�̋z�����݌��I�u�W�F�N�g���擾
        endPoint = GameObject.FindWithTag("InhaleZone");

        // �Ŋ���@�̋z�����݌��Ɍ�������
        transform.DOMove(endPoint.transform.position, time);    // ���X�ɋ߂Â�

        transform.DOScale(afterScale, time).                    // ���X�ɏk������
            OnComplete(() => Destroy(gameObject));              // ������A���̃I�u�W�F�N�g���폜
    }
}
