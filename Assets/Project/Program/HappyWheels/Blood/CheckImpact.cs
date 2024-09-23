using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class CheckImpact : MonoBehaviour
{
    [SerializeField]
    [Tooltip("肉片")]
    private GameObject pieceOfMeat;

    [SerializeField]
    [Tooltip("Dockingの識別用")]
    private string objectName = "BodyParts";
    public string GetObjectName() { return objectName; }    //ゲッター

    /// <summary>
    /// 身体のパーツが強い衝撃を受けたら肉片に置換する
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // 強い衝撃を受けたとき
        if (collision.impulse.magnitude > 40)
        {
            // 衝撃を受けた位置に肉片を生成
            for (int i = 0; i < 7; i++)
            {
                Instantiate(pieceOfMeat, transform.position, Quaternion.identity);
            }

            // 身体パーツの親オブジェクト
            Transform human = transform.parent;
            // 身体パーツ（頭や腕などのこと）
            Transform parts = transform;
            string partsName = BodyParts.None.ToString();

            GameObject obj = new GameObject(partsName);
            obj.transform.parent = human;

            // Hierarchyでの順番を取得
            int siblingIndex = parts.transform.GetSiblingIndex();

            // 順番を入れ替える
            obj.transform.SetSiblingIndex(siblingIndex);

            // 衝撃を受けた体の部位を削除
            Destroy(parts.gameObject);
        }
    }
}
