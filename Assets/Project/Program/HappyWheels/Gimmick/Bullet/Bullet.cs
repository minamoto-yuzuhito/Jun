using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/// <summary>
/// �e�̐������_�ŁA�e�̓v���C���[�̕��������悤�Ɋp�x��ݒ肳���
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̑��x")]
    private float speed = 5.0f;

    void Update()
    {
        // �e�̈ړ�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // �ǂɓ���������
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
