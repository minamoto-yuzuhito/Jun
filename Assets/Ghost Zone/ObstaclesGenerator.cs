using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Enemy")]
    private GameObject enemyPrefab;

    [SerializeField]
    [Tooltip("�����ʒu")]
    private GameObject generatePos;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject parentObject;

    void OnTriggerEnter(Collider other)
    {
        // �l�ԃI�u�W�F�N�g���͈͓��ɓ������Ƃ�
        if (other.transform.CompareTag("BodyParts"))
        {
            // ���̉ӏ������������Ƃ�
            if (other.transform.parent.CompareTag("Chest"))
            {
                // �v���C���[�̂Ƃ�
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    GameObject obj = Instantiate(enemyPrefab, generatePos.transform.position, Quaternion.identity);
                    obj.transform.parent = parentObject.transform;
                }
            }
        }
    }
}
