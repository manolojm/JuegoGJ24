using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    public void btnReintentar() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void btnMenu() {
        SceneManager.LoadScene("MenuInicial");
    }

    public void btnSalir() {
        Application.Quit();
    }

}
