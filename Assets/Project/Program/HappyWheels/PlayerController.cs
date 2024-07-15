using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ★追加（スパイダーフック）
    private enum State
    {
        Normal,
        ThrowingHook,
        FlyingPlayer
    }

    public GameObject FPSCamera;

    // ★追加（スパイダーフック）
    public float hookRange = 100f;
    public Transform hookTargetMark;
    public Transform hookShot;
    private Vector3 hookPoint;
    private float hookShotSize;
    private State state;

    private void Start()
    {
        // ★追加（スパイダーフック）
        state = State.Normal;
        hookShot.gameObject.SetActive(false);
        hookTargetMark.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ★改良＆追加（スパイダーフック）
        // （テクニック）
        // enumとswitch文を組み合わせることで、『この状態（モード）の時は、このメソッドを実行する』という仕組みを作れる。
        switch (state)
        {
            default:
            case State.Normal: // ノーマルモードの時
                HookStart();
                break;

            case State.ThrowingHook: // フック投げモードの時
                HookThrow();
                break;

            case State.FlyingPlayer: // プレーヤーが空中移動の時
                HookFlyingMovement();
                break;
        }
    }

    // ★追加（スパイダーフック）
    void HookStart()
    {
        // マウスの右ボタンを推した時
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, hookRange))
            {
                // Rayで特定した位置にターゲットマーク(目印）を移動させる。
                hookTargetMark.position = hit.point;
                hookPoint = hit.point;

                state = State.ThrowingHook;
                hookShotSize = 0f;

                hookTargetMark.gameObject.SetActive(true);
                hookShot.gameObject.SetActive(true);
            }
        }
    }

    // ★追加（スパイダーフック）
    void HookFlyingMovement()
    {
        Vector3 moveDir = (hookPoint - transform.position).normalized;

        // （テクニック）
        // 現在地と目的地の距離が遠いほど移動速度が早い（近くなるにつれて減速）
        float flyingSpeed = Vector3.Distance(transform.position, hookPoint) * 2f;

        transform.position += moveDir * flyingSpeed * Time.deltaTime;

        // 右クリックでスパイダーフックの解除
        if (Input.GetMouseButtonDown(1))
        {
            // ノーマルモードに移行する
            state = State.Normal;
            hookTargetMark.gameObject.SetActive(false);
            hookShot.gameObject.SetActive(false);
        }

        // 目標地点の近くまで来るとフックショットを自動的に隠す
        if (Vector3.Distance(transform.position, hookPoint) < 2f)
        {
            hookShot.gameObject.SetActive(false);
        }
    }

    // ★追加（スパイダーフック）
    void HookThrow()
    {
        hookShot.LookAt(hookPoint);

        float hookShotSpeed = 50f;
        hookShotSize += hookShotSpeed * Time.deltaTime;
        hookShot.localScale = new Vector3(1, 1, hookShotSize);

        if (hookShotSize >= Vector3.Distance(transform.position, hookPoint))
        {
            // 空中移動モードに移行（空中移動を開始する）
            state = State.FlyingPlayer;
        }
    }
}