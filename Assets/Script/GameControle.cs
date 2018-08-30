using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControle : MonoBehaviour
{
    static public bool PodeFalar,podeAndar;
    private float tempo;
    public CanvasGroup fade;
    private TimeSystem temposystem;
    public CanvasGroup inventario;
    private Interacao interacao;
    private int parametro;
    public int id;
    private Dialogos dialogo;
    private QuickMenu quickMenu;
    private Inventario inventarioSeletor;
    [Header("Mapiamento de teclado")]
    public KeyCode menu;
    public KeyCode menuRapidoCima;
    public KeyCode menuRapidoBaixo;
    public KeyCode interagir1;
    public KeyCode interagir2;
    public KeyCode interagir3;
    public KeyCode interagir4;
    public KeyCode texto;
    

    private void Start()
    {
        temposystem = FindObjectOfType(typeof(TimeSystem)) as TimeSystem;
        interacao = FindObjectOfType(typeof(Interacao)) as Interacao;
        quickMenu = FindObjectOfType(typeof(QuickMenu)) as QuickMenu;
        inventarioSeletor = FindObjectOfType(typeof(Inventario)) as Inventario;
        dialogo = FindObjectOfType(typeof(Dialogos)) as Dialogos;
        podeAndar = true;
    }
    private void Update()
    {
    
        tempo += Time.deltaTime;
        if (tempo > 3)
        {
            quickMenu.animacao.SetBool("Aberto", false);
        }

        if (Input.GetKeyDown(interagir1))
        {
            parametro = 1;
        }
     
        if (Input.GetKeyDown(interagir2))
        {
            parametro = 2;
        }
       
        if (Input.GetKeyDown(interagir3))
        {
            parametro = 3;
        }
      
        if (Input.GetKeyDown(interagir4))
        {
            parametro = 4;
        }
        if (Input.GetKeyDown(texto) && PodeFalar)
        {
            dialogo.Dialogar(id);
        }
       
        interacao.Detectar(parametro);
        parametro = 0;
        if (Input.GetKeyDown(menu))
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find("First").gameObject);
            inventario.alpha = (inventario.alpha==0)?1:0;
            podeAndar = (inventario.alpha == 0) ? true : false;

        }
        if (Input.GetKeyDown(menuRapidoBaixo))
        {
            quickMenu.Down();
            quickMenu.animacao.SetBool("Ativo",true);
            quickMenu.animacao.SetBool("Aberto", true);
            tempo = 0;
        }
        if (Input.GetKeyDown(menuRapidoCima))
        {
            quickMenu.Up();
            quickMenu.animacao.SetBool("Ativo", true);
            quickMenu.animacao.SetBool("Aberto", true);
            tempo = 0;
        }
    }
    public void FadeIn()
    {
        StartCoroutine(_fadein());
    }
    public void FadeOut()
    {
        StartCoroutine(_fadeout());
    }
    IEnumerator _fadein()
    {
        for(float i = 0; i < 1; i += Time.deltaTime/5)
        {
            fade.alpha += i;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator _fadeout()
    {
        for (float i = 0; i < 1; i += Time.deltaTime/5)
        {
            fade.alpha -= i;
            yield return new WaitForEndOfFrame();
        }
    }
}
