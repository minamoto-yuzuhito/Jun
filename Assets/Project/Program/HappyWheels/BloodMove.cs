using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���x")]
    private float speed;

    // Destroy���鎞�Ԃ��w�肷��
    public float time = 2;

    // Update is called once per frame
    void Start()
    {
        // �������ꂽ����������ɔ�΂�
        GetComponent<Rigidbody>().AddForce(transform.up * speed, ForceMode.Impulse);

        // �w�莞�Ԍo�߂Ō����폜
        Destroy(gameObject, time);
    }
}
