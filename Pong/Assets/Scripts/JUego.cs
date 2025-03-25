using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUego : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;
    public Text GameOver;

    private GameObject Marcador;
    private GameObject pelota;

    public static float velBola = 6.0f, velJugador = 7.5f;
    private int signoX, signoY, velocidad = 5;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("Pelota");
        Marcador = GameObject.Find("Marcador");
        Marcador.GetComponent<Text>().text = "0 - 0";

        if (Random.Range(0,1) > 0.5f) {
            signoX = 1;
        }
        else{
            signoX = -1;
        }

        StartCoroutine(ArbitroPitaInicio());
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
        }

        if (Pelota.golesJugadoreDrh == 2 || Pelota.golesJugadorIzq == 2)
        {
            if (Input.anyKey)
            {
                Pelota.golesJugadoreDrh = 0;
                Pelota.golesJugadorIzq = 0;
                SceneManager.LoadScene("Inicio");
            }
        }
    }

    public void EscribeMarcador()
    {
        Marcador.GetComponent<Text>().text = Pelota.golesJugadorIzq.ToString() + " - " + Pelota.golesJugadoreDrh.ToString();
        if (Pelota.golesJugadoreDrh == 2 || Pelota.golesJugadorIzq == 2)
        {
            GameOver.gameObject.SetActive(true);
            audio.clip = sndGameOver;
            audio.Play();
        }else {
            StartCoroutine(ArbitroPitaInicio());
        }
        
    }

    IEnumerator ArbitroPitaInicio()
    {
        yield return new WaitForSeconds(1.0f);
        LanzaPelota();
    }

    public void LanzaPelota()
    {
        audio.clip = sndSilbato;
        audio.Play();
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0);
        signoY = Random.Range(0, 1) > 0.5f ? 1 : -1;
        pelota.GetComponent<Rigidbody2D>().velocity = new Vector2(signoX * velocidad, signoY * velocidad);
    }
}
