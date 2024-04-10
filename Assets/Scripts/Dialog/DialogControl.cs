using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour


{


    [Header("Components")]
    public GameObject dialogueObj; //objet janela do dialog
    public Image profileSprite; //sprite perfil do personagem 
    public Text speechText; //texto da fala 
    public Text actorNameText; //nome do personagem 


    [Header("Setings")]
    public float typingSpeed; //velociadade da fala

    // variaveis de controle
    private bool isShowing; //para saber se a janela do dialogo está ativa ou não
    private int index; // quantidade de texto que tem uma fala

    private string[] sentence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typesentence()
    {
        foreach (char letter in sentence[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //pula para a proxima fala
    public void NextSentence()
    {

    }

    //chamra a fala do npc
    public void Speach(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentence = txt;
            StartCoroutine(Typesentence());
            isShowing = true;

        }
    }



}
