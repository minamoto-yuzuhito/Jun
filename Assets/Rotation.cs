using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��]���x")]
    private float rotateSpeed = 200;

    private int rotationDirection = 1;

    public void IsRotateRight() { rotationDirection = 1; }  // �E��]
    public void IsRotateLeft() { rotationDirection = -1; }   // ����]

    // Update is called once per frame
    void Update()
    {
        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
        gameObject.transform.Rotate(new Vector3(0, rotateSpeed * rotationDirection, 0) * Time.deltaTime);
    }
}
