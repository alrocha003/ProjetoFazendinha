using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour {
    public List<Estrutura> agricutaveis = new List<Estrutura>();
    public List<Estrutura> ferramentas = new List<Estrutura>();
    public List<Estrutura> chaves = new List<Estrutura>();
    private BancoDeDados controle;
    public Transform iAgriculas, iFerramentas, iChaves;
    GameObject currentGameObject;
	// Use this for initialization
	void Start () {
        controle = FindObjectOfType(typeof(BancoDeDados)) as BancoDeDados;
        for(int i = 0; i < iAgriculas.GetChild(0).childCount; i++)
        {
            if (iAgriculas.GetChild(0).GetChild(i).gameObject.activeSelf)
            {
                agricutaveis.Add(new Estrutura());
            }
        }
        for (int i = 0; i < iFerramentas.GetChild(0).childCount; i++)
        {
            if (iFerramentas.GetChild(0).GetChild(i).gameObject.activeSelf)
            {
                ferramentas.Add(new Estrutura());
            }
        }
        for (int i = 0; i < iChaves.GetChild(0).childCount; i++)
        {
            if (iChaves.GetChild(0).GetChild(i).gameObject.activeSelf)
            {
                chaves.Add(new Estrutura());
            }
        }
      
    }

    // Update is called once per frame
    void Update () {
     
      TrocaDeAbas();

    }
    public void Coletar(string _nome,Estrutura.Tipo _tipo, int _quant)
    {
     if(_tipo == Estrutura.Tipo.Agricutavel)
        {
            for(int i = 0; i < agricutaveis.Count; i++)
            {
                if(agricutaveis[i].nome == _nome)
                {
                    agricutaveis[i].quantidade+= _quant;
                    iAgriculas.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = agricutaveis[i].quantidade.ToString();
                    return;
                }
            }
            for(int i = 0; i < agricutaveis.Count; i++)
            {
                if(agricutaveis[i].nome == "")
                {
                    for(int j = 0; j < controle.agricutaveis.Count; j++)
                    {
                        if(controle.agricutaveis[j].nome == _nome)
                        {
                            agricutaveis[i] = controle.agricutaveis[j];
                            iAgriculas.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite = controle.agricutaveis[j].icone;
                            iAgriculas.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;
                            agricutaveis[i].quantidade += _quant;
                            if (agricutaveis[i].quantidade>1)
                            {
                                iAgriculas.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = agricutaveis[i].quantidade.ToString();
                            }

                            return;
                        }
                    }
                }
            }
        }
        if (_tipo == Estrutura.Tipo.Ferramenta)
        {
            for (int i = 0; i < ferramentas.Count; i++)
            {
                if (ferramentas[i].nome == _nome)
                {
                    ferramentas[i].quantidade+= _quant;
                    iFerramentas.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = ferramentas[i].quantidade.ToString();
                    return;
                }
            }
            for (int i = 0; i < ferramentas.Count; i++)
            {
                if (ferramentas[i].nome == "")
                {
                    for (int j = 0; j < controle.ferramenta.Count; j++)
                    {
                        if (controle.ferramenta[j].nome == _nome)
                        {
                            ferramentas[i] = controle.ferramenta[j];
                            iFerramentas.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite = controle.ferramenta[j].icone;
                            iFerramentas.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;
                            ferramentas[i].quantidade += _quant;
                            if (ferramentas[i].quantidade > 1)
                            {
                                iFerramentas.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = ferramentas[i].quantidade.ToString();
                            }

                            return;
                        }
                    }
                }
            }
        }
        if (_tipo == Estrutura.Tipo.Chave)
        {
            for (int i = 0; i < chaves.Count; i++)
            {
                if (chaves[i].nome == _nome)
                {
                    chaves[i].quantidade+=_quant;
                    iChaves.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = chaves[i].quantidade.ToString();
                    return;
                }
            }
            for (int i = 0; i < chaves.Count; i++)
            {
                if (chaves[i].nome == "")
                {
                    for (int j = 0; j < chaves.Count; j++)
                    {
                        if (controle.chaves[j].nome == _nome)
                        {
                            chaves[i] = controle.chaves[j];
                            iChaves.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite = controle.chaves[j].icone;
                            iChaves.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().enabled = true;
                            chaves[i].quantidade += _quant;
                            if (chaves[i].quantidade > 1)
                            {
                                iChaves.GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = chaves[i].quantidade.ToString();
                            }

                            return;
                        }
                    }
                }
            }
        }


    }
   
    void TrocaDeAbas()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(currentGameObject);
        }
        else
        {
            currentGameObject = EventSystem.current.currentSelectedGameObject;
        }
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Chaves":
                iChaves.transform.SetAsLastSibling();
                break;
            case "Agricolas":
                iAgriculas.transform.SetAsLastSibling();
                break;
            case "Ferramentas":
                iFerramentas.transform.SetAsLastSibling();
                break;
        }
    }
}


