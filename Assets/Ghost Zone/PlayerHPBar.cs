using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Slider������")]
    private Slider slider;

    [SerializeField]
    [Tooltip("�v���C���[���_�f����炸�ɐ����ł��鎞��")]
    private float timeToSurvive = 20.0f;

    // �o�ߎ���
    private float nowTime;

    /// <summary>
    /// �̗͂��񕜂���
    /// </summary>
    /// <param name="Value"></param>
    public void IsHealing(float Value)
    {
        // �������Ԃ�����
        nowTime += Value;

        // �ő厞�Ԃ𒴂��ĉ񕜂��Ă��܂����Ƃ�
        if(nowTime > timeToSurvive)
        {
            // �ő�l�ɐݒ�
            nowTime = timeToSurvive;
        }
    }

    void Start()
    {
        // Slider�𖞃^���ɂ���
        slider.value = 1;

        // ���݂̌o�ߎ��Ԃɍő吶�����Ԃ���
        nowTime = timeToSurvive;
    }

    /// <summary>
    /// ���Ԍo�߂Ńv���C���[��HP�o�[�����炷
    /// HP�o�[��0�ɂȂ����Ƃ�true��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool DamageInPlayer()
    {
        // HP�o�[��0�ɂȂ����Ƃ�
        if (slider.value <= 0)
        {
            // �Q�[���I�[�o�[����
            return true;
        }

        // �o�ߎ���
        nowTime -= Time.deltaTime;

        // �ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f
        slider.value = nowTime / timeToSurvive; ;

        return false;
    }
}
