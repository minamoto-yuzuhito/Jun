using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

/// <summary>
/// ��莞�Ԗ��ɃI�u�W�F�N�g���ˏo����
/// </summary>
public class Throwing : MonoBehaviour
{
    /// <summary>
    /// �ˏo����I�u�W�F�N�g
    /// </summary>
    [SerializeField, Tooltip("�ˏo����I�u�W�F�N�g�������Ɋ��蓖�Ă�")]
    private GameObject ThrowingObject;

    /// <summary>
    /// �W�I�̃I�u�W�F�N�g
    /// </summary>
    [SerializeField, Tooltip("�W�I�̃I�u�W�F�N�g�������Ɋ��蓖�Ă�")]
    private GameObject[] TargetObject = new GameObject[(int)ToothPosition.ToothPlus + 1];

    [SerializeField, Tooltip("�����̃C���^�[�o��")]
    private int interval = 3;

    /// <summary>
    /// �ˏo�p�x
    /// </summary>
    [SerializeField, Range(0F, 90F), Tooltip("�ˏo����p�x")]
    private float ThrowingAngle;

    private void Start()
    {

    }

    /// <summary>
    /// �����ˏo����
    /// </summary>
    public void IsThrowingObject(ToothPosition ToothPosition)
    {
        // ���I�u�W�F�N�g�̐���
        GameObject throwingObject = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

        // �W�I�̍��W
        Vector3 targetPosition = TargetObject[(int)ToothPosition].transform.position;

        // �ˏo�p�x
        float angle = ThrowingAngle;

        // �ˏo���x���Z�o
        Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

        // �ˏo
        Rigidbody rid = throwingObject.GetComponent<Rigidbody>();
        rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
    }

    /// <summary>
    /// �W�I�ɖ�������ˏo���x�̌v�Z
    /// </summary>
    /// <param name="pointA">�ˏo�J�n���W</param>
    /// <param name="pointB">�W�I�̍��W</param>
    /// <returns>�ˏo���x</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // �ˏo�p�����W�A���ɕϊ�
        float rad = angle * Mathf.PI / 180;

        // ���������̋���x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // ���������̋���y
        float y = pointA.y - pointB.y;

        // �Ε����˂̌����������x�ɂ��ĉ���
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // �����𖞂����������Z�o�ł��Ȃ����Vector3.zero��Ԃ�
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
