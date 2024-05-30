using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // ���[�^�[�̏��
    public enum MeterState
    {
        kNotMove,   // �����Ȃ�  
        kReduce,    // ����
        kIncrease,  // ������
    }

    [SerializeField]
    [Tooltip("�ω�������摜")]
    private Image UIobj;

    // ���[�^�[�̏��
    MeterState meterState = MeterState.kNotMove;
    public MeterState getMeterState() { return meterState; } // �Q�b�^�[
    public void setMeterState(MeterState MeterState) { meterState = MeterState; } // �Z�b�^�[

    public void IsCountdown(float KeyInputReceptionTime)
    {
        // ���[�^�[�����炷
        UIobj.fillAmount -= 1.0f / KeyInputReceptionTime * Time.deltaTime;
    }

    // ���[�^�[�̕\���E��\��
    public void IsViewMeter(bool Flag)
    {
        // �\������
        if (Flag)
        {
            UIobj.fillAmount = 1.0f;
        }
        // �\�����Ȃ�
        else
        {
            UIobj.fillAmount = 0.0f;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // ���[�^�𓮂����Ȃ�����̂Ƃ�
    //    if (meterState == MeterState.kNotMove)
    //    {
    //        // ���[�^�[��\��
    //        UIobj.fillAmount = 1.0f;

    //        // ���[�^�����炷����ɂ���
    //        meterState = MeterState.kReduce;
    //    }

    //    // ���[�^�����炷����̂Ƃ�
    //    else if (meterState == MeterState.kReduce)
    //    {
    //        // ���[�^�[�����炷
    //        UIobj.fillAmount -= 1.0f / reduceMeterCountTime * Time.deltaTime;

    //        // ���[�^�[��0�ɂȂ����Ƃ�
    //        if (UIobj.fillAmount == 0.0f)
    //        {
    //            // ���[�^�𑝂₷����ɂ���
    //            meterState = MeterState.kNotMove;
    //        }
    //    }
    //}
}
