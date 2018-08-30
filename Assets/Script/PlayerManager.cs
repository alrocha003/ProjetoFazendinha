using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private Movimento movimento;
    public int velocidade;
	// Use this for initialization
	void Start () {
        movimento = FindObjectOfType(typeof(Movimento)) as Movimento;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movimento.Mover(velocidade);
	}
}
