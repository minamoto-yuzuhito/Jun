using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        // 人間オブジェクトが範囲内から出たとき
        if (other.transform.CompareTag("BodyParts"))
        {
            // その箇所が胸だったとき
            if (other.transform.parent.CompareTag("Chest"))
            {
                // プレイヤーのとき
                if (other.transform.parent.parent.CompareTag("Player"))
                {
                    // タワーを削除
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
