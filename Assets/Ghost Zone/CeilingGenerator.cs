using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CeilingGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����ʒu")]
    private Transform generatoePos;

    [SerializeField]
    [Tooltip("�V��I�u�W�F�N�g��Prefab")]
    private GameObject ceilingPrefab;

    [SerializeField]
    [Tooltip("�V��̐e�Ɏw�肷��I�u�W�F�N�g")]
    private GameObject ceilingParent;

    private bool isTowergenerate = false;

    void OnTriggerEnter(Collider other)
    {
        // �V��𐶐����Ă��Ȃ��Ƃ�
        if (!isTowergenerate)
        {
            if (other.transform.parent.CompareTag("Chest"))
            {
                // �V��𐶐�
                Instantiate(ceilingPrefab, generatoePos.position, Quaternion.identity, ceilingParent.transform);
                isTowergenerate = true;
            }
        }
    }
}
