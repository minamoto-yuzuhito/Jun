using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerGameManager : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("LawnMower�N���X")]
    //private LawnMower lawnMower;

    [SerializeField]
    [Tooltip("PlayerController�N���X")]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Rigidbody���g�p����ړ���FixedUpdate�ōs��
    /// </summary>
    private void FixedUpdate()
    {
        // ���N���b�N���Ă���Ƃ�
        // �Ŋ���@�Ɍ������Ă���z�����݃G���A�𐶐�
        //if (lawnMower.IsCreateSuctionArea())
        //{
        //    // ��~
        //    playerController.IsStop();
        //}
        //// ���N���b�N���Ă��Ȃ��Ƃ�
        //else
        //{
        //    // �ړ�
        //    playerController.IsMove();
        //}

        // �ړ�
        playerController.IsMove();
    }

    // Input�̓��͂�FixedUpdate�ł͂Ȃ�Update�ōs��
    private void Update()
    {
        // �ړ��̓���
        playerController.IsMoveInput();
        // ��Œ͂�
        playerController.IsGrapple();
    }
}
