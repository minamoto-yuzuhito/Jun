using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LawnMowerStartPoint : MonoBehaviour
{
    // �ړI�n
    private GameObject endPoint;

    [SerializeField]
    [Tooltip("�Ŋ���@���I�u�W�F�N�g���z�����ޑ��x")]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = transform.parent.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // �z�����݌���ړI�n�܂ňړ�
        transform.position =
        Vector3.MoveTowards(
            transform.position,
            endPoint.transform.position,
            speed * Time.deltaTime);
    }
}
