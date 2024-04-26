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

    public DialogControl dialoqueControl;
    private NPC_Dialogue NPC_Dialogue;
    

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicialSpeedPP = speedPP;
        poeira.GetComponent<ParticleSystem>();

       // dialoqueControl = GetComponent<DialogControl>();

    }

    // Update is called once per frame
   // [System.Obsolete]
    void Update()
    {
        OnInput();
        OnRun();
        OnPlayerIsTalking();
    }
    private void FixedUpdate()
    {
        onMove();
    }
    #region MovementPP
     void OnInput()
    {
        _directionPP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void onMove()
    {
        rb.MovePosition(rb.position + _directionPP * speedPP * Time.fixedDeltaTime);
    }

    [System.Obsolete]
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (_directionPP.x >0 || _directionPP.x < 0)  || Input.GetKeyDown(KeyCode.RightShift)) //quando apertar o Shift adiciona velocidade ao player
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
        
    }
    #endregion
}
