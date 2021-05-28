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
    private Vector3 alvo;
    private Vector3 eu;
    float spawn = 0;
    public GameObject chave;
    public int SpawnChance;

    private int id;
    private enum Urso { red, orange, blue };
    private Urso urso;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        alvo = GameObject.FindWithTag("tesouro").transform.position;
        id = gameObject.layer;
        spawn = Random.Range(0, SpawnChance);

        if (id == 8) urso = Urso.blue;
        else if (id == 9) urso = Urso.red;
        else if (id == 10) urso = Urso.orange;

    }

    void Update()
    {
        navMeshAgent.SetDestination(alvo);
        eu = this.transform.position;
        takeUrso();

    }

    public void Droppar()
    {
        Destroy(gameObject);
        if (spawn > 10)
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

            GameOver.instance.vida = GameOver.instance.vida - 0.5f;
            Destroy(gameObject);
            //Droppar();
            // m_Velocidade = 0;


        }
        if (collision.gameObject.CompareTag("arm"))
        {

            if (id == 8 && collision.gameObject.layer == 13)
            {
                Droppar();
                Destroy(collision.gameObject);
            }
            if (id == 9 && collision.gameObject.layer == 14)
            {
                Droppar();
                Destroy(collision.gameObject);
            }
            if (id == 10 && collision.gameObject.layer == 15)
            {
                Droppar();
                Destroy(collision.gameObject);
            }
        }



    }


}
