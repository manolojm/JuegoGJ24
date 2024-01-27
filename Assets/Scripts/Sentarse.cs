using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sentarse : MonoBehaviour {
    public GameObject[] enemigos;
    public Animator miTelon;
    public GameObject canvas;

    public int likes;
    public int dislikes;
    public int rondas;
    public int puntosChiste;

    public AudioSource[] sonidos;

    // Start is called before the first frame update
    void Start() {
        EmpezarActuacion();
        likes = 0;
        dislikes = 0;
        rondas = 0;
        ElegirPuntosChiste();
    }

    // Update is called once per frame
    void Update() {

    }

    // Empieza la actuación
    public void EmpezarActuacion() {
        CrearEnemigo();
    }

    // Crea enemigos
    public void CrearEnemigo() {
        ElegirPuntosChiste();
        
        if ((dislikes > 2) || (rondas > 4)) {
            FinJuego();
        } else {
            //Debug.Log("Ronda ---> " + rondas);
            Vector3 posicionEnemigo = new Vector3(0, 1, 3);
            var enemigoGenerado = enemigos[Random.Range(0, enemigos.Length)];
            var nuevoEnem = Instantiate(enemigoGenerado, posicionEnemigo, Quaternion.identity);
            Destroy(nuevoEnem, 4);

            Invoke("AnimOpenTelon", 1.0f);
            Invoke("MostrarCanvas", 1.0f);

            Invoke("AnimCloseTelon", 3.0f);
            Invoke("OcultarCanvas", 3.0f);
            Invoke("ContarChiste", 3.0f);
            Invoke("CrearEnemigo", 10.0f);
        }
    }

    // Contar un chiste
    public void ContarChiste(){
        sonidos[rondas].Play();
        rondas++;
        Awake("PararChiste", 3.0f);
    }

    // Parar chiste
    public void PararChiste() {
        sonidos[rondas].Stop();
    }

    // Elegir puntos chiste 1-Bueno 0-Malo
    public void ElegirPuntosChiste() {
        Debug.Log("El chiste es: " + puntosChiste);
        puntosChiste = Random.Range(0, 2);
    }

    // Animación de abrir el telón
    public void AnimOpenTelon() {
        miTelon.Play("SubirTelon");
    }

    // Animación de cerrar el telón
    public void AnimCloseTelon() {
        miTelon.Play("BajarTelon");
    }

    // Mostrar canvas
    public void MostrarCanvas() {
        canvas.SetActive(true);
    }

    // Ocultar canvas
    public void OcultarCanvas() {
        canvas.SetActive(false);
    }

    // Reirse
    public void BtnRisa() {
        if (puntosChiste == 1) {
            Debug.Log("AciertoRisa1 - " + puntosChiste);
            likes++;
        } else {
            Debug.Log("FalloRisa1 - " + puntosChiste);
            dislikes++;
        }
        
        OcultarCanvas();
    }

    // Abuchear
    public void BtnAbucheo() {
        if (puntosChiste != 1) {
            Debug.Log("AciertoAbucheo0 - " + puntosChiste);
            likes++;
        } else {
            Debug.Log("FalloAbucheo0 - " + puntosChiste);
            dislikes++;
        }
        
        OcultarCanvas();
    }

    // Puntuación
    public void Puntos() {
        
    }

    public void FinJuego() {
        Debug.Log("Ha acabado el juego");
    }
}
