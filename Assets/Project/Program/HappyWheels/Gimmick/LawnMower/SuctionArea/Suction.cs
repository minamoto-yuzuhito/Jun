using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PullBehindTheLawnMower;

public class Suction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("完了までの時間")]
    private float time = 3.0f;

    [SerializeField]
    [Tooltip("縮小後の値")]
    private Vector3 afterScale = new Vector3(0.1f, 0.1f, 0.1f);

    // 目的地
    private GameObject endPoint;

    // Start is called before the first frame update
    void Start()
    {
        // 芝刈り機の吸い込み口オブジェクトを取得
        endPoint = GameObject.FindWithTag("InhaleZone");

        // 芝刈り機の吸い込み口に向かって
        transform.DOMove(endPoint.transform.position, time);    // 徐々に近づく

        transform.DOScale(afterScale, time).                    // 徐々に縮小する
            OnComplete(() => Destroy(gameObject));              // 完了後、このオブジェクトを削除
    }
}
