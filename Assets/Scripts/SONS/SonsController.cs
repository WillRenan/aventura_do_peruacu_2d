using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsController : MonoBehaviour
{

    public AudioSource fogoAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        fogoAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (fogoAudio.CompareTag("Player"))
        {
            fogoAudio.Play();
        }
    }



}
