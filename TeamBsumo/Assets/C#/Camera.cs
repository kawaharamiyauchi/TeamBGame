using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField, HeaderAttribute("ゲームオブジェクト")]
    public GameObject stPlayer; //1P
    public GameObject ndPlayer; //2P
    private GameObject c_camera; //カメラ

    private Vector3 stPlayerPosition; //1Pの座標
    private Vector3 ndPlayerPosition; //2Pの座標
    private double distance; //プレイヤー同士の距離
    private Vector3 midpoint; //プレイヤー間の中点座標

    private Vector3 cameraposition; //カメラの座標
    public float kyori; //近平面

    public float DistanceToPlayerM = 2f;

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

    //カメラ移動処理
    void TpsCameraMove(Vector3 midpoint)
    {
        //ステップが追加されたら回転する処理をマウス移動から変更する
        //マウスの移動を検知
        //var rotX = Input.GetAxis("Mouse X") * Time.deltaTime * 100f;
        //var rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * 100f;

        var lookAt = midpoint + Vector3.up * 1.2f;
        //回す
        //transform.RotateAround(lookAt, Vector3.up, rotX);

        //カメラの場所をプレイヤー間の距離に応じて変える
        if (distance > kyori)
        {
            DistanceToPlayerM = (float)distance;
        }

        // カメラとプレイヤーとの間の距離を調整
        transform.position = lookAt - transform.forward * DistanceToPlayerM;

        // カメラを横にずらして中央を開ける
        transform.position = transform.position + transform.right * 0.0f;

        //中点に視点を向ける
        c_camera.transform.LookAt(lookAt);
    }


    //確認用
    public GameObject MIDPOINT;
    void CameraMove()
    {
        //MIDPOINTをプレイヤー間に置く
        MIDPOINT.transform.position = midpoint;
        if (Input.GetButton("Jump"))
        {
            MIDPOINT.transform.Rotate(new Vector3(0, 1, 0));
        }
        var lookAt = midpoint + Vector3.up;
        // カメラとプレイヤーとの間の距離を調整
        transform.position = lookAt - transform.forward * DistanceToPlayerM;
        if (distance > kyori)
        {
            DistanceToPlayerM = (float)distance;
        }
        //中点に視点を向ける
        c_camera.transform.LookAt(lookAt);

    }
    //確認オワリ

    // スタート関数（最初に一回だけ呼び出される）
    private void Start()
    {
        c_camera = this.gameObject;

        //確認用
        Vector3 cameraPos = MIDPOINT.transform.position;

        //カメラを少し後ろに少し高く億
        cameraPos.z -= 3.0f;
        cameraPos.y += 1.0f;

        c_camera.transform.position = cameraPos;

        //親子関係を結ぶ
        c_camera.transform.parent = MIDPOINT.transform;
    }


    // アップデート関数（1フレームに一回呼び出される）
    void Update()
    {
        //プレイヤーの座標を更新（代入）
        stPlayerPosition = stPlayer.transform.position;
        ndPlayerPosition = ndPlayer.transform.position;

        ////カメラの座標を更新
        //cameraposition = c_camera.transform.position;

        //プレイヤー同士の距離を計算する
        PlayerDistance(stPlayerPosition, ndPlayerPosition);

        //プレイヤー間の中点を計算する
        PlayerMidPoint(stPlayerPosition, ndPlayerPosition);

        CameraMove();



        //カメラの回転処理
        //TpsCameraMove(midpoint);

        //中点に視点を向ける
        //c_camera.transform.LookAt(midpoint);

    }
}
