using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	このScriptはRigidbodyのアタッチが必須。無い場合は自動でアタッチする
[RequireComponent(typeof(Rigidbody))]
//	このScriptはAnimatorのアタッチが必須。無い場合は自動でアタッチする
[RequireComponent(typeof(Animator))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rig;
    private Animator anim;
    private float x, y;



    public GameObject c_camera;



    [SerializeField, HeaderAttribute("移動速度")]
    private float speed = 3.0f;

    // Use this for initialization
    void Start()
    {
        //	アタッチされたコンポーネントを取得
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //	スティックの傾きを取得
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //	AnimatorControllerのパラメータへ値を渡す
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector3(x, 0, y) * speed;

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(c_camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * y + c_camera.transform.right * x;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rig.velocity = moveForward * speed + new Vector3(0, rig.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

    }
}
