using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ursos : MonoBehaviour
{
    // [SerializeField] private GameObject azulUi;
    //public float m_Velocidade;
    //private GameObject[] m_Posicao;
    // public Transform[] m_Posicao;
    //public int opcao;

    public NavMeshAgent navMeshAgent;
    private ControleSpawnUrso controleSpawnUrso;
    private Vector3 alvo;
    private Vector3 eu;
    //float spawn;
    public GameObject chave;
    [Range(0,1)] public float SpawnChance;
    public float speedUrso;

    int animUrsoRapido;

    private int id;
    private enum Urso { red, orange, blue };
    private Urso urso;



    private Animator anim;

   


    // Start is called before the first frame update
    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(controleSpawnUrso == null) controleSpawnUrso = GetComponent<ControleSpawnUrso>();
        navMeshAgent.speed = speedUrso * ControleSpawnUrso.instance.speedUrsoMultiplicador;
        alvo = GameObject.FindWithTag("tesouro").transform.position;
        id = gameObject.layer;


        anim = GetComponent<Animator>();

        if (id == 8) urso = Urso.blue;
        else if (id == 9) urso = Urso.red;
        else if (id == 10) urso = Urso.orange;

    }

    void Update()
    {                 
        navMeshAgent.SetDestination(alvo);
        eu = this.transform.position;
        takeUrso();
        animUrsoRapido = Random.Range(0, 100);
       
    }




    public void Droppar()
    {
        if(id == 9)
        {
            anim.SetBool("colidiu", true);
            Destroy(gameObject, 4f);
                navMeshAgent.speed = 0;
        }
        if (id == 8)
        {
           
            if(animUrsoRapido<50) anim.SetBool("colidiuPe", true);
            if (animUrsoRapido>= 50) anim.SetBool("colidiuCaiu", true);
            Destroy(gameObject, 2f);
            navMeshAgent.speed = 0;
        }
        if (id == 10)
        {
            anim.SetBool("colidiu", true);
             Destroy(gameObject, 3f);
            navMeshAgent.speed = 0;
        }



;        if (ControleSpawnUrso.instance.CanDropKey())
        {
            Instantiate(chave, eu, Quaternion.identity);

        }
    }



    public void takeUrso()
    {
        switch (urso)
        {
            case Urso.blue:
                break;
            case Urso.red:
                break;
            case Urso.orange:
                break;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("martelo"))
        {
            Droppar();
            // m_Velocidade = 0;

        }

        if (collision.gameObject.CompareTag("tesouro"))
        {

            GameOver.instance.vida--;
            //anim.SetBool("colidiu", true);
            Droppar();
            Destroy(gameObject);
            // m_Velocidade = 0;


        }
        if (collision.gameObject.CompareTag("arm"))
        {

            if (id == 8 && collision.gameObject.layer == 13)
            {
               
                Droppar();
                Destroy(collision.gameObject,2f);
            }
            if (id == 9 && collision.gameObject.layer == 14)
            {
                Droppar();
                Destroy(collision.gameObject,4f);
            }
            if (id == 10 && collision.gameObject.layer == 15)
            {
                Droppar();
                Destroy(collision.gameObject,3f);
            }
        }



    }


}
