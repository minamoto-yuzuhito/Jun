using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToothController;

public class ThrowingObjectSettings : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothControllerクラス")]
    public ToothController toothController;

    // 投げる物を順番に格納する
    private List<ToothPosition> throwingObjects = new List<ToothPosition>();
    public List<ToothPosition> GetThrowingObjects() { return throwingObjects; }

    /// <summary>
    /// 全ての歯で噛む
    /// </summary>
    private void OnBiteSpace(){ throwingObjects.Add(ToothPosition.AllTooth); toothController.IsToothShining(); }

    /// <summary>
    /// 一番左の歯で嚙む
    /// </summary>
    private void OnBiteA() { throwingObjects.Add(ToothPosition.ToothA); toothController.IsToothShining(); }

    /// <summary>
    /// 左から２番目の歯で嚙む
    /// </summary>
    private void OnBiteS() { throwingObjects.Add(ToothPosition.ToothS); toothController.IsToothShining(); }

    /// <summary>
    /// 左から３番目の歯で嚙む
    /// </summary>
    private void OnBiteD() { throwingObjects.Add(ToothPosition.ToothD); toothController.IsToothShining(); }

    /// <summary>
    /// 左から４番目の歯で嚙む
    /// </summary>
    private void OnBiteF() { throwingObjects.Add(ToothPosition.ToothF); toothController.IsToothShining(); }

    /// <summary>
    /// 右から４番目の歯で嚙む
    /// </summary>
    private void OnBiteJ() { throwingObjects.Add(ToothPosition.ToothJ); toothController.IsToothShining(); }

    /// <summary>
    /// 右から３番目の歯で嚙む
    /// </summary>
    private void OnBiteK() { throwingObjects.Add(ToothPosition.ToothK); toothController.IsToothShining(); }

    /// <summary>
    /// 右から２番目の歯で嚙む
    /// </summary>
    private void OnBiteL() { throwingObjects.Add(ToothPosition.ToothL); toothController.IsToothShining(); }

    /// <summary>
    /// 一番右の歯で嚙む
    /// </summary>
    private void OnBitePlus() { throwingObjects.Add(ToothPosition.ToothPlus); toothController.IsToothShining(); }
}
