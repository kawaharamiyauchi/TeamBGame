using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public struct PlayerInfo
    //{
        public int HP =100;          //プレイヤーの体力
        public int MP =100;          //プレイヤーの必殺技ゲージ
        public int Stamina =100;     //プレイヤーのスタミナ
    //}

    public enum PlayerState
    {
        preparation,
        startdash,
        normal,
        guard,
        fling,
        normalattack,
        damage,
        
    }
    public PlayerState p_state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}