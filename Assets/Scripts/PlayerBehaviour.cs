using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {
	static PlayerStats player;

	// Use this for initialization
	void Start () {
		player=GetComponent<PlayerStats>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void Movimiento(){
		    if (Input.GetKey(KeyCode.A)) {
            player.transform.Translate(player.velocidad*Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(-player.velocidad * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
           player. transform.Translate(0f, player.velocidad * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0f, -player.velocidad * Time.deltaTime, 0f);
        }
    }
	public static void Dash(){
				if (player.direction == 0) {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				player.direction = 1;
			} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
				player.direction = 2;
			} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
				player.direction = 3;
			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				player.direction = 4;
			}
		}
		 else {
			if (player.dashTime <= 0) {
				player.direction = 0;
				player.dashTime = player.startDashTime;
				player.rb.velocity = Vector3.zero;
			} else 
			{ 
				player.dashTime -= Time.deltaTime;

				if (player.direction == 1) {
					player.rb.velocity = Vector3.left * player.dashSpeed;
				} else if (player.direction == 2) {
					player.rb.velocity = Vector3.right * player.dashSpeed;
				} else if (player.direction == 3) {
					player.rb.velocity = Vector3.up * player.dashSpeed;
				} else if (player.direction == 4) {
					player.rb.velocity = Vector3.down * player.dashSpeed;
				}
			}
		}
	}
	public  static void Timer(){
		        player.Tiempotranscurrido += Time.deltaTime;

        if (player.Tiempotranscurrido >= player.TiempoMaximo) {
            player.Tiempotranscurrido = 0;
            player.gasolina--;
            Debug.Log("Te queda " + player.gasolina + "gasolina");
        }

        if (player.gasolina == 0) {
            Destroy(player.gameObject,2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

	}
	}
