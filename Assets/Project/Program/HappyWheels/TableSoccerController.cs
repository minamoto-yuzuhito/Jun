using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class TableSoccerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���삷��I�u�W�F�N�g")]
    private GameObject operationObject;

    // ���W�p�̕ϐ�
    Vector3 mousePos, worldPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--- �ړ� ---//
        // �}�E�X���W�̎擾
        mousePos = Input.mousePosition;
        // �X�N���[�����W�����[���h���W�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        // x���W�����g�p����
        worldPos.y = operationObject.transform.position.y;
        worldPos.z = operationObject.transform.position.z;
        // �ʒu�̍X�V
        operationObject.transform.position = worldPos;

        //--- ��] ---//
        float sensitivity = 500.0f; // ������}�E�X���x
        float mouse_move_x = Input.GetAxis("Mouse X") * sensitivity;
        float mouse_move_y = Input.GetAxis("Mouse Y") * sensitivity;

        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
        operationObject.transform.Rotate(new Vector3(0, -mouse_move_y, 0) * Time.deltaTime);
    }
}
