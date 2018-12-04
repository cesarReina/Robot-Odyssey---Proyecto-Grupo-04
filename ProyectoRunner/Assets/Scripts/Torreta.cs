using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour {
	public Transform target;
	public Transform partToRotate;
	public float turnSpeed;
	public GameObject bullet;
	public Transform firepoint;
	public bool shooting;
	private float count;
	public float firerate;
	// Use this for initialization
	void Start () {
		target=GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		LookAtTarget();
	if(shooting)
		AimAt();
		
	}
		public void LookAtTarget ()
	{
			if(target==null){
			return;
		}
		else{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*turnSpeed);
		}
	}
	    void Disparo()
    {
        GameObject repli = Instantiate(bullet,firepoint.transform.position, firepoint.transform.rotation);
		repli.GetComponent<Rigidbody>().AddForce(repli.transform.forward*600);
		
        Destroy(repli.gameObject, 1);
    }
	public  void AimAt()
	{
				if (target == null)
		{
		

			return;
		}

		
 
	 else
		{
			if (count <= 0f)
			{
				Disparo();
		
				
				count = 60/firerate;
			}

			count-= Time.deltaTime;
		}
	}
/// <summary>
/// OnTriggerEnter is called when the Collider other enters the trigger.
/// </summary>
/// <param name="other">The other Collider involved in this collision.</param>
void OnTriggerEnter(Collider other)
{
	if(other.gameObject.tag=="Player"){
		shooting=true;
	}
}

void OnTriggerExit(Collider other)
{
	if(other.gameObject.tag=="Player"){
		shooting=false;
	}
}
}
