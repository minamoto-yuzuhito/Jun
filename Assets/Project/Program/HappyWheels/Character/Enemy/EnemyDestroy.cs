using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void MyDestroy()
    {
        // �w�莞�Ԍ�ɓG���폜
        Invoke("Destroy", 3.0f);
    }

    private void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
