using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Interacao : MonoBehaviour {
    // Use this for initialization
    public LayerMask camada;
    private GameObject objeto;
    public Transform opcoes;
 

    public void Detectar(int parametro)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,5,camada);
        if (hit.collider != null)
        {
            objeto = hit.collider.gameObject;
            if (opcoes.childCount == 0)
            {
                for (int i = 0; i < objeto.GetComponent<Acoes>().acoes.Count; i++)
                {
                    if(objeto.GetComponent<Acoes>().acoes[i].tipo != Acao.Acoes.vazio)
                    {
                        if(objeto.GetComponent<Acoes>().acoes[i].tipo == Acao.Acoes.Falar)
                        {
                            GameControle.PodeFalar = true;
                        }
                        GameObject botao = Instantiate(Resources.Load<GameObject>("Prefabs/Alternativa"), opcoes);
                        botao.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = objeto.GetComponent<Acoes>().acoes[i].tipo.ToString();
                    }
              
                }
            }
            if (parametro != 0)
            {
                hit.collider.SendMessage("Interagir", parametro, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            objeto = null;
            GameControle.PodeFalar = false;

            for (int i =0;i<opcoes.childCount;i++)
            {
                Destroy(opcoes.GetChild(i).gameObject);
            }
        }

        
    }
    
}
[System.Serializable]
public class Acao    
{
    public enum Acoes {Coletar,Falar,Minerar,Cortar,vazio}
    public Acoes tipo;
    private Inventario inventario;
    [Header("Valores")]
    public string paramentro;
    public int parametro2;
    public Estrutura.Tipo coletavel;
    public Acao()
    {
        tipo = Acoes.vazio;
    }
  
}
