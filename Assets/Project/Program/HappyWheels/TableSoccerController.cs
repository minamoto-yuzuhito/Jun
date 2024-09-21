using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class TableSoccerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("操作するオブジェクト")]
    private GameObject operationObject;
    public void SetOperationObject(GameObject obj) { operationObject = obj; }

    [SerializeField]
    [Tooltip("SoccerBal")]
    private SoccerBal soccerBal;

    [SerializeField]
    [Tooltip("マウス感度（移動）")]
    private float moveSensitivity = 0.1f;

    [SerializeField]
    [Tooltip("マウス感度（回転）")]
    private float rotateSensitivity = 500.0f;

    // Update is called once per frame
    void Update()
    {
        float mouse_move_x = Input.GetAxis("Mouse X") * moveSensitivity;
        float mouse_move_y = Input.GetAxis("Mouse Y") * rotateSensitivity;

        //--- 移動 ---//
        // 左クリックしているとき
        if (Input.GetMouseButton(0))
        {
            // x座標だけ使用する
            Vector3 pos = operationObject.transform.position;
            pos.x += mouse_move_x;
            // 位置の更新
            operationObject.transform.position = pos;
        }

        //--- 回転 ---//
        // 右クリックしているとき
        if (Input.GetMouseButton(1))
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            operationObject.transform.Rotate(new Vector3(-mouse_move_y, 0, 0) * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // サッカーボールの操作
        soccerBal.Acceleration();
    }
}
