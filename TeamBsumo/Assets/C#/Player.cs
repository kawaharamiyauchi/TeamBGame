using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   public struct PlayerInfo
    {
        private int HP;          //プレイヤーの体力
        private int MP;          //プレイヤーの必殺技ゲージ
        private int Stamina;     //プレイヤーのスタミナ

        public void InitData(int hp,int mp,int stamina)
        {
           HP = hp;
           MP = mp;
           Stamina = stamina;
        }
        public int GetHP()
        {
            return HP;
        }
        public int GetMP()
        {
            return MP;
        }
        public int GetStamina()
        {
            return Stamina;
        }
    }

    public PlayerInfo p_Info =new PlayerInfo();
    public int P_HP;
    public int P_MP;
    public int P_Stamina;


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
        p_Info.InitData(100,100,100);
    }

    // Update is called once per frame
    void Update()
    {
        P_HP = p_Info.GetHP();
        P_MP = p_Info.GetMP();
        P_Stamina = p_Info.GetStamina();


        if(this.gameObject.transform.position.y<100.0f)
        {
            
        }

    }
}