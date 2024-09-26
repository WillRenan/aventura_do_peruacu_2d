using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Image aguaUI;
    public Text lixoUI;
    public Text fogoUI;
    public string contLixo;
    //mudando color da seleção
    public   GameObject selecaoBalde; //Cria uma  variavel do tipo gameobject para podermo ter acesso aos componente dele
    public   GameObject selecaoMao; //Cria uma  variavel do tipo gameobject para podermo ter acesso aos componente dele

    private Image imagemSelecaoBalde ;
    private Image imagemSelecaoMao ;

    Color novaCor = new Color(255f / 255f, 136f / 255f, 0f / 255f, 255f / 255f);
    

    private PlayerItens playerItens;
    private PlayerPresente  playerPresente;

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        playerPresente = FindObjectOfType<PlayerPresente>();
    }

    // Start is called before the first frame update
    void Start()
    {
        aguaUI.fillAmount = 0f;
        
        imagemSelecaoBalde = selecaoBalde.GetComponent<Image>();
        imagemSelecaoMao = selecaoMao.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        contLixo = playerItens.quantidadeLixoPego.ToString();
        lixoUI.text = contLixo;
        fogoUI.text = playerItens.quantidadeFogoApagado.ToString();
        aguaUI.fillAmount = playerItens.totalAgua/playerItens.limiteAgua;


       /* switch (playerPresente.objMao)
        {
            case 1:
                // Se o jogador estiver segurando algo na mão (1), a cor será a novaCor
                imagemSelecaoBalde.color = novaCor;
                imagemSelecaoMao.color = Color.white;
                break;
            case 2:
                // Se o jogador estiver segurando algo diferente (2), a cor será outra
               // Color corVermelha = Color.red;
                imagemSelecaoMao.color = novaCor;
                imagemSelecaoBal.color = Color.white;
                break;
            default:
                // Se nenhuma das condições acima for verdadeira, a cor será branca
                imagemSelecaoBalde.color = Color.white;
                break;
        }*/

        if (playerPresente.objMao == 1) {
            imagemSelecaoBalde.color = novaCor;

        }
        else
        {
            imagemSelecaoBalde.color = Color.white;
        }
        if (playerPresente.objMao == 2) {
            imagemSelecaoMao.color = novaCor;

        }
        else
        {
            imagemSelecaoMao.color = Color.white;
        }
        


    }
}
