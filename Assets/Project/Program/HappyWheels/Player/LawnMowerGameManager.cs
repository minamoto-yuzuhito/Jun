using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("LawnMowerクラス")]
    private LawnMower lawnMower;

    [SerializeField]
    [Tooltip("FlyingObjectクラス")]
    private FlyingObject flyingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックしているとき
        // 芝刈り機に向かってくる吸い込みエリアを生成
        if (lawnMower.IsCreateSuctionArea())
        {
            // 停止
            flyingObject.IsStop();
        }
        // 左クリックしていないとき
        else
        {
            // 移動
            flyingObject.IsMove();
        }
    }
}
