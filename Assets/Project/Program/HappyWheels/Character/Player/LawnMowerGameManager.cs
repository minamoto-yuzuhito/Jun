using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("LawnMower�N���X")]
    private LawnMower lawnMower;

    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;

    [SerializeField]
    [Tooltip("FlyingObject�N���X")]
    private FlyingObject flyingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Input�̓��͂�FixedUpdate�ł͂Ȃ�Update�ōs��
    private void Update()
    {
        if(playerController != null)
        {
            // �ړ��̓���
            playerController.IsMoveInput();
            // ��Œ͂�
            playerController.IsGrapple();
        }
    }

    /// <summary>
    /// Rigidbody���g�p����ړ���FixedUpdate�ōs��
    /// </summary>
    private void FixedUpdate()
    {
        // ���N���b�N���Ă���Ƃ�
        // �Ŋ���@�Ɍ������Ă���z�����݃G���A�𐶐�
        if (lawnMower.IsCreateSuctionArea())
        {
            // ��~
            flyingObject.IsStop();
        }
        // ���N���b�N���Ă��Ȃ��Ƃ�
        else
        {
            // �ړ�
            flyingObject.IsMove();
        }

        if (playerController != null)
        {
            // �v���C���[�̑���
            playerController.IsMove();
        }
    }
}
