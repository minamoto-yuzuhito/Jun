using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ړ����x")]
    private Vector3 speed = new Vector3(5.0f, 70.0f, 5.0f);

    private Rigidbody enemyChestRb;
    private Rigidbody playerChestRb;

    private void Start()
    {
        enemyChestRb = GetComponent<Rigidbody>();

        if (GameObject.FindWithTag("Chest").GetComponent<Rigidbody>() != null)
        {
            playerChestRb = GameObject.FindWithTag("Chest").GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        // �v���C���[�����݂��Ă���Ƃ�
        if (playerChestRb != null)
        {
            Vector3 enemyChestPos = transform.position;
            Vector3 playerChestPos = playerChestRb.transform.position;

            Vector3 enemyChestVelocity = enemyChestRb.velocity;

            //--- ���E�Ɖ��s���̈ړ� ---//
            // �G���v���C���[���E�ɋ��鎞
            if (enemyChestPos.x > playerChestPos.x)
            {
                // ���Ɉړ�
                enemyChestVelocity.x = -speed.x;
            }
            // �G���v���C���[��荶�ɋ��鎞
            else
            {
                // �E�Ɉړ�
                enemyChestVelocity.x = speed.x;
            }
            // �G���v���C���[��艜�ɋ��鎞
            if (enemyChestPos.z > playerChestPos.z)
            {
                // ��O�Ɉړ�
                enemyChestVelocity.z = -speed.z;
            }
            // �G���v���C���[����O�ɋ��鎞
            else
            {
                // ���Ɉړ�
                enemyChestVelocity.z = speed.z;
            }

            //--- �㉺�ړ� ---//
            float enemyChestPosYAbs = Mathf.Abs(enemyChestPos.y);
            float playerChestPosYAbs = Mathf.Abs(playerChestPos.y);

            float distancePlayer = 0;
            distancePlayer = Mathf.Abs(enemyChestPosYAbs - playerChestPosYAbs);

            // �v���C���[�Ƃ̋������v�Z
            // �G���v���C���[����ɂ��鎞
            if (enemyChestPos.y > playerChestPos.y)
            {
                enemyChestVelocity.y -= 5;

                // ���x����
                if (enemyChestVelocity.y < -60.0f)
                {
                    enemyChestVelocity.y = -60.0f;
                }
            }
            // ���ɂ��鎞
            else
            {
                // ������艺�~
                enemyChestVelocity.y -= 5.0f;

                // ���x����
                if (enemyChestVelocity.y < -30.0f)
                {
                    enemyChestVelocity.y = -30.0f;
                }
            }

            // �v���C���[�̋߂��ɂ��鎞
            //if (distancePlayer < 10.0f)
            //{
            //    // ���x����
            //    if (enemyChestVelocity.y > 5.0f)
            //    {
            //        enemyChestVelocity.y = 5;
            //    }
            //    else if (enemyChestVelocity.y < -5.0f)
            //    {
            //        enemyChestVelocity.y = -5;
            //    }
            //}
            //// �v���C���[�����苗������Ă���Ƃ�
            //else
            //{
            //    // ���x����
            //    if (enemyChestVelocity.y > speed.y)
            //    {
            //        enemyChestVelocity.y = speed.y;
            //    }
            //    else if (enemyChestVelocity.y < -speed.y)
            //    {
            //        enemyChestVelocity.y = -speed.y;
            //    }
            //}

            

            enemyChestRb.velocity = enemyChestVelocity;
        }
    }

    //[SerializeField]
    //[Tooltip("�p���V���[�g�I�u�W�F�N�g")]
    //private GameObject parachute;

    //[SerializeField]
    //[Tooltip("�l�ԃI�u�W�F�N�g")]
    //private GameObject human;

    //void OnTriggerEnter(Collider other)
    //{
    //    // ��e�����Ƃ�
    //    if (other.gameObject.CompareTag("Bullet"))
    //    {
    //        // ��e�����ۂɋ����ʒu
    //        Vector3 enemyDestroyPos = transform.position;

    //        // �l�Ԃ𐶐�
    //        GameObject humanObject = Instantiate(human, enemyDestroyPos, Quaternion.identity);

    //        // �l�Ԃ̏�����Ƀp���V���[�g�𐶐�
    //        enemyDestroyPos.y += 6.0f;
    //        GameObject parachuteObject = Instantiate(parachute, enemyDestroyPos, Quaternion.identity);

    //        //--- �p���V���[�g�Ɛl�Ԃ�Hinge Joint�Ōq���� ---//
    //        humanObject.transform.GetChild((int)BodyParts.Chest).   // �l�ԃI�u�W�F�N�g�̎q�v�f�ł���yChest�I�u�W�F�N�g�z���擾
    //            gameObject.AddComponent<HingeJoint>().              // �yChest�I�u�W�F�N�g�z��Hinge Joint���A�^�b�`
    //            connectedBody = parachuteObject.GetComponent<Rigidbody>();  // �p���V���[�g�ɐl�Ԃ��q����

    //        // �y�e�z�p���V���[�g
    //        // �y�q�z�l��
    //        humanObject.transform.parent = parachuteObject.transform;

    //        // ���̃I�u�W�F�N�g���폜
    //        Destroy(gameObject);
    //    }
    //}
}
