using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour {
    public int dias, horas;
    public float minutos, tempoemMinutos;
    public enum Estacoes {Primavera, Verão, Outono, Inverno };
    public Estacoes estacoes;
    public bool tempo;
	// Use this for initialization

    public void Tempo()
    {
        minutos += (minutos > 59.99f) ? -minutos:(tempo)?Time.deltaTime*10:0;
        horas += (minutos > 59.99f) ? (horas > 23) ? Valor(): 1:0;
        tempoemMinutos += Time.deltaTime*10;
    }
    private int Valor()
    {
        dias++;
        if (dias % 90    == 0){
            switch (estacoes){
                case Estacoes.Primavera:
                    estacoes = Estacoes.Verão;
                    break;
                case Estacoes.Verão:
                    estacoes = Estacoes.Outono;
                    break;
                case Estacoes.Outono:
                    estacoes = Estacoes.Inverno;
                    break;
                case Estacoes.Inverno:
                    estacoes = Estacoes.Primavera;
                    break;
            }
        }
        return -horas;
    }
}
