using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {
	public Transform newpos;
	public Transform oldpos;
	public GameObject puertita;
	public float speed;
	public bool open=false;
	 public float targetTime = 3.0f;
 

 

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		float step=speed*Time.deltaTime;
		if(open){
			puertita.transform.position=Vector3.MoveTowards(puertita.transform.position,newpos.position,step);
			Timer();
		}
		if (targetTime <= 0.0f)
		{
			open=false;
		timerEnded();
		}
		
	}
	void Timer(){
		targetTime -= Time.deltaTime;
	}
	 void timerEnded()
 {
	 	float step=speed*Time.deltaTime;
   puertita.transform.position=Vector3.MoveTowards(puertita.transform.position,oldpos.position,step);

 }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			Debug.Log("asdasd");
			open=true;
			

		}
	}


	
}
