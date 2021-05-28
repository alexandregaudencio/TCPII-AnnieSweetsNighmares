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

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        alvo = GameObject.FindWithTag("tesouro").transform.position;
        eu = this.transform.position;
        spawn = Random.Range(0, SpawnChance);

    }

    void Update()
    {
        navMeshAgent.SetDestination(alvo);


    }

    public void Droppar()
    {


        Instantiate(chave, eu, Quaternion.identity);

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("martelo"))
        {
            Droppar();
            Destroy(gameObject);
            // m_Velocidade = 0;


        }
        if (collision.gameObject.CompareTag("tesouro"))
        {
            GameOver.instance.vida= GameOver.instance.vida-0.5f;
            Destroy(gameObject);
            // m_Velocidade = 0;


        }



    }


}
