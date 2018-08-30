using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitar : MonoBehaviour {
    private GameControle controle;
    public Vector3 posicaoPersonagem, posicaoCamera;
    private CanvasGroup fade; 
	// Use this for initialization
	void Start () {
        controle = FindObjectOfType(typeof(GameControle)) as GameControle;
        fade = GameObject.Find("FadeEffect").GetComponent<CanvasGroup>();
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(_transicao(other.gameObject));
    }

    IEnumerator _transicao(GameObject personagem)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / 5)
        {
            fade.alpha += i;
            yield return new WaitForEndOfFrame();
        }
        personagem.transform.position = posicaoPersonagem;
        Camera.main.transform.position = posicaoCamera;
        Camera.main.transform.rotation = Quaternion.Euler(15, 0, 0);
        for (float i = 0; i < 1; i += Time.deltaTime / 5)
        {
            fade.alpha -= i;
            yield return new WaitForEndOfFrame();
        }
    }
   
}
