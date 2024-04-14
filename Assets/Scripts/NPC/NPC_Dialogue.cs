using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange; //distancia de alcance para que seja identificado o player
    public LayerMask playerLayer; //pega todas as layers

    public DialogoConfig dialogue;    
    public DialogControl dialogueControl;
    public bool playerHit;

    private List<string> sentences = new List<string>();    

    
    
    // Start is called before the first frame update
    void Start()
    {
        GetTextNPCInfo();
    }
    private void Update()//chamado a cada frame
    {
        if( Input.GetKeyDown(KeyCode.E) && playerHit == true) { //verifica se o jogado está dentro do espaço de conversa e se ele aperta a letra E
            DialogControl.instance.Speach(sentences.ToArray());
        }
    }
    void GetTextNPCInfo()
    {
        for(int i = 0; i< dialogue.dialogos.Count; i++)
        {
            sentences.Add(dialogue.dialogos[i].sentence.portugues);
        }
    }

    // 
    void FixedUpdate() //usado pela física
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            //Debug.Log("Pegou");
            playerHit = true;
        }
        else
        {

            // Debug.Log("saiu");
            playerHit = false;
          // DialogControl.instance.dialogueObj.SetActive(false); //desativando janela de dialogo
          // DialogControl.instance.dialogueObj.SetActive(false); //desativando janela de dialogo


        }

    }
    private void OnDrawGizmosSelected() //desenha o gizmo ao redor do npc, gizmos é como se fosse um icone
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
      
    }

}
