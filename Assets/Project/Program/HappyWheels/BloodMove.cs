using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����΂��ۂ̂Ԃ�̍ő�l")]
    private Vector3 bloodMoveShaking = new Vector3(2.0f, 2.0f, 2.0f);

    [SerializeField]
    [Tooltip("���x")]
    private float speed;

    [SerializeField]
    [Tooltip("Destroy���鎞�Ԃ��w�肷��")]
    private float time = 2;

    // Update is called once per frame
    void Start()
    {
        // �g�̂̃p�[�c�������Ă���������A�����x�N�g���ɕϊ�
        Vector3 direction = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward;

        // ���ݎ����̃~���b�ŃV�[�h�l��������
        Random.InitState(DateTime.Now.Millisecond);

        // ���˕������������炷
        direction.x += Random.Range(0.0f, bloodMoveShaking.x);
        direction.y += Random.Range(0.0f, bloodMoveShaking.y);
        direction.z += Random.Range(0.0f, bloodMoveShaking.z);

        // �����΂�
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

        // �w�莞�Ԍo�߂Ō����폜
        Destroy(gameObject, time);
    }
}
