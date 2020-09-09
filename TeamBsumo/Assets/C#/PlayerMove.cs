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
    }
}
