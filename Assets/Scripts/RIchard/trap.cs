using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{

    private GameObject Jogador;
    public KeyCode teclaPlayer;
    public GameObject botao;
    public KeyCode TeclaAbrir = KeyCode.E;

    public KeyCode usar;
    public float giroAtual, giroAlvo;
    public int tempoDeVolta;
    Vector3 rotacaoInicial;
    float velocidade;
    private GameObject mao;
    private GameObject chave;


    [Range(0.0f, 150.0f)] public float grausDeGiro = 90.0f;
    public float velocidadeDeGiro = 30, distanciaAtivacao = 3;


    public enum EstadoInic { Aberta90, Fechada00 };
    public EstadoInic EstadoInicial = EstadoInic.Fechada00;

    public enum Bater { ir, voltar };
    public Bater Rotacao = Bater.ir;


    float seg = 10;
    float segAtual = 0;

    private bool ativo, temBotao;


    // Start is called before the first frame update
    void Start()
    {
        giroAtual = 0.0f;

        rotacaoInicial = transform.eulerAngles;

        ativo = false;
        temBotao = false;


    }

    // Update is called once per frame
    void Update()
    {
        temBotao = botao.GetComponent<Botao>().gastarChave;
        ativo = botao.GetComponent<Botao>().ativou;
        teclaPlayer = botao.GetComponent<Botao>().TeclaPlayer;
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

        if (giroAtual < 1.0f && ativo == true && temBotao == true && Input.GetKey(teclaPlayer))
        {
            giroAlvo = grausDeGiro;
            segAtual = seg;

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
