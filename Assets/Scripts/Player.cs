using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    public float inicialSpeed;


    private Rigidbody2D rig;
    private Vector2 _direction;
    private bool _isRunning;

    private bool _isDash;
    public bool canDash;
    public float timeDash;

    public bool isDash //propriedade para que ocódigo usado para acessar de outro script o valor do _direction que está private
    {
        get { return _isDash; }
        set { _isDash = value; }
    }
    public bool isRunning //propriedade para que ocódigo usado para acessar de outro script o valor do _direction que está private
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public Vector2 direction //propriedade para que ocódigo usado para acessar de outro script o valor do _direction que está private
    {
        get { return _direction; }
        set { _direction = value; }
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        inicialSpeed = speed;
        canDash = true;
    }
    private void Update()
    {
        OnInput();
        OnRun ();
       // OnDash();
    }

    private void FixedUpdate()
    {
        OnMove();
    }
    //Reion cria uma região de código, e é possivel minimizar toda a região
    #region Movement 
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)  || Input.GetKeyDown(KeyCode.RightShift)) //quando apertar o Shift adiciona velocidade ao player
        {
            speed = runSpeed;
            isRunning = true;
        }
        if( Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))//quando  solta o Shift reduz velocidade ao player
        {
            speed = inicialSpeed;
            isRunning = false;
        }

    }
    void OnDash()
    {
        
        
            if (Input.GetMouseButtonDown(1) && canDash)
            {
                
                _isDash = true;
                timeDash -= Time.deltaTime;
                speed = runSpeed;
                if (timeDash <= 0)
                {
                    StopDash();
                }
            

            }
            if (Input.GetMouseButtonUp(1))
            {
                _isDash = false;
                StopDash(); 
                //speed = inicialSpeed;

            }
        
       
        
        
    }

    void StopDash()
    {
        timeDash = 0;
        canDash = true;
        timeDash = 0.4f;
        speed = inicialSpeed;

    }

    #endregion



}
