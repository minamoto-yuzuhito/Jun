using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class TableSoccerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("操作するオブジェクト")]
    private GameObject operationObject;

    // 座標用の変数
    Vector3 mousePos, worldPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--- 移動 ---//
        // マウス座標の取得
        mousePos = Input.mousePosition;
        // スクリーン座標をワールド座標に変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        // x座標だけ使用する
        worldPos.y = operationObject.transform.position.y;
        worldPos.z = operationObject.transform.position.z;
        // 位置の更新
        operationObject.transform.position = worldPos;

        //--- 回転 ---//
        float sensitivity = 500.0f; // いわゆるマウス感度
        float mouse_move_x = Input.GetAxis("Mouse X") * sensitivity;
        float mouse_move_y = Input.GetAxis("Mouse Y") * sensitivity;

        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
        operationObject.transform.Rotate(new Vector3(0, -mouse_move_y, 0) * Time.deltaTime);
    }
}
