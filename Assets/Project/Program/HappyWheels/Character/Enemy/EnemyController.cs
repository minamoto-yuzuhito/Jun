using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyChestRb;
    private Rigidbody playerChestRb;

    private void Start()
    {
        enemyChestRb = GetComponent<Rigidbody>();
        playerChestRb = GameObject.FindWithTag("Chest").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        Vector3 enemyChestPos = transform.position;
        Vector3 playerChestPos = playerChestRb.transform.position;

        Vector3 enemyChestVelocity = enemyChestRb.velocity;

        // �E
        if (enemyChestPos.x > playerChestPos.x)
        {
            enemyChestVelocity.x = -5;
        }
        // ��
        else
        {
            enemyChestVelocity.x = 5;
        }

        // �����ʒu
        if (enemyChestPos.y == playerChestPos.y)
        {
            if (enemyChestRb.velocity.y < -50.0f)
            {
                enemyChestVelocity.y = -50.0f;
            }
        }
        // ��
        else if (enemyChestPos.y > playerChestPos.y)
        {
            enemyChestVelocity.y += -5; // ���~
        }
        // ��
        else
        {
            enemyChestVelocity.y += 10; // �㏸
        }

        // ��
        if (enemyChestPos.z > playerChestPos.z)
        {
            enemyChestVelocity.z = -5;
        }
        // ��O
        else
        {
            enemyChestVelocity.z = 5;
        }

        enemyChestRb.velocity = enemyChestVelocity;
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
