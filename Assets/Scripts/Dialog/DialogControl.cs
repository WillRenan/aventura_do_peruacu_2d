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
    public bool isShowing; //para saber se a janela do dialogo está ativa ou não
    public int index; // quantidade de texto que tem uma fala


    public string[] sentence;

    public static DialogControl instance;

    /*public bool showing
    {
        get{ return isShowing; }
        set { isShowing = value; }
    }*/

    private void Awake() //é chamado primiero, antes de todos os outros métodos na hierasquia de scripts
    {
        instance = this;
    }


    // é chamado ao iniciar
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typesentence()
    {
      // actorNameText.text = " oi";
        foreach (char letter in sentence[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //pula para a proxima fala
    public void NextSentence()
    {
        if(speechText.text == sentence[index]) //verifica se a frase é a está completa, para que  só funcione se a frase toda foi dita.
        {
            if(index < sentence.Length - 1) //verificando se as frases acabaram
            {
                index++; //Incrementa para mudar de frases
                speechText.text = "";
                //actorNameText.text = "teste";
                StartCoroutine(Typesentence());
            }
            else //executa quando as fases estiveram acabado
            {
                OnCleanDialogue();
            }
        }
    }
    public void OnCleanDialogue()
    {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        sentence = null;
        isShowing = false;
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
