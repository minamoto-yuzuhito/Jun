using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckImpact : MonoBehaviour
{
    [SerializeField]
    [Tooltip("肉片")]
    private GameObject pieceOfMeat;

    /// <summary>
    /// 身体のパーツが強い衝撃を受けたら肉片に置換する
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(transform.tag + "：" + collision.impulse.magnitude);

        // 強い衝撃を受けたとき
        if (collision.impulse.magnitude > 40)
        {
            // 衝撃を受けた位置に肉片を生成
            for (int i = 0; i < 7; i++)
            {
                Instantiate(pieceOfMeat, transform.position, Quaternion.identity);
            }

            // 衝撃を受けた体の部位を削除
            Destroy(gameObject);
        }
    }
}
