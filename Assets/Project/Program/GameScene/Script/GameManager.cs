using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ToothControllerクラス")]
    public ToothController toothController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが押すべきキーを提示する
        toothController.PresentProblem();
    }
}
