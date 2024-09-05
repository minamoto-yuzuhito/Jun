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
        // ��e�����Ƃ�
        if (other.gameObject.CompareTag("Bullet"))
        {
            // �l�𐶐�
            Instantiate(human);

            // ���̃I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}
