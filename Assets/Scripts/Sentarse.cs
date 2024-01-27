using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentarse : MonoBehaviour
{
    public GameObject[] enemigos;
    public Animator miTelon;

    // Start is called before the first frame update
    void Start()
    {
        CrearEnemigo();
        //OpenTelon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrearEnemigo() {
        Debug.Log("Nuevo enemigo");
        Vector3 posicionEnemigo = new Vector3(0, 1, 3);
        var enemigoGenerado = enemigos[Random.Range(0, enemigos.Length)];
        var nuevoEnem = Instantiate(enemigoGenerado, posicionEnemigo, Quaternion.identity);
        Destroy(nuevoEnem, 2);
        //CloseTelon();

        Invoke("CrearEnemigo", 3.0f);
    }

    public void OpenTelon() {
        miTelon.Play("TelonAbrir");
    }

    public void CloseTelon() {
        miTelon.Play("TelonCerrar");
    }
}
