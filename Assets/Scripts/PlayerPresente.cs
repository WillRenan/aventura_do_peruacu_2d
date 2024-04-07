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
    private bool isRunningPP;
    public Vector2 direction //propriedade para que ocódigo usado para acessar de outro script o valor do _direction que está private
    {
        get { return _directionPP; }
        set { _directionPP = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicialSpeedPP = speedPP;

    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        OnRun();
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
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) //quando apertar o Shift adiciona velocidade ao player
        {
            speedPP = runSpeedPP;
            isRunningPP = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))//quando  solta o Shift reduz velocidade ao player
        {
            speedPP = inicialSpeedPP;
            isRunningPP = false;
        }
    }
    #endregion
}
