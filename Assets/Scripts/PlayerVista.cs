using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVista : MonoBehaviour {
	PlayerStats player;

	// Use this for initialization
	void Start () {
		player=GetComponent<PlayerStats>();
		player.rb = GetComponent<Rigidbody>();
		player.dashTime = player.startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerBehaviour.Dash();
		PlayerBehaviour.Timer();
		PlayerBehaviour.Movimiento();
		
		
	}
	     void OnCollisionEnter(Collision col )
    {
        Debug.Log("Choca con " + col.gameObject.tag);
        if (col.gameObject.tag == "Obstaculo") {
            player.vida = player.vida - 1;
            Debug.Log("Te quedan " + player.vida + "vidas");
            if (player.vida == 0) {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
        
        }

        if (col.gameObject.tag == "Gasolina") {
           player. gasolina = player.gasolina + 1;
            Destroy(col.gameObject, 1);
        }

        if (col.gameObject.tag == "Memoria") {
           player. memoriacounter = player.memoriacounter + 1;
            Debug.Log("Tienes " + player.memoriacounter + "memorias");

        }

    }
}
