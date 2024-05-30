using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // メーターの状態
    public enum MeterState
    {
        kNotMove,   // 動かない  
        kReduce,    // 減る
        kIncrease,  // 増える
    }

    [SerializeField]
    [Tooltip("変化させる画像")]
    private Image UIobj;

    // メーターの状態
    MeterState meterState = MeterState.kNotMove;
    public MeterState getMeterState() { return meterState; } // ゲッター
    public void setMeterState(MeterState MeterState) { meterState = MeterState; } // セッター

    public void IsCountdown(float KeyInputReceptionTime)
    {
        // メーターを減らす
        UIobj.fillAmount -= 1.0f / KeyInputReceptionTime * Time.deltaTime;
    }

    // メーターの表示・非表示
    public void IsViewMeter(bool Flag)
    {
        // 表示する
        if (Flag)
        {
            UIobj.fillAmount = 1.0f;
        }
        // 表示しない
        else
        {
            UIobj.fillAmount = 0.0f;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // メータを動かさない判定のとき
    //    if (meterState == MeterState.kNotMove)
    //    {
    //        // メーターを表示
    //        UIobj.fillAmount = 1.0f;

    //        // メータを減らす判定にする
    //        meterState = MeterState.kReduce;
    //    }

    //    // メータを減らす判定のとき
    //    else if (meterState == MeterState.kReduce)
    //    {
    //        // メーターを減らす
    //        UIobj.fillAmount -= 1.0f / reduceMeterCountTime * Time.deltaTime;

    //        // メーターが0になったとき
    //        if (UIobj.fillAmount == 0.0f)
    //        {
    //            // メータを増やす判定にする
    //            meterState = MeterState.kNotMove;
    //        }
    //    }
    //}
}
