using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacaoTelas : MonoBehaviour
{
    public Transform pauseMenu;
    public Transform fimJogo;
    // Start is called before the first frame update
    private PlayerItens playerItens;
    public GameObject playerPresente;

    //public GameObject playerPresente; // Arraste o objeto "PlayerPresente" aqui no Inspector
    public Vector3 posicaoInicial; // Defina a posição inicial aqui no Inspector

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
    }
    void Start()
    {
    // playerPresente = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerItens.quantidadeFogoApagado == 10 && playerItens.quantidadeLixoPego == 12)
        {
            //playerPresente.transform.position = posicaoInicial;
            //playerItens.ResetItens();
            fimJogo.gameObject.SetActive(true);

            //SceneManager.LoadScene("FimDoJogo");

        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.gameObject.activeSelf) {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                
            }

        }
    }
     public void BntVoltar()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void BtnMenu()
    {
       
        Time.timeScale = 1;
        //ResetarPosicao();
        playerPresente.transform.position = posicaoInicial;
        playerItens.ResetItens();
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Sair()
    {

        Application.Quit();
        Time.timeScale = 1;
    }
    
    void ResetarPosicao()
    {
        playerPresente.transform.position = posicaoInicial;
    }


}
