using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    // �J�E���g�_�E��
    public float countdown = 5.0f;

    [SerializeField]
    [Tooltip("���Ԃ�\������Text�^�̕ϐ�")]
    private TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        // ���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        // ���Ԃ�\������
        timeText.text = "Next" + countdown.ToString("f1") + "�b";

        // countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "Let's Go!";
        }
    }
}
