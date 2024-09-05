using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Human")]
    private GameObject human;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // 被弾したとき
        if (other.gameObject.CompareTag("Bullet"))
        {
            // 人を生成
            Instantiate(human);

            // このオブジェクトを削除
            Destroy(gameObject);
        }
    }
}
