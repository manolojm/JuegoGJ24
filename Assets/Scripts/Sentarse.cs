using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sentarse : MonoBehaviour {
    public GameObject[] enemigos;
    public GameObject[] sonidos;
    public Animator miTelon;
    public GameObject canvas;
    public GameObject canvasDerrota;
    public GameObject canvasVictoria;
    public GameObject canvasAcierto;
    public GameObject canvasFallo;

    public int likes;
    public int dislikes;
    public int rondas;
    public int puntosChiste;
    public int vota;

    //public AudioSource[] sonidos;

    void Start() {
        //EmpezarActuacion();
        likes = 0;
        dislikes = 0;
        rondas = 0;
        vota = 0;
        ElegirPuntosChiste();
    }

    // Update is called once per frame
    void Update() {

    }

    // Empieza la actuación
    public void EmpezarActuacion() {
        likes = 0;
        dislikes = 0;
        rondas = 0;
        vota = 0;
        ElegirPuntosChiste();
        CrearEnemigo();
    }

    // Crea enemigos
    public void CrearEnemigo() {
        ElegirPuntosChiste();
        vota = 0;

        if ((dislikes > 2) || (rondas > 4)) {
            FinJuego();
        } else {
            //Debug.Log("Ronda ---> " + rondas);
            //Vector3 posicionEnemigo = new Vector3(0, 1, 3);

            Invoke("MostrarEnemigo", 3.0f);
            Invoke("AnimOpenTelon", 3.0f);
            Invoke("MostrarCanvas", 5.0f);

            Invoke("AnimCloseTelon", 13.0f);
            Invoke("OcultarCanvas", 15.0f);
            //Invoke("ContarChiste", 3.0f);
            Invoke("CrearEnemigo", 20.0f);
        }
    }

    // Muestra enemigo
    public void MostrarEnemigo() {
        Debug.Log("Ronda ---> " + rondas);
        var enemigoGenerado = enemigos[rondas];
        var nuevoEnem = Instantiate(enemigoGenerado, enemigoGenerado.transform.position, Quaternion.identity);
        Destroy(nuevoEnem, 11);
    }

    // Contar un chiste
    public void ContarChiste() {
        //sonidos[rondas].Play();
        Invoke("PararChiste", 3.0f);
    }

    // Parar chiste
    public void PararChiste() {
        //sonidos[rondas].Stop();
    }

    // Elegir puntos chiste 1-Bueno 0-Malo
    public void ElegirPuntosChiste() {
        //Debug.Log("El chiste es: " + puntosChiste);
        puntosChiste = Random.Range(0, 2);
    }

    // Animación de abrir el telón
    public void AnimOpenTelon() {
        miTelon.Play("SubirTelon");
    }

    // Animación de cerrar el telón
    public void AnimCloseTelon() {
        miTelon.Play("BajarTelon");
        Invoke("Sonidos", 1.0f);
    }

    public void Sonidos() {
        var sonidosGenerados = sonidos[puntosChiste];
        var sonidoPlantilla = Instantiate(sonidosGenerados, sonidosGenerados.transform.position, Quaternion.identity);
        Destroy(sonidoPlantilla, 3);
        
    }

    // Mostrar canvas
    public void MostrarCanvas() {
        Cursor.lockState = CursorLockMode.Confined;
        canvas.SetActive(true);
    }

    // Ocultar canvas
    public void OcultarCanvas() {
        Cursor.lockState = CursorLockMode.Locked;
        if (vota != 1){
            dislikes++;
        }
        canvas.SetActive(false);
        rondas++;
    }

    // Reirse
    public void BtnRisa() {
        if (puntosChiste == 1) {
            //Debug.Log("AciertoRisa1 - " + puntosChiste);
            likes++;
            Invoke("CanvasAcierto", 1.0f);
        } else {
            //Debug.Log("FalloRisa1 - " + puntosChiste);
            dislikes++;
            Invoke("CanvasFallo", 1.0f);
        }
        vota = 1;
        OcultarCanvas();
    }

    // Abuchear
    public void BtnAbucheo() {
        if (puntosChiste != 1) {
            //Debug.Log("AciertoAbucheo0 - " + puntosChiste);
            likes++;
            Invoke("CanvasAcierto", 1.0f);
        } else {
            //Debug.Log("FalloAbucheo0 - " + puntosChiste);
            dislikes++;
            Invoke("CanvasFallo", 1.0f);
        }
        vota = 1;
        OcultarCanvas();
    }

    public void CanvasAcierto() {
        canvasAcierto.SetActive(true);
        Invoke("CanvasAciertoB", 2.0f);
    }

    public void CanvasFallo() {
        canvasFallo.SetActive(true);
        Invoke("CanvasFalloB", 2.0f);
    }

    public void CanvasAciertoB() {
        canvasAcierto.SetActive(false);
    }

    public void CanvasFalloB() {
        canvasFallo.SetActive(false);
    }




    // Puntuación
    public void Puntos() {

    }

    public void FinJuego() {
        Debug.Log("Ha acabado el juego");
        if (dislikes > 2) {
            canvasDerrota.SetActive(true);
        } else {
            canvasVictoria.SetActive(true);
        }
        
    }
}