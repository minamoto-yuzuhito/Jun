using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �v���C���[�̃Z���T�[�ɐG�ꂽ�Ƃ�
    /// ���C���[�ݒ�ɂ���ăT�b�J�[�{�[���I�u�W�F�N�g�̓v���C���[�̃Z���T�[�������m�ł��Ȃ�
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("���蔲�����I");


    }
}
