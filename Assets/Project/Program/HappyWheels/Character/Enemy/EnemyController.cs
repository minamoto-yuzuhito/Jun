using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("移動速度")]
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
        // プレイヤーが存在しているとき
        if (playerChestRb != null)
        {
            Vector3 enemyChestPos = transform.position;
            Vector3 playerChestPos = playerChestRb.transform.position;

            Vector3 enemyChestVelocity = enemyChestRb.velocity;

            //--- 左右と奥行きの移動 ---//
            // 敵がプレイヤーより右に居る時
            if (enemyChestPos.x > playerChestPos.x)
            {
                // 左に移動
                enemyChestVelocity.x = -speed.x;
            }
            // 敵がプレイヤーより左に居る時
            else
            {
                // 右に移動
                enemyChestVelocity.x = speed.x;
            }
            // 敵がプレイヤーより奥に居る時
            if (enemyChestPos.z > playerChestPos.z)
            {
                // 手前に移動
                enemyChestVelocity.z = -speed.z;
            }
            // 敵がプレイヤーより手前に居る時
            else
            {
                // 奥に移動
                enemyChestVelocity.z = speed.z;
            }

            //--- 上下移動 ---//
            float enemyChestPosYAbs = Mathf.Abs(enemyChestPos.y);
            float playerChestPosYAbs = Mathf.Abs(playerChestPos.y);

            float distancePlayer = 0;
            distancePlayer = Mathf.Abs(enemyChestPosYAbs - playerChestPosYAbs);

            // プレイヤーとの距離を計算
            // 敵がプレイヤーより上にいる時
            if (enemyChestPos.y > playerChestPos.y)
            {
                enemyChestVelocity.y -= 5;

                // 速度制限
                if (enemyChestVelocity.y < -60.0f)
                {
                    enemyChestVelocity.y = -60.0f;
                }
            }
            // 下にいる時
            else
            {
                // ゆっくり下降
                enemyChestVelocity.y -= 5.0f;

                // 速度制限
                if (enemyChestVelocity.y < -30.0f)
                {
                    enemyChestVelocity.y = -30.0f;
                }
            }

            // プレイヤーの近くにいる時
            //if (distancePlayer < 10.0f)
            //{
            //    // 速度制限
            //    if (enemyChestVelocity.y > 5.0f)
            //    {
            //        enemyChestVelocity.y = 5;
            //    }
            //    else if (enemyChestVelocity.y < -5.0f)
            //    {
            //        enemyChestVelocity.y = -5;
            //    }
            //}
            //// プレイヤーから一定距離離れているとき
            //else
            //{
            //    // 速度制限
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
