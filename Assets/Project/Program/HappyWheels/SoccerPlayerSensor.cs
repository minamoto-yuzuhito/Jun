using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerSensor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Z���T�[�����m�����ۂɑ��삷��I�u�W�F�N�g���삷��I�u�W�F�N�g")]
    private GameObject operationObject;
    public GameObject GetOperationObject() {  return operationObject; } // �Q�b�^�[
}
