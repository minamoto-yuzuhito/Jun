using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    // カウントダウン
    public float countdown = 5.0f;

    [SerializeField]
    [Tooltip("時間を表示するText型の変数")]
    private TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        // 時間をカウントダウンする
        countdown -= Time.deltaTime;

        // 時間を表示する
        timeText.text = "Next" + countdown.ToString("f1") + "秒";

        // countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "Let's Go!";
        }
    }
}
