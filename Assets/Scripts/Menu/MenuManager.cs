using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void BotonJugar()
    {
        SceneManager.LoadScene("Juego");
    }
    public void BotonOpciones()
    {
        SceneManager.LoadScene("menuOpciones");
    }

    // Update is called once per frame
    public void BotonSalir()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }
}
