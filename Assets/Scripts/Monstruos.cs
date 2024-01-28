using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruos : MonoBehaviour
{
    public Transform seguir;

    private Vector3 vectorLook;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(seguir);

        Vector3 eulerRotation = transform.rotation.eulerAngles;

        eulerRotation.z = 0;
        transform.rotation = Quaternion.Euler(eulerRotation);

        eulerRotation.x = -90;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
