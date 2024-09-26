using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    

    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite fogo;
    [SerializeField] private Sprite madeiraQueimada;
    [SerializeField] private float vidaFogo = 10f;
    [SerializeField] private CircleCollider2D boxCollider;

    private PlayerItens playerItens;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<CircleCollider2D>();
        playerItens = FindObjectOfType<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit()
    {
        vidaFogo -= 1f;
       
        //Debug.Log("deminuiu");
        if (vidaFogo < 0f) 
        {
            
            spriteRender.sprite = madeiraQueimada; //SUBSTITUI O SPRITE DE FOGO PELO DE MADEIRA QUEIMADA

            playerItens.quantidadeFogoApagado += 1;
           boxCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AguaCol")) {
            OnHit();
        }
    }


}
