using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGUA : MonoBehaviour
{
    [SerializeField] private bool detectaPlayer;
    [SerializeField] private int valorAgua;
    private PlayerItens player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectaPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.LimiteAgua(valorAgua);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            detectaPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            detectaPlayer = false;
        }
    }
}
