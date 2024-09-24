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

        // 右
        if (enemyChestPos.x > playerChestPos.x)
        {
            enemyChestVelocity.x = -5;
        }
        // 左
        else
        {
            enemyChestVelocity.x = 5;
        }

        // 同じ位置
        if (enemyChestPos.y == playerChestPos.y)
        {
            if (enemyChestRb.velocity.y < -50.0f)
            {
                enemyChestVelocity.y = -50.0f;
            }
        }
        // 上
        else if (enemyChestPos.y > playerChestPos.y)
        {
            enemyChestVelocity.y += -5; // 下降
        }
        // 下
        else
        {
            enemyChestVelocity.y += 10; // 上昇
        }

        // 奥
        if (enemyChestPos.z > playerChestPos.z)
        {
            enemyChestVelocity.z = -5;
        }
        // 手前
        else
        {
            enemyChestVelocity.z = 5;
        }

        enemyChestRb.velocity = enemyChestVelocity;
    }

    //[SerializeField]
    //[Tooltip("パラシュートオブジェクト")]
    //private GameObject parachute;

    //[SerializeField]
    //[Tooltip("人間オブジェクト")]
    //private GameObject human;

    //void OnTriggerEnter(Collider other)
    //{
    //    // 被弾したとき
    //    if (other.gameObject.CompareTag("Bullet"))
    //    {
    //        // 被弾した際に居た位置
    //        Vector3 enemyDestroyPos = transform.position;

    //        // 人間を生成
    //        GameObject humanObject = Instantiate(human, enemyDestroyPos, Quaternion.identity);

    //        // 人間の少し上にパラシュートを生成
    //        enemyDestroyPos.y += 6.0f;
    //        GameObject parachuteObject = Instantiate(parachute, enemyDestroyPos, Quaternion.identity);

    //        //--- パラシュートと人間をHinge Jointで繋げる ---//
    //        humanObject.transform.GetChild((int)BodyParts.Chest).   // 人間オブジェクトの子要素である【Chestオブジェクト】を取得
    //            gameObject.AddComponent<HingeJoint>().              // 【Chestオブジェクト】にHinge Jointをアタッチ
    //            connectedBody = parachuteObject.GetComponent<Rigidbody>();  // パラシュートに人間を繋げる

    //        // 【親】パラシュート
    //        // 【子】人間
    //        humanObject.transform.parent = parachuteObject.transform;

    //        // このオブジェクトを削除
    //        Destroy(gameObject);
    //    }
    //}
}
