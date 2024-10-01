using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsLixoColetado : MonoBehaviour
{

    public AudioSource somLixo;
    // Start is called before the first frame update
    void Start()
    {
        somLixo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LIXO")) { 
        
            somLixo.Play();
        }

    }

}
