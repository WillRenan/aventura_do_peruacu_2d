using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public SpriteRenderer spriteBox;    

    // Start is called before the first frame update
    void Start()
    {
        spriteBox = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteBox.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteBox.enabled = false;
        }
    }
}
