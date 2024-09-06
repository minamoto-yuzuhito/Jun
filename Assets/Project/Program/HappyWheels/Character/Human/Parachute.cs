using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CheckDamage;

public class Parachute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 3秒後にパラシュートを人間から切り離す
        Invoke("DetachTheParachute", 2.0f);
    }

    private void DetachTheParachute()
    {
        GameObject human = transform.GetChild(0).gameObject;

        // ChestオブジェクトにアタッチされているHingeJointを削除
        Destroy(human.transform.GetChild((int)BodyParts.Chest).GetComponent<HingeJoint>());

        // 親子関係を解除
        human.transform.parent = null;

        // パラシュートを削除
        Destroy(gameObject);
    }
}
