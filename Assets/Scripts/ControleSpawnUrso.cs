using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSpawnUrso : MonoBehaviour
{
    [SerializeField] private spawUrso[] spawUrso;
    [SerializeField] private float spawnInterval = 10f;

    [SerializeField] private bool spawningAtEveryPoints;
    [SerializeField] [Range(0,3)] private int spawnCount = 0;
    public static ControleSpawnUrso instance;
    public float speedUrsoMultiplicador;

        float Timer = 0f;
    private bool waveAttackOn = true;

    private void Start()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        if(waveAttackOn && Timer >= spawnInterval)
        {
            GenerateSpawnUrso(spawningAtEveryPoints);
            Timer = 0;
        }

        if(spawnCount >=3)
        {
            spawningAtEveryPoints = true;
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
            spawnCount = 0;
            

        } else
        {
            int indexArrayRandom = Random.Range(0, spawUrso.Length);
            spawUrso[indexArrayRandom].OnAttackWave();
            spawnCount += 1;
        }
    }


}
