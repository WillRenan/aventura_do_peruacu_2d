using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="Novo Dálogo",menuName ="Novo Diálogo/Dialogo")]
public class DialogoConfig : ScriptableObject
{
    [Header("Configurações")]
    public GameObject actor;

    [Header("Diálogo")]
    public Sprite speakActorSprite;//foto do falante
    public string sentence; //texto do dialogo

    public List<Sentences> dialogos = new List<Sentences>(); //lista de dialogos

}
[System.Serializable] //para aparecer no inspector da unity
public class Sentences
{
    public string actorName;//nome do falante
    public Sprite profile;//foto de perfil
    public Languages sentence; //saber linguagems
}
[System.Serializable]
public class Languages{
    public string portugues;
    public string english;
}

//Criar botãao na interface na unity
#if UNITY_EDITOR //só irá ser executado quando a unity estiver aberte em modo de edição
[CustomEditor(typeof(DialogoConfig))]
public class BuildEditos : Editor
{
    public override void OnInspectorGUI() // usando o override para sobrescrever um método padrão da unity
    {
        DrawDefaultInspector();
        DialogoConfig df = (DialogoConfig)target; //criando objetos

        Languages l = new Languages();//criando objetos
        l.portugues = df.sentence;

        

        Sentences s = new Sentences();//criando objetos
        s.profile = df.speakActorSprite;
        s.sentence = l;
        //s.actorName = df.actor.name;

        if(GUILayout.Button("Create Dialogue")) //quando clica no botão add a fala
        {
            if(df.sentence != "") //verificando se tem algo esqcrito ou não 
            {
                df.dialogos.Add(s); //Adicioando  à lista de dialogos

                df.speakActorSprite = null;  //reseteando
                df.sentence = "";//reseteando
            }
        }

    }
}

#endif