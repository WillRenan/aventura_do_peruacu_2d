using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniPresente : MonoBehaviour
{
    private PlayerPresente playerPresente;
    private Animator animPresente;

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


        // fly
        if(playerPresente.direction.x > 0 )
        {
            playerPresente.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (playerPresente.direction.x < 0)
        {
            playerPresente.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }
    #endregion
}
