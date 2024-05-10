using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ToothController : MonoBehaviour
{
    /// <summary>
    /// キーごとに対応する歯
    /// </summary>
    public enum ToothType
    {
        ToothA, ToothS, ToothD, ToothF,     // 左手で操作する歯
        ToothJ, ToothK, ToothL, ToothPlus,  // 右手で操作する歯
    }

    // 子オブジェクトを格納する配列
    private List<GameObject> tooths = new List<GameObject>();

    private void Start()
    {
        // 子を順番に配列に格納
        for (int i = 0; i <= (int)ToothType.ToothPlus; i++)
        {
            tooths.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// 一番左の歯で嚙む
    /// </summary>
    private void OnBiteA() { tooths[(int)ToothType.ToothA].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 左から２番目の歯で嚙む
    /// </summary>
    private void OnBiteS() { tooths[(int)ToothType.ToothS].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 左から３番目の歯で嚙む
    /// </summary>
    private void OnBiteD() { tooths[(int)ToothType.ToothD].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 左から４番目の歯で嚙む
    /// </summary>
    private void OnBiteF() { tooths[(int)ToothType.ToothF].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 右から４番目の歯で嚙む
    /// </summary>
    private void OnBiteJ() { tooths[(int)ToothType.ToothJ].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 右から３番目の歯で嚙む
    /// </summary>
    private void OnBiteK() { tooths[(int)ToothType.ToothK].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 右から２番目の歯で嚙む
    /// </summary>
    private void OnBiteL() { tooths[(int)ToothType.ToothL].GetComponent<BiteWithTeeth>().IsBite(); }

    /// <summary>
    /// 一番右の歯で嚙む
    /// </summary>
    private void OnBitePlus() { tooths[(int)ToothType.ToothPlus].GetComponent<BiteWithTeeth>().IsBite(); }
}