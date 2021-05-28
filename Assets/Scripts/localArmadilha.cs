using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localArmadilha : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
       //n esta sendo usada
    }
    void Update()
    {
       
    }
    /*private void OnTriggerEnter(Collider collision)
    {
        playerMenina playerScript = GameObject.Find("playerMenina").GetComponent<playerMenina>();
        if (collision.gameObject.CompareTag("urso"))
        {
            if (id == 0)
            {
                if (playerScript.jaTem == true)
                {
                    playerScript.jaTem = false;
                }
            }
            if (id == 1)
            {
                if (playerScript.jaTem2 == true)
                {
                    playerScript.jaTem2 = false;
                }
            }


        }
    }*/
}