using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawUrso : MonoBehaviour
{

    public GameObject[] ursinho;
    private float spawnPositionX;
    private float spawnPositionZ;
    [Range(0f, 3.0f)] public float spawnRangeX;
    [Range(0.0f, 30.0f)] public float spawnRangeZ;


    public void OnAttackWave() {
        int ursoCor = Random.Range(0, ursinho.Length);
        Instantiate(ursinho[ursoCor], Vector3Random(), Quaternion.identity);
        
    }
    
    void OnDrawGizmos()
    {
        Vector3 LineX = new Vector3(spawnRangeX, 0, 0);
        Vector3 LineZ = new Vector3(0, 0, spawnRangeZ);
        Gizmos.DrawLine(transform.position-LineX/2,transform.position + LineX/2);
        Gizmos.DrawLine(transform.position-LineZ/2, transform.position + LineZ/2);
        Gizmos.DrawWireCube(transform.position, LineX+LineZ);
    }

    public Vector3 Vector3Random()
    {
        spawnPositionX = Random.Range(-spawnRangeX/2, spawnRangeX/2);
        spawnPositionZ = Random.Range(-spawnRangeZ/2, spawnRangeZ/2);
        return new Vector3(this.transform.position.x + spawnPositionX,
            this.transform.position.y, this.transform.position.z + spawnPositionZ);
    }
}

