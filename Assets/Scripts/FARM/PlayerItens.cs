using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    public float totalAgua;

    public float limiteAgua = 50f;

    public int quantidadeFogoApagado = 0;

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
        }
    }
}
