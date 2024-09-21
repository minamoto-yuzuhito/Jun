using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class TableSoccerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���삷��I�u�W�F�N�g")]
    private GameObject operationObject;
    public void SetOperationObject(GameObject obj) { operationObject = obj; }

    [SerializeField]
    [Tooltip("SoccerBal")]
    private SoccerBal soccerBal;

    [SerializeField]
    [Tooltip("�}�E�X���x�i�ړ��j")]
    private float moveSensitivity = 0.1f;

    [SerializeField]
    [Tooltip("�}�E�X���x�i��]�j")]
    private float rotateSensitivity = 500.0f;

    // Update is called once per frame
    void Update()
    {
        float mouse_move_x = Input.GetAxis("Mouse X") * moveSensitivity;
        float mouse_move_y = Input.GetAxis("Mouse Y") * rotateSensitivity;

        //--- �ړ� ---//
        // ���N���b�N���Ă���Ƃ�
        if (Input.GetMouseButton(0))
        {
            // x���W�����g�p����
            Vector3 pos = operationObject.transform.position;
            pos.x += mouse_move_x;
            // �ʒu�̍X�V
            operationObject.transform.position = pos;
        }

        //--- ��] ---//
        // �E�N���b�N���Ă���Ƃ�
        if (Input.GetMouseButton(1))
        {
            // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
            // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
            operationObject.transform.Rotate(new Vector3(-mouse_move_y, 0, 0) * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // �T�b�J�[�{�[���̑���
        soccerBal.Acceleration();
    }
}
