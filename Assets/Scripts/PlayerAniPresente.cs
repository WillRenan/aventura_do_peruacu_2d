using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniPresente : MonoBehaviour
{
    private PlayerPresente playerPresente;
    private Animator animPresente;

    private DialogControl dialogControl;


    

    private void Awake()
    {
        dialogControl = FindObjectOfType<DialogControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPresente = GetComponent<PlayerPresente>();    
        animPresente = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       

        onMove();
        OnRun();    
    }
    #region Monimentacao
    void onMove()
    {
        if( playerPresente.direction.sqrMagnitude >0 )
        {
            animPresente.SetInteger("transicao",1);
        }
        else
        {
            animPresente.SetInteger("transicao", 0);
        }

        if (playerPresente.isMolhando && !dialogControl.isShowing )  //molhando
        {
            animPresente.SetInteger("transicao", 3);
        }

        // fly
        if (playerPresente.direction.x > 0 )
        {
            playerPresente.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (playerPresente.direction.x < 0)
        {
            playerPresente.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }
    void OnRun()
    {
        if(playerPresente.isRunningPP && 
            (playerPresente.direction.x > 0 || playerPresente.direction.x<0
          || playerPresente.direction.y >0 || playerPresente.direction.y<0 ))
        {
           // Debug.Log("oi");
            animPresente.SetInteger("transicao",2);
            

        }
    }

   
    #endregion
}
