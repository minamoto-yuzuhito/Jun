using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�V����Tower�I�u�W�F�N�g�̐����ʒu�iDangerZone�I�u�W�F�N�g���w��j")]
    private Transform newTowerPos;

    [SerializeField]
    [Tooltip("Tower�I�u�W�F�N�g��Prefab")]
    private GameObject towerPrefab;

    private bool isTowergenerate = false;

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
        if (!isTowergenerate)
        {
            Instantiate(towerPrefab, newTowerPos.position, Quaternion.identity);
            isTowergenerate = true;
        }
    }
}
