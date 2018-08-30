using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCam : MonoBehaviour {
    public Vector3 posicao,rotacao;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Camera.main.transform.position = posicao;
        Camera.main.transform.rotation = Quaternion.Euler(rotacao);
        
    }
}
