using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{
    [Header("PERSONAJE1")]
    public GameObject personaje1;
    [Header ("PERSONAJE2")]
    public GameObject personaje2;

    public Animator animator;

    void Start()
    {
        personaje1.SetActive(true);
        personaje2.SetActive(false);
    }

 
    void OnTriggerEnter (Collider collider)
    {
        
        personaje1.SetActive(false);
        personaje2.SetActive(true);
        
        animacionEntrada();
        
    }

    public void animacionEntrada()
    {
        animator.Play("Animacionpersonaje");
    }
}
