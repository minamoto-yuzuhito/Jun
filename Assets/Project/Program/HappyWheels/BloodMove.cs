using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�������x")]
    private float speed = -0.005f;

    // Update is called once per frame
    void Update()
    {
        // �t���[�����Ƃɓ����ŗ���������
        transform.Translate(0, speed, 0);
    }
}
