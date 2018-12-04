using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 void OnTriggerEnter(Collider other) {
		 
		 if(other.gameObject.tag=="Player"){
			 Debug.Log("asdsad");
			 GameObject.FindGameObjectWithTag("Player").transform.rotation=new Quaternion(0,0,0,0);
			  GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().flip=true;
			

		 }
		
	}
}
