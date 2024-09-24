using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void MyDestroy()
    {
        // 指定時間後に敵を削除
        Invoke("Destroy", 3.0f);
    }

    private void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
