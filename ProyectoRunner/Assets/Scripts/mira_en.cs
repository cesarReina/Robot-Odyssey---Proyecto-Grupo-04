using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mira_en : MonoBehaviour {

    AudioSource son;
    public M_mira modelo;
 
	void Start () {

        son = GetComponent<AudioSource>();
        modelo.dispa = false;
	}

	void Update () {

        if (modelo.target == null)
            return;
        Flip(transform, modelo.target);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            modelo.dispa = true;
        }
       
    }
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (modelo.dispa == true)
            {
                InvokeRepeating("Disparo", 0.5f, 0.5f);
                InvokeRepeating("sonido", 0.5f, 0.5f);
                modelo.dispa = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("Disparo");
            CancelInvoke("Sonido");
        }
    }
    void Disparo()
    {
        GameObject repli = Instantiate(modelo.objeto, modelo.spawm.transform.position, modelo.spawm.transform.rotation) as GameObject;
        repli.AddComponent<Rigidbody>();
        repli.GetComponent<Rigidbody>().useGravity = false;
        repli.GetComponent<Rigidbody>().AddForce(modelo.spawm.transform.right * 30, ForceMode.VelocityChange);
        Destroy(repli.gameObject, 3);
    }
    void sound()
    {
        son.Play();
    }
    static public void Flip(Transform myObj, Transform otherObj)
    {
        Vector3 aux = otherObj.position;
        aux.y -= myObj.position.y;
        aux.x = 0;
        aux.z -= myObj.position.z;
        myObj.forward = aux;
    }
}
