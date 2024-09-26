using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sliderを入れる")]
    private Slider slider;

    [SerializeField]
    [Tooltip("プレイヤーが酸素を取らずに生存できる時間")]
    private float timeToSurvive = 20.0f;

    // 経過時間
    private float nowTime;

    /// <summary>
    /// 体力を回復する
    /// </summary>
    /// <param name="Value"></param>
    public void IsHealing(float Value)
    {
        // 制限時間を延長
        nowTime += Value;

        // 最大時間を超えて回復してしまったとき
        if(nowTime > timeToSurvive)
        {
            // 最大値に設定
            nowTime = timeToSurvive;
        }
    }

    void Start()
    {
        // Sliderを満タンにする
        slider.value = 1;

        // 現在の経過時間に最大生存時間を代入
        nowTime = timeToSurvive;
    }

    /// <summary>
    /// 時間経過でプレイヤーのHPバーを減らす
    /// HPバーが0になったときtrueを返す
    /// </summary>
    /// <returns></returns>
    public bool DamageInPlayer()
    {
        // HPバーが0になったとき
        if (slider.value <= 0)
        {
            // ゲームオーバー判定
            return true;
        }

        // 経過時間
        nowTime -= Time.deltaTime;

        // 最大HPにおける現在のHPをSliderに反映
        slider.value = nowTime / timeToSurvive; ;

        return false;
    }
}
