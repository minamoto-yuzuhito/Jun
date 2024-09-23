using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("新しいTowerオブジェクトの生成位置（DangerZoneオブジェクトを指定）")]
    private Transform newTowerPos;

    [SerializeField]
    [Tooltip("TowerオブジェクトのPrefab")]
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
