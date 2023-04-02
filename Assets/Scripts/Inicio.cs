using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickGame()
    {
        SceneManager.LoadScene("scena1");
    }

    public void ClickMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Ganador()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
