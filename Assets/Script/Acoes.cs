using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoes : MonoBehaviour
{
    public List<Acao> acoes = new List<Acao>();
    private Inventario inventario;
    private GameControle controle;
    // Use this for initialization
    void Start()
    {
        inventario = FindObjectOfType(typeof(Inventario)) as Inventario;
        controle = FindObjectOfType(typeof(GameControle)) as GameControle;
        for (int i = 0; i < 4; i++)
        {
            if (acoes.Count < 4)
            {
                acoes.Add(new Acao());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interagir(int parametro)
    {
        if (acoes[parametro - 1].tipo == Acao.Acoes.Coletar)
        {
            inventario.Coletar(acoes[parametro - 1].paramentro, acoes[parametro - 1].coletavel, acoes[parametro - 1].parametro2);
            Destroy(gameObject);
        }
        if (acoes[parametro - 1].tipo == Acao.Acoes.Falar)
        {
            controle.id = acoes[parametro - 1].parametro2;
        }
    }
}
