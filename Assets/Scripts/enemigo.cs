using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {

    public Transform Jugador;
    public bool following;
    float speed = 5f;
    public float Y;
    public float Z;
    //public Transform trans_inicial;
    
    // Use this for initialization
	void Start () {

        Jugador = GameObject.FindWithTag("Player").transform;
 
       //trans_inicial.position=transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        if (following)
        {
            //Debug.Log(" creao que ya ");
            //transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,trans_inicial.position.y,0), Jugador.position, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,Y,Z), Jugador.position, Time.deltaTime * speed);
			//transform.position += Jugador.position.normalized * Time.deltaTime * speed;
        }
	}

}
