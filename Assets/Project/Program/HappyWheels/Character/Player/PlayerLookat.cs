using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �}�E�X�J�[�\���̈ʒu�Ƀv���C���[����]������
/// </summary>
public class PlayerLookat : MonoBehaviour
{
    Plane plane = new Plane();
    float distance = 0;

    void Update()
    {
        // �J�����ƃ}�E�X�̈ʒu������Ray������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            // ���������Ɍ�_���Z�o���āA��_�̕�������
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);
        }
    }
}