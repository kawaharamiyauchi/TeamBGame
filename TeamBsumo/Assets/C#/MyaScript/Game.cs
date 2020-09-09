using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player m_player_01;
    public Player m_player_02;
    public Player m_player_03;

    public Player firstPlayer;
    public Player secondPlayer;

    public void SelectButton()
    {
        firstPlayer =Instantiate(m_player_01,new Vector3(-100.0f,10.0f,40.0f), Quaternion.identity);
        secondPlayer =Instantiate(m_player_03, new Vector3(100.0f, 10.0f, 40.0f), Quaternion.identity);

        firstPlayer.gameObject.GetComponent<Player>().SetEnemy(secondPlayer);
        secondPlayer.gameObject.GetComponent<Player>().SetEnemy(firstPlayer);

    }
    // Start is called before the first frame update
    void Start()
    {
       

       // m_player.gameObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
