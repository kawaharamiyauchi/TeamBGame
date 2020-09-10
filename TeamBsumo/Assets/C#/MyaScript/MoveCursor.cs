using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{

    public Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        move.Set(x, y);
        if (Input.GetButtonDown("ButtonA"))
        {
            Debug.Log("PressA");
        }
        this.gameObject.transform.Translate(move);
        //this.gameObject.transform.
    }
}
