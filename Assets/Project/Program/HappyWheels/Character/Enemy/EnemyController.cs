using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class EnemyController : MonoBehaviour
{
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
