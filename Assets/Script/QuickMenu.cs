using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickMenu : MonoBehaviour {
    private RectTransform segundo;
    private Inventario inventario;
    public Animator animacao;
    public List<Estrutura> itens = new List<Estrutura>();
    // Use this for initialization
    void Start () {
        inventario = FindObjectOfType(typeof(Inventario)) as Inventario;
        animacao = transform.parent.GetComponent<Animator>();

    }

    // Update is called once per frame
   
     private void TrocarPosicao()
    {
        if(itens.Count ==0)
        {
            for (int i = 0; i < inventario.agricutaveis.Count; i++)
            {
                if (inventario.agricutaveis[i].nome != "")
                {
                    itens.Add(inventario.agricutaveis[i]);
                }
            }
            for (int i = 0; i < inventario.ferramentas.Count; i++)
            {
                if (inventario.ferramentas[i].nome != "")
                {
                    itens.Add(inventario.ferramentas[i]);
                }
            }
            for(int i = 0; i < itens.Count; i++)
            {
                if(itens.Count >= 4)
                {
                    GameObject iten = Instantiate(Resources.Load<GameObject>("Prefabs/Slot"), transform);
                    iten.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = itens[i].icone;
                    iten.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;

                }
                else {
                    transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = itens[i].icone;
                    transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;

                }
            }
          
        }
    

    }
    public void Up()
    {
        TrocarPosicao();
        if (segundo != null)
        {
            segundo.sizeDelta = new Vector2(100, 100);
        }
        segundo = transform.GetChild(2).GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(transform.GetChild(2).gameObject);
        segundo.sizeDelta = new Vector2(120, 120);
        transform.GetChild(0).SetAsLastSibling();
    }
    public void Down()
    {
        TrocarPosicao();
        if (segundo != null)
        {
            segundo.sizeDelta = new Vector2(100, 100);
        }
        segundo = transform.GetChild(0).GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject);
        segundo.sizeDelta = new Vector2(120, 120);
        transform.GetChild(2).SetAsFirstSibling();
    }

}
