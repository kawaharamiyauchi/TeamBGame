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

        public void SetHP(int hp)
        {
            HP = hp;
        }
        public void SetMP(int mp)
        {
            MP = mp;
        }
        public void SetStamina(int stamina)
        {
            Stamina = stamina;
        }
    }

    PlayerInfo p_Info =new PlayerInfo();

    public PlayerInfo GetPlayerInformation()
    {
        return p_Info;
    }
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

    public enum PlayerType
    {
        ONE,
        TWO,
        THREE
    }

    public enum PlayerNum
    {
        FirstPlayer_1P,
        SecondPlayer_2P
    }

    public PlayerState p_state;
    public PlayerType p_type;
    public PlayerNum p_num;

    public void SetPlayerNum(PlayerNum num)
    {
        p_num = num;
    }
    public Player enemy;
    public void SetEnemy(Player ene)
    {
        enemy = ene;
    }
   public  PlayerInfo enemyInfo;

    // Start is called before the first frame update
    void Start()
    {
        p_Info.InitData(100,100,100);
       enemyInfo = enemy.GetComponent<Player>().GetPlayerInformation();
        

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