using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telon : MonoBehaviour
{
    public Animator miTelon;

    public void OpenTelon() {
        miTelon.Play("TelonAbrir");
    }

    public void CloseTelon() {
        miTelon.Play("TelonCerrar");
    }
}
