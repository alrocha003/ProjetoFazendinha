using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaScript : MonoBehaviour {
    private TimeSystem tempo;
    public float Germinado;
    private BancoDeDados banco;
    private float[] etapas = new float[] { 60, 60, 60 };
    private int contador;
    
	// Use this for initialization
	void Awake () {
        tempo = FindObjectOfType(typeof(TimeSystem)) as TimeSystem;
	}
	
	// Update is called once per frame
	void Update () {
        if (tempo.tempoemMinutos > Germinado+etapas[contador])
        {
            for(int i= 0; i < transform.childCount; i++)
            {
                if(i == transform.childCount - 1)
                {
                    Destroy(gameObject);
                    break;
                }
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                    transform.GetChild(i+1).gameObject.SetActive(true);
                    Germinado += etapas[contador];
                    contador++;
                    break;
                }
            }
        }
		
	}
    private void OnEnable()
    {
        Germinado = tempo.tempoemMinutos;
    }
}
