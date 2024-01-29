using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sentarse : MonoBehaviour {

    public ControlHub controlhub;

    public GameObject[] enemigos;
    public GameObject[] sonidos;
    public GameObject canvas;
    public GameObject canvasDerrota;
    public GameObject canvasVictoria;
    public GameObject canvasAcierto;
    public GameObject canvasFallo;
    public GameObject canvasPuntos;
    public GameObject cuadrado;

    public Animator miTelon;

    public int likes;
    public int dislikes;
    public int rondas;
    public int puntosChiste;
    public int vota;
    public int miVoto;

    // Empieza la actuación
    public void EmpezarActuacion() {
        likes = 0;
        dislikes = 0;
        rondas = 0;
        vota = 0;
        miVoto = 0;
        puntosChiste = 0;
        CrearEnemigo();
        canvasPuntos.SetActive(true);
        cuadrado.SetActive(false);
    }

    // Crea enemigos
    public void CrearEnemigo() {
        controlhub.textoRondas.text = "Rondas: " + (rondas+1) + "/5";
        ElegirPuntosChiste();
        vota = 0;
        miVoto = 2;

        if ((dislikes > 2) || (rondas > 4)) {
            FinJuego();
        } else {
            Invoke("MostrarEnemigo", 3.0f);
            Invoke("AnimOpenTelon", 3.0f);
            Invoke("MostrarCanvas", 5.0f);

            Invoke("AnimCloseTelon", 13.0f);
            Invoke("OcultarCanvas", 13.0f);
            Invoke("CrearEnemigo", 16.0f);
        }
    }

    // Muestra enemigo
    public void MostrarEnemigo() {
        var enemigoGenerado = enemigos[rondas];
        var nuevoEnem = Instantiate(enemigoGenerado, enemigoGenerado.transform.position, Quaternion.identity);
        Destroy(nuevoEnem, 11);
    }

    // Elegir puntos chiste 1-Bueno 0-Malo
    public void ElegirPuntosChiste() {
        puntosChiste = Random.Range(0, 2);
        Debug.Log("Ronda: " + rondas + " --- El chiste es: " + puntosChiste);
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

    // Crea un prefab con el sonido y lo borra a los 3 segundos
    public void Sonidos() {
        var sonidosGenerados = sonidos[puntosChiste];
        var sonidoPlantilla = Instantiate(sonidosGenerados, sonidosGenerados.transform.position, Quaternion.identity);
        Destroy(sonidoPlantilla, 3);

        controlhub.textoFallos.text = "Fallos: " + dislikes + "/3";
        if (miVoto == puntosChiste) {
            CanvasAcierto();
        } else {
            CanvasFallo();
        }
    }

    // Mostrar canvas votación
    public void MostrarCanvas() {
        Cursor.lockState = CursorLockMode.Confined;
        canvas.SetActive(true);
    }

    // Ocultar canvas votación
    public void OcultarCanvas() {
        Cursor.lockState = CursorLockMode.Locked;
        if (vota != 1){
            SumarFallo();
            rondas++;
        }
        canvas.SetActive(false);
        
    }

    // Sumar fallo
    public void SumarFallo() {
        dislikes++;
    }

    // Reirse
    public void BtnRisa() {
        if (puntosChiste == 1) {
            likes++;
            //Invoke("CanvasAcierto", 1.0f);
        } else {
            SumarFallo();
            //Invoke("CanvasFallo", 1.0f);
        }

        miVoto = 1;
        vota = 1;
        rondas++;
        OcultarCanvas();
    }

    // Abuchear
    public void BtnAbucheo() {
        if (puntosChiste != 1) {
            likes++;
            //Invoke("CanvasAcierto", 1.0f);
        } else {
            SumarFallo();
            //Invoke("CanvasFallo", 1.0f);
        }

        miVoto = 0;
        vota = 1;
        rondas++;
        OcultarCanvas();
    }

    // Mostrar cuando has acertado
    public void CanvasAcierto() {
        canvasAcierto.SetActive(true);
        Invoke("CanvasAciertoB", 2.0f);
    }

    // Mostrar cuando has fallado
    public void CanvasFallo() {
        canvasFallo.SetActive(true);
        Invoke("CanvasFalloB", 2.0f);
    }

    // Desactiva el canvas del acierto
    public void CanvasAciertoB() {
        canvasAcierto.SetActive(false);
    }

    // Desactiva el canvas del fallo
    public void CanvasFalloB() {
        canvasFallo.SetActive(false);
    }

    // Acaba la partida
    public void FinJuego() {
        Cursor.lockState = CursorLockMode.None;
        if (dislikes > 2) {
            canvasDerrota.SetActive(true);
        } else {
            canvasVictoria.SetActive(true);
        }
        
    }
}