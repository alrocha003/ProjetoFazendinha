using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimento : MonoBehaviour
{
    private Rigidbody personagem;
    private Animator animacao;
    private float tempo;
    
	
	void Start ()
    {
        personagem = GetComponent<Rigidbody>();
        animacao = GetComponent<Animator>();
	}
	
    public void Mover(int velocidade)
    {
        if (GameControle.podeAndar)
        {
            Quaternion rotacao = new Quaternion();
            rotacao = personagem.rotation;
            float y = Input.GetAxisRaw("Horizontal");
            float x = Input.GetAxisRaw("Vertical");
            if (x == 0 && y == 0)
            {
                tempo += Time.deltaTime;
                animacao.SetFloat("Parado", tempo);
            }
            else
            {
                animacao.SetFloat("Parado", 0);
                tempo = 0;
            }
            animacao.SetFloat("PosX", Mathf.Abs(x));
            animacao.SetFloat("PosY", Mathf.Abs(y));
            personagem.velocity = new Vector3(velocidade * y, 0, velocidade * x);
            if (x > 0)
            {
                rotacao = Quaternion.Euler(0, 0, 0);
                if (y > 0)
                {
                    rotacao = Quaternion.Euler(0, 45, 0);
                }
                if (y < 0)
                {
                    rotacao = Quaternion.Euler(0, -45, 0);
                }

            }
            if (x < 0)
            {
                rotacao = Quaternion.Euler(0, 180, 0);
                if (y > 0)
                    rotacao = Quaternion.Euler(0, 135, 0);
                if (y < 0)
                    rotacao = Quaternion.Euler(0, 225, 0);

            }
            if (y != 0 && x == 0)
            {
                if (y > 0)
                    rotacao = Quaternion.Euler(0, 90, 0);
                if (y < 0)
                    rotacao = Quaternion.Euler(0, -90, 0);
            }
           transform.rotation = Quaternion.Slerp(personagem.rotation, rotacao, Time.deltaTime * velocidade);
        }
    }

}
