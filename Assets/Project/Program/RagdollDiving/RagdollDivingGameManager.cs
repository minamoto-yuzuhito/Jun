using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDivingGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PlayerControllerクラス")]
    private PlayerController playerController;

    /// <summary>
    /// ここでは操作入力を行う
    /// </summary>
    private void Update()
    {
        // キー入力を受け付ける
        playerController.IsMoveInput();
    }

    /// <summary>
    /// ここで実際にプレイヤーを移動させる
    /// Rigidbodyを使用する移動はFixedUpdateで行う
    /// </summary>
    private void FixedUpdate()
    {
        // プレイヤーの操作
        playerController.IsMove();
    }
}
