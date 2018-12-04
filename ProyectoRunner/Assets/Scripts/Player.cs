using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float velocidad;
    public bool flip;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!flip)
        movement();
        else
        {
            movementflip();
        }

        // transform.Translate(velocidad * Time.deltaTime, 0f, 0f);
        // transform.Translate(velocidad *Input.GetAxis("Horizontal")* Time.deltaTime, velocidad * Input.GetAxis("Vertical") * Time.deltaTime, 0f);

    }
    void movement(){
                if (Input.GetKey(KeyCode.A)) {
            transform.Translate(velocidad*Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-velocidad * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, velocidad * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -velocidad * Time.deltaTime, 0f);
        }
    }
    void movementflip(){
                if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-velocidad*Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(velocidad * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, velocidad * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -velocidad * Time.deltaTime, 0f);
        }
    }

  

}
