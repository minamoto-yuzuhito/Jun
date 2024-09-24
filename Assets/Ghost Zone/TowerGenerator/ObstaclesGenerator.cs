using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Q�������N���X
/// </summary>
public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��Q���I�u�W�F�N�gPrefab")]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    [Tooltip("��Q���̐����ʒu")]
    private GameObject obstaclesGeneratePos;

    [SerializeField]
    [Tooltip("��Q���̐e")]
    private GameObject obstaclesParentObject;

    /// <summary>
    /// ��Q���𐶐�
    /// </summary>
    public void GenerateObstacles()
    {
        // �w��̈ʒu�ɐ���
        Instantiate(
            obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)],
            obstaclesGeneratePos.transform.position,
            Quaternion.identity);
    }
}
