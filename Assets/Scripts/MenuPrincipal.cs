using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jogar()
    {
        SceneManager.LoadScene("Presente");
    }

    public void Sair()
    {

        Application.Quit();
    }

    
}
