using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class Parachute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 3�b��Ƀp���V���[�g��l�Ԃ���؂藣��
        Invoke("DetachTheParachute", 2.0f);
    }

    private void DetachTheParachute()
    {
        GameObject human = transform.GetChild(0).gameObject;

        // Chest�I�u�W�F�N�g�ɃA�^�b�`����Ă���HingeJoint���폜
        Destroy(human.transform.GetChild((int)BodyParts.Chest).GetComponent<HingeJoint>());

        // �e�q�֌W������
        human.transform.parent = null;

        // �p���V���[�g���폜
        Destroy(gameObject);
    }
}
