using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBehindTheLawnMower : MonoBehaviour
{
    // �Ŋ���@���\������I�u�W�F�N�g
    public enum LawnMowerObjects
    {
        kInhaleZone,    // �����̃Z���T�[�B���m�������̂����ɋz������
        kBreakZone,     // �I�_�̃Z���T�[�B���m�������̂�j�󂷂�
    }

    // �ړI�n
    private GameObject endPoint;

    [SerializeField]
    [Tooltip("�Ŋ���@���I�u�W�F�N�g���z�����ޑ��x")]
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = transform.parent.transform.GetChild((int)LawnMowerObjects.kBreakZone).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // �Ŋ���@�̉��ɘA��Ă����I�u�W�F�N�g��ړI�n�܂ňړ�
        transform.position =
        Vector3.MoveTowards(
            transform.position,
            endPoint.transform.position,
            speed * Time.deltaTime);
    }
}
