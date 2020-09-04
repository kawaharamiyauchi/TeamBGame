using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    struct PlayerInfo
    {
        public int HP;          //プレイヤーの体力
        public int MP;          //プレイヤーの必殺技ゲージ
        public int Stamina;     //プレイヤーのスタミナ
    }

    enum PlayerState
    {
        preparation,
        startdash,
        normal,
        guard,
        fling,
        normalattack,
        damage,
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}