using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSpawnUrso : MonoBehaviour
{
    [SerializeField] private spawUrso[] spawUrso;
    [SerializeField] private float spawnInterval = 10f;
    private bool waveAttackOn = true;
    [SerializeField] private bool spawningAtEveryPoints;

    float Timer = 0f;

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        if(waveAttackOn && Timer >= spawnInterval)
        {
            GenerateSpawnUrso(spawningAtEveryPoints);
            Timer = 0;
        }
    }

    void GenerateSpawnUrso(bool everySpawnPoint)
    {
        if( everySpawnPoint)
        {
            foreach (spawUrso iSpawnUrso in spawUrso)
            { 
                iSpawnUrso.OnAttackWave();
            }
            spawningAtEveryPoints = false;
            

        } else
        {
            int indexArrayRandom = Random.Range(0, spawUrso.Length);
            spawUrso[indexArrayRandom].OnAttackWave();
        }
    }




}
