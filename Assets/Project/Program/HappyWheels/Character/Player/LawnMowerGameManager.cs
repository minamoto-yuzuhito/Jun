using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerGameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("LawnMower�N���X")]
    private LawnMower lawnMower;

    [SerializeField]
    [Tooltip("FlyingObject�N���X")]
    private FlyingObject flyingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
