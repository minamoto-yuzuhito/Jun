using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodLost : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��")]
    private GameObject blood;

    // Update is called once per frame
    void Update()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// �w�莞�Ԍ�ɏo�����~�߂�
    /// </summary>
    public void BloodLossStopAafter()
    {
        // 2�b��ɏo�����~�߂�
        Invoke("BloodLossStop", 5);
    }

    /// <summary>
    /// �o�����~�߂�
    /// </summary>
    void BloodLossStop()
    {
        GetComponent<BloodLost>().enabled = false;
    }
}
