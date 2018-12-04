using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour {
    public int vida;
    public int maxvida = 3;
    public int memoriacounter = 0;
    public int gasolina;
    public int maxgasolina = 6;
    float Tiempotranscurrido = 0;
    float TiempoMaximo = 6;
    void Start()
    {
        vida = maxvida;
        gasolina = maxgasolina;
    }


     void OnCollisionEnter(Collision col )
    {
        Debug.Log("Choca con " + col.gameObject.tag);
        if (col.gameObject.tag == "Obstaculo") {
            vida = vida - 1;
            Debug.Log("Te quedan " + vida + "vidas");

        
        }

        if (col.gameObject.tag == "Gasolina") {
            gasolina = gasolina + 1;
            Destroy(col.gameObject, 1);
        }

        if (col.gameObject.tag == "Memoria") {
            memoriacounter = memoriacounter + 1;
            Debug.Log("Tienes " + memoriacounter + "memorias");

        }
         if (col.gameObject.tag == "Bala") {
            vida = vida - 1;
            Debug.Log("Te quedan " + vida + "vidas");
            Destroy(col.gameObject);

            }
            

    }

    public void Update()
    {
        Tiempotranscurrido += Time.deltaTime;

        if (Tiempotranscurrido >= TiempoMaximo) {
            Tiempotranscurrido = 0;
            gasolina--;
            Debug.Log("Te queda " + gasolina + "gasolina");
        }

        if (gasolina == 0) {

            SceneManager.LoadScene("LoseMenu");
        }
        if (vida <= 0)
        {
        
            SceneManager.LoadScene("LoseMenu");

        }

    }
}
