using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{

    private GameObject Jogador;
    public KeyCode teclaPlayer;
    public GameObject botao;
    public KeyCode TeclaAbrir = KeyCode.E;

   // public KeyCode usar;
    public float giroAtual, giroAlvo, posAtual, posAlvo, posAtual2, posAlvo2;
    public int tempoDeVolta;
    Vector3 rotacaoInicial, posicaoInicial;
    float velocidade;
    private GameObject mao;
    private GameObject chave;

    public float altura = 15.8f;
    public float altura2 = 20.0f;
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
        posAtual = 0.0f;
        posAtual2 = 0.0f;

        rotacaoInicial = transform.eulerAngles;
        posicaoInicial = this.transform.position;

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
            posAlvo = 0.0f;
            posAtual2 = 0.0f;
        }

    }

    void ControlarPorta()
    {

        if (giroAtual < 1.0f && ativo == true && temBotao == true && Input.GetKey(teclaPlayer))
        {
            giroAlvo = grausDeGiro;
            posAlvo = altura;
            posAlvo2 = altura2;
            segAtual = seg;

        }



        giroAtual = Mathf.MoveTowards(giroAtual, giroAlvo, velocidadeDeGiro * Time.deltaTime);
        posAtual = Mathf.MoveTowards(posAtual, posAlvo, velocidadeDeGiro * Time.deltaTime);
        posAtual2 = Mathf.MoveTowards(posAtual2, posAlvo2, velocidadeDeGiro * Time.deltaTime);


    }


    void Ativar()
    {
        switch (Rotacao)
        {
            case Bater.ir:
                this.transform.eulerAngles = new Vector3(rotacaoInicial.x + giroAtual, rotacaoInicial.y, rotacaoInicial.z);
                this.transform.position = new Vector3(posicaoInicial.x, posicaoInicial.y + posAtual, posicaoInicial.z - posAtual2);
                break;
            case Bater.voltar:
                this.transform.eulerAngles = new Vector3(rotacaoInicial.x - giroAtual, rotacaoInicial.y, rotacaoInicial.z);
                this.transform.position = new Vector3(posicaoInicial.x, posicaoInicial.y + posAtual, posicaoInicial.z - posAtual2);
                break;
        }
    }
}
