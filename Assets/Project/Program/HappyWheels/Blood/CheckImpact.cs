using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckImpact : MonoBehaviour
{
    [SerializeField]
    [Tooltip("����")]
    private GameObject pieceOfMeat;

    /// <summary>
    /// �g�̂̃p�[�c�������Ռ����󂯂�����Ђɒu������
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(transform.tag + "�F" + collision.impulse.magnitude);

        // �����Ռ����󂯂��Ƃ�
        if (collision.impulse.magnitude > 40)
        {
            // �Ռ����󂯂��ʒu�ɓ��Ђ𐶐�
            for (int i = 0; i < 7; i++)
            {
                Instantiate(pieceOfMeat, transform.position, Quaternion.identity);
            }

            // �Ռ����󂯂��̂̕��ʂ��폜
            Destroy(gameObject);
        }
    }
}
