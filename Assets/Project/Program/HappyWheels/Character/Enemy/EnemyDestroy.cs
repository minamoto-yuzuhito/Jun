using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void MyDestroy()
    {
        // w’èŠÔŒã‚É“G‚ğíœ
        Invoke("Destroy", 3.0f);
    }

    private void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
