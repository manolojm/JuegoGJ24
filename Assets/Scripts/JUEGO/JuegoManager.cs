using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{
    [Header("PERSONAJE1")]
    public GameObject personaje1;
    [Header("PERSONAJE2")]
    public GameObject personaje2;
    [Header("Luz")]
    public GameObject luz;

    public Animator fundido;

    void Start()
    {
        personaje1.SetActive(true);
        personaje2.SetActive(false);
        luz.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {

        personaje1.SetActive(false);
        personaje2.SetActive(true);
        luz.SetActive(false);
        fundido.Play("Fundidodeentrada");


    }

}
