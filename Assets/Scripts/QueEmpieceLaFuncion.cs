using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueEmpieceLaFuncion : MonoBehaviour
{

    public Sentarse sit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        sit.EmpezarActuacion();
    }
    
}
