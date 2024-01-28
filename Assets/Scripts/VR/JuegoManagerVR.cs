using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManagerVR : MonoBehaviour
{
    [Header("Luz")]
    public GameObject luz;

    public Animator fundido;
    public SentarseVR sit;

    void Start()
    {
        luz.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        luz.SetActive(false);
        fundido.Play("Fundidodeentrada");
        //sit.EmpezarActuacion();
    }

}
