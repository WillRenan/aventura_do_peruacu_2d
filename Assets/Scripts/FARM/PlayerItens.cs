using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    public float totalAgua;

    public float limiteAgua = 20f;

    public int quantidadeFogoApagado = 0;
    public int quantidadeLixoPego = 0;

    void Update()
    {
        /*if (quantidadeFogoApagado == 2)
        {
            Debug.Log("Apagou tudo!");
        }*/
    }

    public void LimiteAgua(float agua)
    {
        if (totalAgua < limiteAgua)
        {
            totalAgua += agua;
            if (totalAgua > limiteAgua) 
            {
                totalAgua = limiteAgua; 
            }
        }
    }


    public void ResetItens()
    {
        quantidadeFogoApagado = 0;
        quantidadeLixoPego = 0;
    }
}
