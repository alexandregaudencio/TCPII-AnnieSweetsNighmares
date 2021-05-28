using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{

    public GameObject Jogador;
    public GameObject botao;
    public KeyCode TeclaAbrir = KeyCode.E;
    public float giroAtual, giroAlvo;
    public int tempoDeVolta;
    Vector3 rotacaoInicial;
    float velocidade;


    [Range(0.0f, 150.0f)] public float grausDeGiro = 90.0f;
    public float velocidadeDeGiro = 30, distanciaAtivacao = 3;


    public enum EstadoInic { Aberta90, Fechada00 };
    public EstadoInic EstadoInicial = EstadoInic.Fechada00;

    public enum Bater { ir, voltar };
    public Bater Rotacao = Bater.ir;


    float seg = 10;
    float segAtual = 0;



    // Start is called before the first frame update
    void Start()
    {
        giroAtual = 0.0f;

        rotacaoInicial = transform.eulerAngles;





    }

    // Update is called once per frame
    void Update()
    {
        ControlarPorta();
        Ativar();

        seg += Time.deltaTime;

        if (segAtual + tempoDeVolta < seg)
        {
            giroAlvo = 0.0f;
        }

    }

    void ControlarPorta()
    {
        Vector3 localDeChecagem;
        if (Jogador != null)
        {
            localDeChecagem = Jogador.transform.position;
        }
        else
        {
            localDeChecagem = transform.position;
        }
        if (Vector3.Distance(botao.transform.position, localDeChecagem) < distanciaAtivacao)
        {
            if (giroAtual < 1.0f && Input.GetKeyDown(TeclaAbrir))
            {
                giroAlvo = grausDeGiro;
                segAtual = seg;

            }


        }
        giroAtual = Mathf.MoveTowards(giroAtual, giroAlvo, velocidadeDeGiro * Time.deltaTime);


    }



    void Ativar()
    {
        switch (Rotacao)
        {
            case Bater.ir:
                this.transform.eulerAngles = new Vector3(rotacaoInicial.x + giroAtual, rotacaoInicial.y, rotacaoInicial.z);
                break;
            case Bater.voltar:
                this.transform.eulerAngles = new Vector3(rotacaoInicial.x - giroAtual, rotacaoInicial.y, rotacaoInicial.z);
                break;
        }
    }
}
