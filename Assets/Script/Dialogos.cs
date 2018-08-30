using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dialogos : MonoBehaviour
{
    public Image personagemA, personagemB, fundo;
    public Transform respostaA, respostaB;
    public TextMeshProUGUI texto, nomeA, nomeB;
    public List<Texto> dialogos = new List<Texto>();
    private bool avancar;
    private List<string> lista = new List<string>();
    private int id = 0;
    private GameControle controle;


    private void Start()
    {
        avancar = true;
    }
    private void Update()
    {


    }
    public void Dialogar(int id)
    {
        GameControle.podeAndar = false;
        if (dialogos[id].ativado)
        {
            id = this.id;
            if (dialogos[id].alt)
            {
                string[] separador = new string[] { "*" };
                string[] t = dialogos[id].alternativo.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);

                lista = new List<string>(t);

                if (avancar)
                {
                    StartCoroutine("_dialogo", id);

                }

            }
            else
            {
                string[] separador = new string[] { "*" };
                string[] t = dialogos[id].principal.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);

                lista = new List<string>(t);

                if (avancar)
                {
                    StartCoroutine("_dialogo", id);

                }

            }

        }
    }
    public void Alter(int n)
    {
        if (n == 1)
        {
            string[] separador = new string[] { "*" };
            string[] t = dialogos[id].alternativo.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);
            lista = new List<string>(t);
            dialogos[id].alt = true;
            dialogos[id].contador = 0;
        }
        respostaA.GetComponent<Image>().enabled = false;
        respostaB.GetComponent<Image>().enabled = false;
        respostaA.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        respostaB.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        EventSystem.current.SetSelectedGameObject(GameObject.Find("First").gameObject);

        StartCoroutine("_dialogo", id);

    }



    IEnumerator _dialogo(int _id)
    {
        dialogos[id].ativado = false;
        if (dialogos[id].contador == lista.Count)
        {
            fundo.color = new Color(fundo.color.r, fundo.color.g, fundo.color.b, 0);
            personagemA.color = new Color(personagemA.color.r, personagemA.color.g, personagemA.color.b, 0);
            personagemB.color = new Color(personagemB.color.r, personagemB.color.g, personagemB.color.b, 0);
            texto.text = "";
            nomeA.text = "";
            nomeB.text = "";
            if (dialogos[_id].repetir)
            {

                dialogos[id].alt = false;
                dialogos[id].contador = 0;
            }
            else
            {
                dialogos[id].contador--;
            }
            dialogos[id].ativado = true;
            GameControle.podeAndar = true;
            yield break;

        }
        fundo.color = new Color(fundo.color.r, fundo.color.g, fundo.color.b, 1);
        if (lista[dialogos[id].contador].StartsWith("A"))
        {
            personagemA.color = new Color(personagemA.color.r, personagemA.color.g, personagemA.color.b, 1);
            personagemB.color = new Color(personagemB.color.r, personagemB.color.g, personagemB.color.b, 0);
            nomeA.text = dialogos[_id].personagemA;
            nomeB.text = "";
        }
        else
        {
            personagemB.color = new Color(personagemB.color.r, personagemB.color.g, personagemB.color.b, 1);
            personagemA.color = new Color(personagemA.color.r, personagemA.color.g, personagemA.color.b, 0);
            nomeB.text = dialogos[_id].personagemB;
            nomeA.text = "";
        }
        for (float i = 2; i < lista[dialogos[id].contador].Length - 1; i += Time.deltaTime * 10)
        {
            texto.text = lista[dialogos[id].contador].Substring(2, Mathf.FloorToInt(i));
            yield return null;
        }
        if (lista[dialogos[id].contador].EndsWith("?"))
        {
            char[] separador = new char[] { '.' };
            string[] r = dialogos[_id].respostas.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);
            respostaA.GetComponent<Image>().enabled = true;
            respostaB.GetComponent<Image>().enabled = true;
            respostaA.GetChild(0).GetComponent<TextMeshProUGUI>().text = r[0];
            respostaB.GetChild(0).GetComponent<TextMeshProUGUI>().text = r[1];
            EventSystem.current.SetSelectedGameObject(respostaA.gameObject);
            dialogos[id].ativado = false;
            dialogos[id].contador++;
            yield break;

        }
        dialogos[id].contador++;
        dialogos[id].ativado = true;
    }
}
[System.Serializable]
public class Texto
{

    public string personagemA, personagemB;
    [TextArea]
    [Tooltip("Utilize os códigos *A e *B para definir os personagens")]
    public string principal, alternativo;
    public string respostas;
    public Image iconeA, iconeB;
    public bool repetir, alt, ativado;
    public int contador;
    public Texto(string A, string B)
    {
        personagemA = A;
        personagemB = B;
    }

}

