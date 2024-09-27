using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresente : MonoBehaviour
{
  //PP-Player Presente
    public float speedPP;
    public float runSpeedPP;
    public float inicialSpeedPP;

    private Rigidbody2D rb;
    private Vector2 _directionPP;
    private bool _isRunningPP;
    // private bool isRunningPP;

    public int objMao;//mostra qual objeto esta na mão dopersonagem

    public int contItensColetaveis;

    private bool _isMolhando;

    public DialogControl dialoqueControl;
    private NPC_Dialogue NPC_Dialogue;

    private PlayerItens playerItens;
    

    [SerializeField] private ParticleSystem poeira;
    public Vector2 direction //propriedade para que ocódigo usado para acessar de outro script o valor do _direction que está private
    {
        get { return _directionPP; }
        set { _directionPP = value; }
    }

    public bool isRunningPP
    {
        get { return _isRunningPP; } 
        set { _isRunningPP = value; }
    }
    public bool isMolhando
    {
        get { return _isMolhando; }
        set { _isMolhando = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicialSpeedPP = speedPP;
        poeira.GetComponent<ParticleSystem>();

        playerItens = GetComponent<PlayerItens>();

        contItensColetaveis = 0;
       // dialoqueControl = GetComponent<DialogControl>();

    }

    // Update is called once per frame
    // [System.Obsolete]
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {

           // Debug.Log("Mudou pro 1");
            objMao = 1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
           // Debug.Log("Mudou pro 2");
            objMao = 2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
           // Debug.Log("Mudou pro 3");
            objMao = 3;
        }

        if (playerItens.quantidadeFogoApagado == 2)
        {
            Debug.Log("Apagou tudo!");
        }

        OnInput();
        OnRun();
       // OnPlayerIsTalking();
        OnMolhando();
    }
    private void FixedUpdate()
    {
        onMove();
    }
    void OnMolhando()
    {
        if (objMao == 1 )
        {
            if (Input.GetMouseButtonDown(0) && playerItens.totalAgua > 0 && !dialoqueControl.isShowing)
            {
                
                isMolhando = true;
                speedPP = 0f;//para  o personagem ficar parado enquanto molha
               // if (isMolhando)
               // {
                    playerItens.totalAgua -= 1f;
                //}
            }
            if (Input.GetMouseButtonUp(0) || playerItens.totalAgua < 0)
            {
                isMolhando = false;
                speedPP =inicialSpeedPP; // pra ele voltar a andar
            }

            


        }
    }

    #region Coletaveis

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LIXO"))
        {
            Destroy(collision.gameObject);
            //contItensColetaveis++;
            playerItens.quantidadeLixoPego++;
        }
    }


    #endregion

    #region MovementPP
    void OnInput()
    {
        _directionPP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void onMove()
    {   
        if(dialoqueControl.isShowing == false) { 
        rb.MovePosition(rb.position + _directionPP * speedPP * Time.fixedDeltaTime);
        }
    }

    [System.Obsolete]
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (_directionPP.x >0 || _directionPP.x < 0 )  || Input.GetKeyDown(KeyCode.RightShift)) //quando apertar o Shift adiciona velocidade ao player
        {
            speedPP = runSpeedPP;
            isRunningPP = true;
            //CreateDust();
            
            poeira.Play();
            poeira.loop = true;
            
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))//quando  solta o Shift reduz velocidade ao player
        {
            speedPP = inicialSpeedPP;
            isRunningPP = false;
            poeira.Stop();
            poeira.loop = false;
            
            
        }
    }
    void OnPlayerIsTalking()
    {
        if(dialoqueControl.isShowing )
        {
            speedPP = 0f;

        }
        else
        {
            speedPP = inicialSpeedPP;
        }
        
    }
    #endregion
}
