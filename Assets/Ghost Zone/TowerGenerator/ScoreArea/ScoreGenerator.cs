using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("スコアエリアオブジェクトPrefab")]
    private GameObject scoreAreaPrefab;

    [SerializeField]
    [Tooltip("スコアエリアの生成位置")]
    private GameObject[] scoreAreaGeneratePos;

    /// <summary>
    /// スコアエリアを生成
    /// </summary>
    public void GenerateScore()
    {
        // 指定の位置に生成
        Instantiate(scoreAreaPrefab,
            scoreAreaGeneratePos[Random.Range(0, scoreAreaGeneratePos.Length)].transform.position,
            Quaternion.identity);
    }
}