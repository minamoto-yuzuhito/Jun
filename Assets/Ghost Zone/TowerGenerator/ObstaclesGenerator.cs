using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 障害物生成クラス
/// </summary>
public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("障害物オブジェクトPrefab")]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    [Tooltip("障害物の生成位置")]
    private GameObject obstaclesGeneratePos;

    [SerializeField]
    [Tooltip("障害物の親")]
    private GameObject obstaclesParentObject;

    /// <summary>
    /// 障害物を生成
    /// </summary>
    public void GenerateObstacles()
    {
        // 指定の位置に生成
        Instantiate(
            obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)],
            obstaclesGeneratePos.transform.position,
            Quaternion.identity);
    }
}
