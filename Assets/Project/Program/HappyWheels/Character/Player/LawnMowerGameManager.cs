using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("LawnMowerクラス")]
    private LawnMower lawnMower;

    [SerializeField]
    [Tooltip("PlayerControllerクラス")]
    private PlayerController playerController;

    [SerializeField]
    [Tooltip("FlyingObjectクラス")]
    private FlyingObject flyingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Inputの入力はFixedUpdateではなくUpdateで行う
    private void Update()
    {
        if(playerController != null)
        {
            // 移動の入力
            playerController.IsMoveInput();
            // 手で掴む
            playerController.IsGrapple();
        }
    }

    /// <summary>
    /// Rigidbodyを使用する移動はFixedUpdateで行う
    /// </summary>
    private void FixedUpdate()
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

        if (playerController != null)
        {
            // プレイヤーの操作
            playerController.IsMove();
        }
    }
}
