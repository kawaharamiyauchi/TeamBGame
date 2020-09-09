using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player m_player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(m_player);
       // m_player.gameObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
