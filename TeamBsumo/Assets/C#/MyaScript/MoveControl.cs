using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon =
           gameObject.GetComponent<CharacterController>();

        Vector3 move = new Vector3();
        //move.x = 0.1f;

        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move.x = -10.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move.x = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move.y += 50.0f;
        }
        move.y -= 4.0f;
        charaCon.Move(move);

        //Star star = GameObject.FindObjectOfType<Star>();
        //GameObject god = GameObject.Find("God");
        //God godScript = god.GetComponent<God>();
        //godScript.numGetStar++;
    }
}
