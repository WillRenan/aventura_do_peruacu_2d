using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Image aguaUI;
    public Text lixoUI;
    [SerializeField] private Text fogoUI;
    public string contLixo;

    private PlayerItens playerItens;

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
    }

    // Start is called before the first frame update
    void Start()
    {
        aguaUI.fillAmount = 0f;
        

    }

    // Update is called once per frame
    void Update()
    {
        contLixo = playerItens.quantidadeLixoPego.ToString();
        lixoUI.text = contLixo;
        fogoUI.text = playerItens.quantidadeFogoApagado.ToString();
        aguaUI.fillAmount = playerItens.totalAgua/playerItens.limiteAgua;
    }
}
