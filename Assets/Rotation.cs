using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("回転速度")]
    private float rotateSpeed = 200;

    private int rotationDirection = 1;

    public void IsRotateRight() { rotationDirection = 1; }  // 右回転
    public void IsRotateLeft() { rotationDirection = -1; }   // 左回転

    // Update is called once per frame
    void Update()
    {
        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
        gameObject.transform.Rotate(new Vector3(0, rotateSpeed * rotationDirection, 0) * Time.deltaTime);
    }
}
