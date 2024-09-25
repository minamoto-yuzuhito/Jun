using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�X�R�A�G���A�I�u�W�F�N�gPrefab")]
    private GameObject scoreAreaPrefab;

    [SerializeField]
    [Tooltip("�X�R�A�G���A�̐����ʒu")]
    private GameObject[] scoreAreaGeneratePos;

    /// <summary>
    /// �X�R�A�G���A�𐶐�
    /// </summary>
    public void GenerateScore()
    {
        // �w��̈ʒu�ɐ���
        Instantiate(scoreAreaPrefab,
            scoreAreaGeneratePos[Random.Range(0, scoreAreaGeneratePos.Length)].transform.position,
            Quaternion.identity);
    }
}