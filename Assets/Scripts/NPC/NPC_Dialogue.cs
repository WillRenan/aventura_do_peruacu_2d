using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange; //distancia de alcance para que seja identificado o player
    public LayerMask playerLayer; //pega todas as layers
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            Debug.Log("Pegou");
        }
        else
        {

        }

    }
    private void OnDrawGizmosSelected() //desenha o gizmo ao redor do npc, gizmos é como se fosse um icone
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
      
    }

}
