using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSpawnUrso : MonoBehaviour
{
    //[SerializeField] private float gameTime;
    //TempoTeste tempoTeste;
    [SerializeField] private spawUrso[] spawUrso;
    [SerializeField] private float spawnInterval = 10f;
    private int spawnAtEveryPointCount = 5;
    private bool spawningAtEveryPoints;
    public float speedUrsoMultiplicador;

    [SerializeField] [Range(0, 5)] private int toSpawnAtEveryPointCount = 0;
    
    public static ControleSpawnUrso instance;

    [SerializeField] [Range(0, 100)] private float keySpawnProbability;
    //public float getKeySpawnProbability { get => keySpawnProbability; }*/

    private bool isTimeOn = true;
    public bool IsTimeOn { get => isTimeOn; set => isTimeOn = value; }

    public bool CanDropKey()
    {
        float randomSpawnNumber = Random.Range(0, 100);
        Debug.Log(randomSpawnNumber);
        return randomSpawnNumber <= keySpawnProbability ? true : false;

    }



    float Timer = 0f;
    private bool waveAttackOn = true;



    private void Start()
    {
        instance = this;
        //tempoTeste = GetComponent<TempoTeste>();
        //tempoTeste.timeValue = gameTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (TempoTeste.tempoTesteInstante.timeValue <= 0f) isTimeOn = false;
        Debug.Log(TempoTeste.tempoTesteInstante.timeValue);


        if(isTimeOn) { 
            Timer += Time.deltaTime;
            if(waveAttackOn && Timer >= spawnInterval)
            {
                GenerateSpawnUrso(spawningAtEveryPoints);
                Timer = 0;
            }
            if(toSpawnAtEveryPointCount >= spawnAtEveryPointCount) spawningAtEveryPoints = true;
        }

    }

    void GenerateSpawnUrso(bool everySpawnPoint)
    {
        if(everySpawnPoint)
        {
            foreach (spawUrso iSpawnUrso in spawUrso)
            { 
                iSpawnUrso.OnAttackWave();
            }
            spawningAtEveryPoints = false;
            toSpawnAtEveryPointCount = 0;
        } else
        {
            int indexArrayRandom = Random.Range(0, spawUrso.Length);
            spawUrso[indexArrayRandom].OnAttackWave();
            toSpawnAtEveryPointCount += 1;
        }
    }


}
