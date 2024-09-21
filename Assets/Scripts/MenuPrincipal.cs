using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Transform painelSobre;
    public Transform painelHistoria;
    // Start is called before the first frame update
    public void Jogar()
    {
        SceneManager.LoadScene("Presente");
    }
    public void Historia()
    {
        painelHistoria.gameObject.SetActive(true);
    }
    public void Sair()
    {

        Application.Quit();
    }

    public void SobreBtn()
    {
        painelSobre.gameObject.SetActive(true);
    }public void VoltarBtn()
    {
        painelSobre.gameObject.SetActive(false);
        painelHistoria.gameObject.SetActive(false);
    }
}
