using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAComputadora : MonoBehaviour
{
    public GameObject miPelota;
    Vector3 posicionPelota;
    float velocidad = 6.0f;
    private GameObject Jugador1, Jugador2;

    void Start()
    {
        Jugador1 = GameObject.Find("JugadorIzq").gameObject;
        Jugador2 = GameObject.Find("JugadorDrh").gameObject;
    }

    void Update()
    {
        if (Configuracion.tipojuego == 1) {
            float deltaY = velocidad * Time.deltaTime + (float)Pelota.numToques / 500.0f; // Velocidad Computadora
            posicionPelota = miPelota.gameObject.transform.position;
            if (posicionPelota.x >= -9 && posicionPelota.x <= 9)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, posicionPelota.y, 0), deltaY);
            } else{
                Jugador1.transform.position = new Vector3(-8, 0, 0);
                Jugador2.transform.position = new Vector3(8, 0, 0);
            }

        }
    }
}
