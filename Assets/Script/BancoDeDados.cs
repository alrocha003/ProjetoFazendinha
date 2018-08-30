using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoDeDados : MonoBehaviour
{
    public List<Estrutura> ferramenta = new List<Estrutura>();
    public List<Planta> agricutaveis = new List<Planta>();
    public List<Estrutura> chaves = new List<Estrutura>();

    // Use this for initialization
}
[System.Serializable]
public class Planta : Estrutura
{
    public float[] TempoEtapasDeCrescimento;
}

[System.Serializable]
public class Estrutura
{
    public string nome;
    public int quantidade;
    public Sprite icone;
    public enum Tipo { Agricutavel, Ferramenta, Chave };
    public Tipo tipo;
    public Estrutura()
    {
        nome = "";
    }

}
