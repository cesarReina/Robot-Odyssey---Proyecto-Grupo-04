using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Vida player;
    public Image img;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
    }


    void Update()
    {





        img.fillAmount = (((float)player.gasolina / player.maxgasolina));

   




    }
}
