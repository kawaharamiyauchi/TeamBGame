using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject stPlayer; //1P
    public GameObject ndPlayer; //2P
    private GameObject c_camera; //カメラ

    private Vector3 stPlayerPosition; //1Pの座標
    private Vector3 ndPlayerPosition; //2Pの座標
    private double distance; //プレイヤー同士の距離
    private Vector3 midpoint; //プレイヤー間の中点座標

    private Vector3 cameraposition; //カメラの座標
    public float kyori; //近平面

    //プレイヤー同士の距離計算処理(distanceに値が代入される)
    void PlayerDistance(Vector3 stPl,Vector3 ndPl)
    {
        //距離計算
        double a = (ndPl.x - stPl.x) * (ndPl.x - stPl.x);
        double b = (ndPl.y - stPl.z) * (ndPl.y - stPl.z);

        a += b;

        //平方根
        distance = System.Math.Sqrt(a);
    }

    //2人のプレイヤーの座標の中点を計算（midpointに値が代入される）
    void PlayerMidPoint(Vector3 stPl, Vector3 ndPl)
    {
        Vector3 m;
        //中点計算
        m.x = (ndPl.x + stPl.x) / 2;
        m.z = (ndPl.z + stPl.z) / 2;
        m.y = (ndPl.y + stPl.y) / 2;

        midpoint = m;
    }

    // スタート関数（最初に一回だけ呼び出される）
    void Start()
    {
        c_camera = this.gameObject;
    }

    // アップデート関数（1フレームに一回呼び出される）
    void Update()
    {
        //プレイヤーの座標を更新（代入）
        stPlayerPosition = stPlayer.transform.position;
        ndPlayerPosition = ndPlayer.transform.position;

        //カメラの座標を更新
        cameraposition = c_camera.transform.position;

        //プレイヤー同士の距離を計算する
        PlayerDistance(stPlayerPosition, ndPlayerPosition);
        //プレイヤー間の中点を計算する
        PlayerMidPoint(stPlayerPosition, ndPlayerPosition);
    
        //カメラの場所をプレイヤー間の距離に応じて変える
        if (distance > kyori)
        {
            cameraposition.z = (float)distance * -1;
        }
        Debug.Log(distance);

        //プレイヤー間の中点に移動する
        cameraposition.x = midpoint.x;


        //カメラを更新
        c_camera.transform.position = cameraposition;

        c_camera.transform.LookAt(midpoint);
    }
}
