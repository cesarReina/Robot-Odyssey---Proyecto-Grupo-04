using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour {

    float speed = 5f;
	enemigo enen;
    public string tank;
    //public Transform trans_inicial;
    
    // Use this for initialization
	void Start () {
		enen=GameObject.Find(tank).GetComponent<enemigo>();

        
 
       //trans_inicial.position=transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hola");
        if (other.tag == "Player")
        {
            enen.following = true;
			
        }
    }
	    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enen.following = false;
        }
    }
}
