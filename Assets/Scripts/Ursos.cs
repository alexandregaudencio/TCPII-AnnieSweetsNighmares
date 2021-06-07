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

    
    public AudioSource myFx;
    public AudioSource myFxall;
    
    public AudioClip  morreu, nasceu, chegou, drop;


    private Animator anim;
    //string s = "";

    bool andando = true;


   


    // Start is called before the first frame update
    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(controleSpawnUrso == null) controleSpawnUrso = GetComponent<ControleSpawnUrso>();
        navMeshAgent.speed = speedUrso * ControleSpawnUrso.instance.speedUrsoMultiplicador;
        alvo = GameObject.FindWithTag("tesouro").transform.position;
        id = gameObject.layer;
        myFx = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
 myFx.Play(0);
 
        myFx.Pause();
        
        Debug.Log("started");
        
        myFxall.PlayOneShot(nasceu);

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


        if(this.transform.position.x > -20.0f && this.transform.position.x < 20.0f && andando == true)
         {
myFx.UnPause();
            
         }
         else{
             myFx.Pause();
         }
       
    }


    public void AtivarSom(string s)
    {

        switch (s)
        {
            case "drop":
                myFxall.PlayOneShot(drop);
                break;

            case "chegou":
                myFxall.PlayOneShot(chegou);
                break;

            case "morreu":
                myFxall.PlayOneShot(morreu);
                break;

            case "nasceu":
                myFxall.PlayOneShot(nasceu);
                break;
        }
    }
    public void Droppar()
    {

      
        if(id == 9)
        {
            andando = false;
            anim.SetBool("colidiu", true);
            Destroy(gameObject, 4f);
                navMeshAgent.speed = 0;
                 
        }
        if (id == 8)
        {
            andando = false;
            if(animUrsoRapido<50) anim.SetBool("colidiuPe", true);
            if (animUrsoRapido>= 50) anim.SetBool("colidiuCaiu", true);
            Destroy(gameObject, 2f);
            navMeshAgent.speed = 0;
            
        }
        if (id == 10)
        {
            andando = false;
            anim.SetBool("colidiu", true);
             Destroy(gameObject, 3f);
            navMeshAgent.speed = 0;
             

        }


if (ControleSpawnUrso.instance.CanDropKey()){
        
            Instantiate(chave, eu, Quaternion.identity);
            AtivarSom("drop");
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
        RestoreArm(collision);

        if (collision.gameObject.CompareTag("martelo"))
        {
            AtivarSom("morreu");
            andando = false;            
            Destroy(gameObject, 1f);
           
        }

        if (collision.gameObject.CompareTag("tesouro") && GameOver.instance.vida > 0 && ControleSpawnUrso.instance.IsGameplayOn)
        {
            AtivarSom("chegou");
            andando = false;                        
            GameOver.instance.vida--;
   //
             Droppar();
            Destroy(gameObject,2f);
           gameObject.SetActive(false);
            // m_Velocidade = 0;


        }
        if (collision.gameObject.CompareTag("arm"))
        {

            if (id == 8 && collision.gameObject.layer == 13)
            {
                AtivarSom("morreu");
                andando = false;
                Droppar();
                Destroy(collision.gameObject,2f);
                
            }
            if (id == 9 && collision.gameObject.layer == 14)
            {
                AtivarSom("morreu");
                andando = false;
                Droppar();
                Destroy(collision.gameObject,4f);
            }
            if (id == 10 && collision.gameObject.layer == 15)
            {
                AtivarSom("morreu");
                andando = false; 
                Droppar();
                Destroy(collision.gameObject,3f);
            }

        }

        



    }

    public void RestoreArm(Collider collision)
    {
        if(collision.CompareTag("LA1")) {
            MesaEsquerda.instance.jaTem = false;

        } else if (collision.CompareTag("LA2"))
        {
            MesaEsquerda.instance.jaTem2 = false;

        }
        else if (collision.CompareTag("LA3"))
        {
            MesaEsquerda.instance.jaTem3 = false;

        }
        else if (collision.CompareTag("LA4"))
        {
            MesaEsquerda.instance.jaTem4 = false;

        }
    }


}
